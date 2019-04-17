using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float dmgAmount;
    private PlayerHealth health;

    public AudioSource source;
    float range = 3f;

    void Start()
    {
        source = GetComponent<AudioSource>();
        dmgAmount = (Level.level + 1) * 10f;


    }
    public void DamageEvent()
    {
        
        health = FindObjectOfType<PlayerHealth>();
        Vector3 PlayerPosition = GameObject.Find("Player").transform.position;
        Vector3 myPostion = this.transform.position;
        float dist = Vector3.Distance(transform.position, PlayerPosition);
        if (dist < range)
        {
            source.Play();
            health.Damage(dmgAmount);
        }

    }
}
