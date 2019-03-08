using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float dmgAmount = 10f;
    private PlayerHealth health;

    void Start()
    {

    }
    public void DamageEvent()
    {
        health = FindObjectOfType<PlayerHealth>();
        health.Damage(dmgAmount);
        

    }
}
