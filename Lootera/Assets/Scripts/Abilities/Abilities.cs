using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    float doHealingShout;
    float doShieldBash;
    float doDash;
    float closeRadius = 10f;
    float shieldBashDamage = 30f;
    float shieldBashCost = 70f;
    float rollCost = 20f;
    float rollSpeed = 60f;
    float damagingAuraDamage = 10f;
    float doDamagingAura = 0f;
    private PlayerHealth health;
    private PlayerMana mana;
    private GameObject player;
    private Animator animate;
    private Joystick joystick;
    private Movement mov;
    AbilitySlots abilities;
    int ability1;
    int ability2;
    int ability3;
    GameObject magicCircle;

    void Start()
    {
        doHealingShout = 0f;
        player = GameObject.Find("Player");
        mov = FindObjectOfType<Movement>();
        health = FindObjectOfType<PlayerHealth>();
        mana = FindObjectOfType<PlayerMana>();
        animate = player.GetComponent<Animator>();
        abilities = FindObjectOfType<AbilitySlots>();
        magicCircle = GameObject.Find("MagicCircle");
        magicCircle.SetActive(false);
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
        animate.SetFloat("roll", doDash);
        doDash = 0f;
        if(doDamagingAura == 1f)
        {
            
        }

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
            case 3:
                Roll();
                break;
            case 4:
                DoDamagingAura();
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
            case 3:
                Roll();
                break;
            case 4:
                DoDamagingAura();
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
            case 3:
                Roll();
                break;
            case 4:
                DoDamagingAura();
                break;
        }
    }

    IEnumerator MovementStop(int sec)
    {
        yield return new WaitForSeconds(sec);
        mov.canMove = 1;
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
            mov.canMove = 0;
            StartCoroutine(MovementStop(2));
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
            mov.canMove = 0;
            StartCoroutine(MovementStop(2));
            mana.Damage(shieldBashCost);
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

                    print(monster.getHealth());
                }

            }
        }
    }

    public void Roll()
    {
        joystick = FindObjectOfType<Joystick>();
        if(mana.Getmana() < rollCost)
        {

        }
        else
        {
            doDash = 1f;
            mana.Damage(rollCost);
            for (int i = 1; i <= 10; i++)
            {
                
                Vector3 movement = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);
                player.transform.Translate(movement * rollSpeed * Time.deltaTime, Space.World);
                
            }

        }

    }

    public void DamagingAura()
    {
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
                monster.Damage(damagingAuraDamage);

            }

        }
    }

    public void DoDamagingAura()
    {
        if(doDamagingAura == 0f) {

            doDamagingAura = 1f;
            InvokeRepeating("DamagingAura", 0f, 1f);
            mana.permaDamage(40f);
            magicCircle.SetActive(true);
        }
        else
        {
            CancelInvoke("DamagingAura");
            doDamagingAura = 0f;
            mana.permaRestore(40f);
            magicCircle.SetActive(false);
        }
        
    }


}
