using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Sword_Attack : MonoBehaviour
{
    public float damage = 20f;
    Movement Player;
    public AudioSource source;
    PlayerHealth health;
    Animator anim;

    void OnTriggerEnter(Collider col)
    {

        health = FindObjectOfType<PlayerHealth>();        
        Player = col.gameObject.GetComponent<Movement>();
        source = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
        print(anim);
        if (Player != null)
        {
            print("Inside Player");
            if (anim.GetBool("attacking") == true)
            {
                health.Damage(damage);
                source.Play();
            }
        }

    }

  
}

