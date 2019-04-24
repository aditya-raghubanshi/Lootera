using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class Minotaur_Controller : MonoBehaviour
{
    public NavMeshAgent Agent;
    CharacterController controller;
    Animator anim;
    float attackRadius;
    public float visibleRadius = 20;
    public float enemyMaxHealth = (Level.level +2 )*101f;
    public float enemyHealth;
    private PlayerHealth health;
    public Image healthBar;
    private Vector3 currentPostionOfEnemy;
    private Quaternion currentRotationOfEnemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        attackRadius = Agent.stoppingDistance;
        //print("Dungeon Monster in Start");
        health = FindObjectOfType<PlayerHealth>();

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Vector3 PlayerPosition = GameObject.Find("Player").transform.position;
        float dist = Vector3.Distance(transform.position, PlayerPosition);
        
        // When are we walking? - when we can see him and we are not attacking;
        if (dist < visibleRadius)
        {
            //print("Inside Visible Radius");
            // when to stop walking when we are walking.
            // if we are in attack radius 
            if (dist < attackRadius)
            {
                //print("Inside Attack");
                Attack(PlayerPosition);
            }
            // if he is out of visible radius. 
            else if (dist > visibleRadius)
            {
                Idle();
            }
            else
            {
                Walk(PlayerPosition);
            }
            healthBar.fillAmount = enemyHealth / enemyMaxHealth;

        }
        // When to become Idle - don`t really care which state we are in, if he is out of range just stop.

        if (dist > visibleRadius)
        {
            Idle();
        }

        // When to Attack
        if (dist < attackRadius)
        {

            Attack(PlayerPosition);

            //health.Damage(10);
        }
        // if my health is 0; then die


    }

    void Walk(Vector3 PlayerPosition)
    {

        this.transform.LookAt(PlayerPosition);
        anim.SetBool("running", true);
        anim.SetInteger("condition", 1);
        anim.SetBool("attacking", false);
        Agent.SetDestination(PlayerPosition);
        controller.Move(Agent.desiredVelocity * Time.deltaTime);
    }
    void Attack(Vector3 PlayerPosition)
    {
        this.transform.LookAt(PlayerPosition);

        //print("Inside attack function");
        anim.SetBool("running", false);
        anim.SetInteger("condition", 2);
        anim.SetBool("attacking", true);

        controller.Move(Vector3.zero);
        //Agent.SetDestination(Vector3.zero);

    }
    void Idle()
    {
        anim.SetBool("running", false);
        anim.SetInteger("condition", 0);
        anim.SetBool("attacking", false);
        controller.Move(Vector3.zero);
        //Agent.SetDestination(Vector3.zero);
    }

    public void Damage(float damage)
    {
        enemyHealth = enemyHealth - damage;
        anim.SetFloat("Hit", 1f);
        StartCoroutine(BackToIdle(0.5f));
        //Debug.Log("Mino damaged");
        //Debug.Log(damage);
        if (enemyHealth <= 0f)
        {

            anim.SetBool("running", false);
            anim.SetInteger("condition", 3);
            anim.SetBool("attacking", false);
            anim.SetFloat("Dead", 1f);
            StartCoroutine(MonsterDead(2));
            
        }
    }

    public float getHealth()
    {
        return enemyHealth;
    }

    IEnumerator MonsterDead(int sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }

    IEnumerator BackToIdle(float sec)
    {
        yield return new WaitForSeconds(sec);
        anim.SetFloat("Hit", 0f);
    }

}
