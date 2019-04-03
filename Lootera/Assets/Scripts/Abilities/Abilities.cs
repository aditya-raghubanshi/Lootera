using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    float doHealingShout;
    float doShieldBash;
    float closeRadius = 10f;
    float shieldBashDamage = 30f;
    float shieldBashCost = 70f;
    private PlayerHealth health;
    private PlayerMana mana;
    private GameObject player;
    private Animator animate;
    AbilitySlots abilities;
    int ability1;
    int ability2;
    int ability3;

    void Start()
    {
        doHealingShout = 0f;
        player = GameObject.Find("Player");
        health = FindObjectOfType<PlayerHealth>();
        mana = FindObjectOfType<PlayerMana>();
        animate = player.GetComponent<Animator>();
        abilities = FindObjectOfType<AbilitySlots>();
        ability1 = abilities.GetAbility1();
        ability2 = abilities.GetAbility2();
        ability3 = abilities.GetAbility3();
                
    }

    // Update is called once per frame
    void Update()
    {


        animate.SetFloat("HealingShout", doHealingShout);
        doHealingShout = 0f;
        animate.SetFloat("ShieldBash", doShieldBash);
        doShieldBash = 0f;

    }

    public void ToggleAbility1()
    {
        switch (ability1)
        {
            case 1:
                HealingShout();
                break;
            case 2:
                ShieldBash();
                break;
        }
    }

    public void ToggleAbility2()
    {
        switch (ability2)
        {
            case 1:
                HealingShout();
                break;
            case 2:
                ShieldBash();
                break;
        }
    }

    public void ToggleAbility3()
    {
        switch (ability3)
        {
            case 1:
                HealingShout();
                break;
            case 2:
                ShieldBash();
                break;
        }
    }

    void HealingShout()
    {
        
        if (mana.Getmana() < 10f)
        {
            //Not Enough Mana
        }
        else if (health.GetHealth() == 100f)
        {
            //FullHealth
        }
        else
        {
            doHealingShout = 1f;
            
            health.Heal(30f);
            mana.Damage(10f);
        }
    }

    void ShieldBash()
    {
        if (mana.Getmana() < shieldBashCost)
        {
            //Not Enough Mana
        }
        else
        {

            doShieldBash = 1f;
            Collider[] colliders = Physics.OverlapSphere(player.transform.transform.position, closeRadius);
            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(5000f, player.transform.transform.position, closeRadius);

                }
                Dungeon_Monster_Controller monster = nearbyObject.GetComponent<Dungeon_Monster_Controller>();
                if (monster != null)
                {
                    monster.Damage(shieldBashDamage);
                    mana.Damage(shieldBashCost);
                    print(monster.getHealth());
                }

            }
        }
    }

}
