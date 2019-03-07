using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlots : MonoBehaviour
{
    public static int ability1;
    public static int ability2;
    public static int ability3;

    public void SetAbility1(int i)
    {
        ability1 = i;
    }

    public void SetAbility2(int i)
    {
        ability3 = i;
    }

    public void SetAbility3(int i)
    {
        ability3 = i;
    }

    public int GetAbility1()
    {
        return ability1;
    }

    public int GetAbility2()
    {
        return ability2;
    }

    public int GetAbility3()
    {
        return ability3;
    }




}
