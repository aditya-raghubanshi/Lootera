using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability3Button : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    AbilitySlots slots;
    int ability3;
    public Sprite defaultImage;
    public Sprite healingShout;
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
        ability3 = slots.GetAbility3();
        //Debug.Log("ability3:" + ability3);

        switch (ability3)
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
            case 56:
                button.GetComponent<Image>().sprite = roll;
                break;
            case 57:
                button.GetComponent<Image>().sprite = magicCircle;
                break;
        }
        // Add more cases as we add new Abilities
    }
}
