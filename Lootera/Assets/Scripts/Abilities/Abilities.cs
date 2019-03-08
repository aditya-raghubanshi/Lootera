using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    float doHealingShout;
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

    }

    public void ToggleAbility1()
    {
        switch (ability1)
        {
            case 1:
                HealingShout();
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
        }
    }

    public void ToggleAbility3()
    {
        switch (ability3)
        {
            case 1:
                HealingShout();
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

}
