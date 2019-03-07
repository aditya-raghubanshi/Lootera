using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability1Button : MonoBehaviour
{
    // Start is called before the first frame update
    AbilitySlots slots;
    int ability1;
    public Sprite healingShout;
    Button button;
    void Start()
    {
        slots = FindObjectOfType<AbilitySlots>();
        ability1 = slots.GetAbility1();
        button = GetComponent<Button>();


        switch (ability1)
        {
            case 1:
                button.GetComponent<Image>().sprite = healingShout;
                break;
        }
    }

    
}
