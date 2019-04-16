using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Sword_Attack : MonoBehaviour
{
    public float damage = 20f;
    Movement Player;
    public AudioSource source;
    PlayerHealth health;
    private Skeleton_Animation_Script damageAnimationsScript;
    Animator anim;
    bool doDamage = false;
    void OnTriggerEnter(Collider col)
    {


        health = FindObjectOfType<PlayerHealth>();
        damageAnimationsScript = FindObjectOfType<Skeleton_Animation_Script>();
        Player = col.gameObject.GetComponent<Movement>();
        source = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
        if (Player != null)
        {
            print("Inside Player");
            print(anim.GetBool("attacking"));
            print(damageAnimationsScript.getDoDamage());
            source.Play(); 
            if (damageAnimationsScript.getDoDamage())
            {
                health.Damage(damage);
            }
        }

    }

}

