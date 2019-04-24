using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float damage = 50f;
    Dungeon_Monster_Controller[] skeletons;
    Minotaur_Controller[] minotaurs;
    void OnTriggerEnter(Collider col)
    {
        AttackButton button = FindObjectOfType<AttackButton>();
        //skeleton = FindObjectOfType<Dungeon_Monster_Controller>();
        skeletons = col.gameObject.GetComponents<Dungeon_Monster_Controller>();
        minotaurs = col.gameObject.GetComponents<Minotaur_Controller>();

        if (skeletons != null)
        {
            if (button.pressed == true)
            {
                foreach (Dungeon_Monster_Controller skeleton in skeletons)
                {
                    skeleton.Damage(button.GetDamage());
                    Debug.Log(button.GetDamage());
                }
            }
        }
        if (minotaurs != null)
        {
            if (button.pressed == true)
            {
                foreach (Minotaur_Controller minotaur in minotaurs)
                {   
                        minotaur.Damage(button.GetDamage());
                        Debug.Log(button.GetDamage());

                }
            }
        }
    }
}
