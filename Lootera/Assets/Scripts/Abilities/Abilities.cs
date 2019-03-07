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

    void Start()
    {
        doHealingShout = 0f;
        player = GameObject.Find("Player");
        health = FindObjectOfType<PlayerHealth>();
        mana = FindObjectOfType<PlayerMana>();
        animate = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        doHealingShout = 0f;
        animate.SetFloat("HealingShout", 0f);

    }

    void HealingShout()
    {
        animate.SetFloat("HealingShout", 1f);
    }

}
