using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody myBody;
    private float lifetimer = 2f;
    private float timer;
    private bool hitSomething = false;

    // Start is called before the first frame update
    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitSomething = true;
        stick();

    }
    private void stick()
    {
        myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
