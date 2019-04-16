using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject Bow;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;
    public int count = 0;

    GameObject player;
    Animator animate;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
    public void arrowspawn()
    {
        if (count == 0)
        {
            player = GameObject.Find("Player");
            Bow = GameObject.Find("BOW");
            animate = player.GetComponent<Animator>();
            animate.SetInteger("Arrow", 1);
            StartCoroutine(ExecuteAfterTime(1f));
            count = 1;

        }


    }
    IEnumerator ExecuteAfterTime(float sec)
    {
        yield return new WaitForSeconds(sec);
        
        GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        cam.transform.rotation = Bow.transform.rotation* Quaternion.Euler(90,90,-90);
        go.transform.rotation = cam.transform.rotation * Quaternion.Euler(270,0,0) ;
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.velocity = cam.transform.forward * shootForce;
        animate.SetInteger("Arrow", 0);
        count = 0;
        
    }
}
