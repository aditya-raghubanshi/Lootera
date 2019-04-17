using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody myBody;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        stick();
        StartCoroutine(KillArrow(1f));
    }
    IEnumerator KillArrow(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
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
