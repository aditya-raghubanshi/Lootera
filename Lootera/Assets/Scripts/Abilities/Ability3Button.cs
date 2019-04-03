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
    public Sprite healingShout;
    public Sprite shieldBash;
    Button button;
    void Start()
    {
        slots = FindObjectOfType<AbilitySlots>();
        ability3 = slots.GetAbility3();
        button = GetComponent<Button>();
        Debug.Log(ability3);

        switch (ability3)
        {
            case 1:
                button.GetComponent<Image>().sprite = healingShout;
                break;
            case 2:
                button.GetComponent<Image>().sprite = shieldBash;
                break;
        }
        // Add more cases as we add new Abilities
    }
}
