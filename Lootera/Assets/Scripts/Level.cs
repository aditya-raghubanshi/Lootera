using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level: MonoBehaviour
{
    public static int level;


    public void SetLevel(int i)
    {
        level = i;
    }

    public int GetLevel()
    {
        return level;
    }

}
