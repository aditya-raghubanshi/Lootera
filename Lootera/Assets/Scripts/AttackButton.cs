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
    public void attack()
    {

        print("Attack Button Pressed");
        player = GameObject.Find("Player");
        animate = player.GetComponent<Animator>();
        Movement movement = player.GetComponent<Movement>();
        animate.SetFloat("Attack", 1f);
        pressed = true;
        movement.movSpeed = 0f;
        StartCoroutine(ExecuteAfterTime(0.5f, movement));

    }

    IEnumerator ExecuteAfterTime(float sec, Movement movement)
    {
        yield return new WaitForSeconds(sec);
        animate.SetFloat("Attack", -1f);
        pressed = false;
        movement.movSpeed = 10f;
        
    }
}
