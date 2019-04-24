using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    Gems gems;
    int gem;
    public static float strength = 0f;
    public static float intelligence = 0f;
    public static float dexterity = 0f;
    public static float constitution = 0f;
    public static string playerName = "Player";
    void Start()
    {
        gem = gems.GetGems();

    }

    public string GetName()
    {
        return playerName;
    }

    public float GetStrength()
    {
        return strength;
    }

    public float GetDexterity()
    {
        return dexterity;
    }

    public float GetConstitution()
    {
        return constitution;
    } 

    public float GetIntelligence()
    {
        return intelligence;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetInt(float inte)
    {
        intelligence = inte;
    }

    public void SetStr(float str)
    {
        strength = str;
    }

    public void SetDex(float dex)
    {
        dexterity = dex;
    }

    public void SetCon(float con)
    {
        constitution = con;
    }
}
