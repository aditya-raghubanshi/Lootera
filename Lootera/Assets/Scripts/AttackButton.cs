using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{

    GameObject player;
    Animator animate;
    GameObject dragonblade;
    public bool pressed = false;
    Movement movement;
    int count = 1;

    public void attack()
    {
        count++;
        Debug.Log(count);
        attackcall();

    }
    public void attackcall()
    {
        if (count == 1)
        {
            attackfunc();
        }
        if (count == 2)
        {
            attackfunc2();
        }
        if (count == 3)
        {
            attackfunc3();
        }
    }
    public void attackfunc()
    {
        Debug.Log("Called 1");
        player = GameObject.Find("Player");
        animate = player.GetComponent<Animator>();
        Movement movement = player.GetComponent<Movement>();
        animate.SetFloat("Attack", 1f);
        pressed = true;
        movement.movSpeed = 0f;
        StartCoroutine(ExecuteAfterTime(0.5f, movement));
    }
    public void attackfunc2()
    {
        Debug.Log("Called 2");
        player = GameObject.Find("Player");
        animate = player.GetComponent<Animator>();
        Movement movement = player.GetComponent<Movement>();
        animate.SetInteger("Attack2", 2);
        pressed = true;
        movement.movSpeed = 0f;
        StartCoroutine(ExecuteSecondAttack(0.5f, movement));
    }
    public void attackfunc3()
    {
        Debug.Log("Called 3");
        player = GameObject.Find("Player");
        animate = player.GetComponent<Animator>();
        Movement movement = player.GetComponent<Movement>();
        animate.SetInteger("Attack3", 3);
        pressed = true;
        movement.movSpeed = 0f;
        StartCoroutine(ExecuteThirdAttack(0.5f, movement));
    }
    IEnumerator ExecuteAfterTime(float sec, Movement movement)
    {
        yield return new WaitForSeconds(sec);
        animate.SetFloat("Attack", -1f);
        //animate.SetInteger("Attack2", 0);
        //animate.SetInteger("Attack3", 0);
        pressed = false;
        movement.movSpeed = 10f;
        count = 2;
        Debug.Log(count);
    }
    IEnumerator ExecuteSecondAttack(float sec, Movement movement)
    {
        yield return new WaitForSeconds(sec);
        animate.SetInteger("Attack2", 0);
        pressed = false;
        movement.movSpeed = 10f;
        count = 3;
        Debug.Log(count);
    }
    IEnumerator ExecuteThirdAttack(float sec, Movement movement)
    {
        yield return new WaitForSeconds(sec);
        animate.SetInteger("Attack3", 0);
        pressed = false;
        movement.movSpeed = 10f;
        count = 1;
        Debug.Log(count);
    }


}
