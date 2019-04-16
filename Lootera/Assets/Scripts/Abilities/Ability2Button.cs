using System.Collections;
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
        ability2 = slots.GetAbility2();
        button = GetComponent<Button>();
        Debug.Log(ability2);

        switch (ability2)
        {
            case 0:
                button.GetComponent<Image>().sprite = defaultImage;
                break;
            case 1:
                button.GetComponent<Image>().sprite = healingShout;
                break;
            case 2:
                button.GetComponent<Image>().sprite = shieldBash;
                break;
            case 3:
                button.GetComponent<Image>().sprite = roll;
                break;
            case 4:
                button.GetComponent<Image>().sprite = magicCircle;
                break;
        }
        // Add more cases as we add new Abilities
    }
}
