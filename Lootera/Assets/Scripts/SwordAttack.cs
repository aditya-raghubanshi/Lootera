using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    MeshCollider mesh;
    public float damage = 10f;
    Dungeon_Monster_Controller skeleton;
    void OnTriggerEnter(Collider col)
    {
        AttackButton button = FindObjectOfType<AttackButton>();
        //skeleton = FindObjectOfType<Dungeon_Monster_Controller>();
        skeleton = col.gameObject.GetComponent<Dungeon_Monster_Controller>();
        if(button.pressed == true)
        {
            skeleton.Damage(damage);
        }
        
    }
}
