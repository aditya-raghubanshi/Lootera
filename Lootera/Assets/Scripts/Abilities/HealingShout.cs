using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingShout : MonoBehaviour
{
    public float healAmount = 10;
    public float manaUse = 20;
    private PlayerHealth health;
    private PlayerMana mana;
    private GameObject player;
    private Animator animate;
    private Movement mov;
    

    public void Heal()
    {
        
        if (mana.Getmana() < manaUse)
        {
            //Not Enough Mana
            return ;
        }
        health = FindObjectOfType<PlayerHealth>();
        mana = FindObjectOfType<PlayerMana>();
        player = GameObject.Find("Player");
        animate = player.GetComponent<Animator>();
        
        health.Heal(healAmount);
        mana.Damage(manaUse);
    }
    
}
