using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gems : MonoBehaviour
{
    public static int gems;


    public void SetGems(int i)
    {
        gems = i;
    }

    public int GetGems()
    {
        return gems;
    }

}
