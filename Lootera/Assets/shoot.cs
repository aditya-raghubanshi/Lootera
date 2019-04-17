using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Camera cam;
    public Camera cam2;
    public Camera cam3;
    public GameObject Bow;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public Transform arrowSpawn2;
    public Transform arrowSpawn3;
    public GameObject body;
    public float shootForce = 20f;
    public int Drawed = 0;

    GameObject player;
    Animator animate;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
    public void arrowspawn()
    {
        if (Drawed == 0)
        {
            player = GameObject.Find("Player");
            animate = player.GetComponent<Animator>();
            animate.SetInteger("Arrow", 1);
            cam.transform.rotation = Bow.transform.rotation * Quaternion.Euler(270, 90, -90);
            cam2.transform.rotation = Bow.transform.rotation * Quaternion.Euler(295, 90, -90);
            cam3.transform.rotation = Bow.transform.rotation * Quaternion.Euler(245, 90, -90);
            Drawed = 1;
            StartCoroutine(ExecuteAfterTime(1f));
 
        }


    }
    IEnumerator ExecuteAfterTime(float sec)
    {
        yield return new WaitForSeconds(sec);
        GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        GameObject go1 = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        GameObject go2 = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        go.transform.rotation = cam.transform.rotation * Quaternion.Euler(270, 0, 0);
        go1.transform.rotation = cam2.transform.rotation * Quaternion.Euler(270, 0, 0);
        go2.transform.rotation = cam3.transform.rotation * Quaternion.Euler(270, 0, 0);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.velocity = cam.transform.forward * shootForce;
        Rigidbody rb1 = go1.GetComponent<Rigidbody>();
        rb1.velocity = cam2.transform.forward * shootForce;
        Rigidbody rb2 = go2.GetComponent<Rigidbody>();
        rb2.velocity = cam3.transform.forward * shootForce;
        animate.SetInteger("Arrow", 0);
        Drawed = 0;
        
    }
}
