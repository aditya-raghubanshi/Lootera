using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody myBody;
    private float lifetimer = 20f;
    private float timer;
    private bool hitSomething = false;
    Dungeon_Monster_Controller[] skeletons;

    // Start is called before the first frame update
    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
       // transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifetimer)
        {
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "DungeonSkeleton_demo"){
            stick();    
            Debug.Log("Not Skeleton");
        }
        else{
            stick();
            Debug.Log(" Skeleton");
        }

    }
    private void stick()
    {
        myBody.constraints = RigidbodyConstraints.FreezeAll;
        //hitSomething = false;
    }
    void OnTriggerEnter(Collider col)
    {
        skeletons = col.gameObject.GetComponents<Dungeon_Monster_Controller>();
        if (skeletons != null)
        {
                foreach (Dungeon_Monster_Controller skeleton in skeletons)
                {
                    skeleton.Damage(20);
                }
            
        }
    }
}
