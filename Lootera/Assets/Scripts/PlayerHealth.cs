using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float health;
    private float maxHealth;
    private Image healthbar;
    public float resistance;
    GameObject gameOver;
    Animator animate;
    GameObject player;
    Movement mvmnt;

    void Start()
    {
        healthbar = GetComponent<Image>();
        health = 200f + PlayerStats.constitution;
        maxHealth = 200f + PlayerStats.constitution;
        resistance = 0f;
        player = GameObject.Find("Player");
        animate = player.GetComponent<Animator>();
        mvmnt = player.GetComponent<Movement>();
        gameOver = GameObject.Find("Game Over 1");
        gameOver.SetActive(false);
        
    }

    public void setResistance(float res)
    {
        resistance = res;
    }

    public PlayerHealth(float health = 100f)
    {
        this.health = health;
        this.maxHealth = health;
    }

    public float GetHealth()
    {
        return health;
    }

    public void Damage(float damageAmount)
    {
        damageAmount -= damageAmount * resistance;
        health -= damageAmount;

        if (health <= 0)
        {
            //Debug.Log("health 0");
            health = 0f;
            animate.SetFloat("dead", 1f);
            mvmnt.canMove = 0;
            StartCoroutine(DelayedDeath(2));
            
            
        }
        healthbar.fillAmount = health / maxHealth;
    }

    public void Heal(float HealAmount)
    {
        health += HealAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthbar.fillAmount = health / maxHealth;
    }

    IEnumerator DelayedDeath(int time)
    {
        yield return new WaitForSeconds(time);

        gameOver.SetActive(true);
        SaveData.flag = 2;
    }
}
