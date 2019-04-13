using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability1Button : MonoBehaviour
{
    // Start is called before the first frame update
    AbilitySlots slots;
    int ability1;
    public Sprite defaultImage;
    public Sprite healingShout;
    public Sprite shieldBash;
    public Sprite magicCircle;
    public Sprite roll;
    Button button;
    void Start()
    {
        slots = FindObjectOfType<AbilitySlots>();
        ability1 = slots.GetAbility1();
        button = GetComponent<Button>();
        Debug.Log(ability1);

        switch (ability1)
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
