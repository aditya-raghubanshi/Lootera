using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    // Start is called before the first frame update
    private float mana;
    private float maxMana;
    public float manaRegen = 1f;
    public float permaDamageAmount;
    public float tempMaxmana;
    Image manaBar;

    void Start()
    {
        manaBar = GetComponent<Image>();
        mana = 100f;
        maxMana = 100f;
        tempMaxmana = maxMana;
        permaDamageAmount = 0f;
    }

    void Update()
    {
        mana += manaRegen;
        if (mana < 0)
        {
            mana = 0;
        }

        if (mana > tempMaxmana)
        {
            mana = tempMaxmana;
        }

        manaBar.fillAmount = mana / maxMana;
    }
    public PlayerMana(float mana = 100f)
    {
        this.mana = mana;
        this.maxMana = mana;
    }

    public float Getmana()
    {
        return mana;
    }

    public void Damage(float spentAmount)
    {
        mana -= spentAmount;
        /*if (mana < 0)
        {
            mana = 0;
        }
        manaBar.fillAmount = mana / maxMana;*/
    }

    public void permaDamage(float spentAmount)
    {
        tempMaxmana -= spentAmount;
    }

    public void permaRestore(float amount)
    {
        tempMaxmana += amount;
    }

    public void Heal(float recoverAmount)
    {
        mana += recoverAmount;
        /*if (mana > maxMana)
        {
            mana = maxMana;
        }
        manaBar.fillAmount = mana / maxMana;*/
    }
}
