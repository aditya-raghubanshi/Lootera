using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackbuttonSprite : MonoBehaviour
{
    Button button;
    public Sprite DefaultImg;
    public Sprite Viking;
    public Sprite Dragonblade;
    public Sprite Bow;
    int ID;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        ID = AttackButton.weaponID;
        switch (ID)
        {
            case 36:
                button.GetComponent<Image>().sprite = Dragonblade;
                break;
            case 37:
                button.GetComponent<Image>().sprite = Viking;
                break;
            case 42:
                button.GetComponent<Image>().sprite = Bow;
                break;
            case 0:
                button.GetComponent<Image>().sprite = DefaultImg;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
