using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{

    GameObject player;
    Animator animate;
    public GameObject dragonblade ;
    public GameObject Bow;
    public GameObject Viking_Sword;
    public bool pressed = false;
    Movement movement;
    int count = 1;
    public static int weaponID = 36;

    public void SlotWeapon(int weaponID)
    {
        //dragonblade = GameObject.Find("Dragonblade");
        //Bow = GameObject.Find("BOW");
        //Debug.Log(weaponID);
        //Debug.Log("Slotter called");
        if(weaponID == 36)
        {
            Debug.Log(" BOW " + Bow.activeInHierarchy);
            Debug.Log(" dragonblade " + dragonblade.activeInHierarchy);
        
            if (!dragonblade.activeInHierarchy)
            {
                Debug.Log(" dragonblade set true");
                dragonblade.SetActive(true);
            }
            //Bow.SetActive(false);
            
            if (Bow.activeInHierarchy)
            {
                Bow.SetActive(false);
            }

            if (Viking_Sword.activeInHierarchy)
            {
                Viking_Sword.SetActive(false);
            }
            //weaponID = 42;
            //attackcall();
        }
        else if( weaponID == 42)
        {
            //Debug.Log(" BOW " + Bow.activeInHierarchy);
            //Debug.Log(" dragonblade " + dragonblade.activeInHierarchy);
            if (!Bow.activeInHierarchy)
            Bow.SetActive(true);
            //dragonblade.SetActive(false);
            if (dragonblade.activeInHierarchy)
            {
                dragonblade.SetActive(false);
            }
            if (Viking_Sword.activeInHierarchy)
            {
                Viking_Sword.SetActive(false);
            }
            //weaponID = 37;
            //arrowspawn();

        }
        else if( weaponID == 37)
        {
            if (!Viking_Sword.activeInHierarchy)
                Viking_Sword.SetActive(true);
            if (dragonblade.activeInHierarchy)
            {
                dragonblade.SetActive(false);
            }
            if (Bow.activeInHierarchy)
            {
                Bow.SetActive(false);
            }
            //weaponID = 36;
        }
    }
    public void choseAttack()
    {
        if (weaponID == 36 || weaponID == 37)
        {
            attackcall();
        }
        else if(weaponID == 42)
        {
            arrowspawn();
        }
    }
    public void attackcall()
    {
        
        Debug.Log(count);
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
    public void Update()
    {
        //Debug.Log(weaponID);
        SlotWeapon(weaponID);
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
        StartCoroutine(ExecuteAfterTime(1.3f, movement));
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
    //====================Arrow Code ====================================================
    public Camera cam;
    public Camera cam2;
    public Camera cam3;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public Transform arrowSpawn2;
    public Transform arrowSpawn3;
    
    public float shootForce = 20f;
    public int Drawed = 0;

    public void arrowspawn()
    {
        if (Drawed == 0)
        {
            player = GameObject.Find("Player");
            //Bow = GameObject.Find("BOW");
            animate = player.GetComponent<Animator>();
            animate.SetInteger("Arrow", 1);
            cam.transform.rotation = Bow.transform.rotation * Quaternion.Euler(-180, 180, 0);
            cam2.transform.rotation = Bow.transform.rotation * Quaternion.Euler(-180, 155, 0);
            cam3.transform.rotation = Bow.transform.rotation * Quaternion.Euler(-180, 205, 0);
            Drawed = 1;
            StartCoroutine(ExecuteAfterTime(0.5f));

        }


    }

    IEnumerator ExecuteAfterTime(float sec)
    {
        yield return new WaitForSeconds(sec);
        GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        GameObject go1 = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        GameObject go2 = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        go.transform.rotation = cam.transform.rotation * Quaternion.Euler(270, 0, 0);
        go1.transform.rotation = cam2.transform.rotation * Quaternion.Euler(270, 0, 0);
        go2.transform.rotation = cam3.transform.rotation * Quaternion.Euler(270, 0, 0);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.velocity = cam.transform.forward * shootForce;
        Rigidbody rb1 = go1.GetComponent<Rigidbody>();
        rb1.velocity = cam2.transform.forward * shootForce;
        Rigidbody rb2 = go2.GetComponent<Rigidbody>();
        rb2.velocity = cam3.transform.forward * shootForce;
        animate.SetInteger("Arrow", 0);
        Drawed = 0;

    }
}









