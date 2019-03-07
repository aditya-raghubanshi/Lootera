using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    MeshCollider mesh;
    public float damage = 10f;
    Dungeon_Monster_Controller[] skeletons;
    void OnTriggerEnter(Collider col)
    {
        AttackButton button = FindObjectOfType<AttackButton>();
        //skeleton = FindObjectOfType<Dungeon_Monster_Controller>();
        skeletons = col.gameObject.GetComponents<Dungeon_Monster_Controller>();
        if (skeletons != null)
        {
            if (button.pressed == true)
            {
                foreach(Dungeon_Monster_Controller skeleton in skeletons)
                {
                    skeleton.Damage(10);
                }
            }
        }
    }
}
