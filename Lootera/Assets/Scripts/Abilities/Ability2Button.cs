﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability2Button : MonoBehaviour
{
    // Start is called before the first frame update
    AbilitySlots slots;
    int ability2;
    public Sprite healingShout;
    public Sprite defaultImage;
    public Sprite shieldBash;
    public Sprite magicCircle;
    public Sprite roll;
    Button button;
    void Start()
    {
        slots = FindObjectOfType<AbilitySlots>();
        
        button = GetComponent<Button>();
    }
    void Update()
    {

        //Debug.Log("ability2:" + ability2);
        ability2 = slots.GetAbility2();

        switch (ability2)
        {

            case 0:
                button.GetComponent<Image>().sprite = defaultImage;
                break;
            case 38:
                button.GetComponent<Image>().sprite = healingShout;
                break;
            case 41:
                button.GetComponent<Image>().sprite = shieldBash;
                break;
            case 39:
                button.GetComponent<Image>().sprite = roll;
                break;
            case 40:
                button.GetComponent<Image>().sprite = magicCircle;
                break;
            case 45:
                button.GetComponent<Image>().sprite = healingShout;
                break;
            case 48:
                button.GetComponent<Image>().sprite = shieldBash;
                break;
            case 46:
                button.GetComponent<Image>().sprite = roll;
                break;
            case 47:
                button.GetComponent<Image>().sprite = magicCircle;
                break;
            case 52:
                button.GetComponent<Image>().sprite = healingShout;
                break;
            case 55:
                button.GetComponent<Image>().sprite = shieldBash;
                break;
            case 53:
                button.GetComponent<Image>().sprite = roll;
                break;
            case 54:
                button.GetComponent<Image>().sprite = magicCircle;
                break;
        }
        // Add more cases as we add new Abilities
    }
}
