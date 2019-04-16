using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Animation_Script : MonoBehaviour
{
    public bool doDamage = false;

    public void setDoDamageTrue()
    {
        doDamage = true;
    }

    public void setDoDamageFalse()
    {
        doDamage = false;
    }

   public bool getDoDamage() => doDamage;


}
