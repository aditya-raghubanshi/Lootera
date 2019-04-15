using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBash : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject aura;
    public AudioSource source;
    public AudioClip groundBash;
    void Start()
    {
        player = GameObject.Find("Player");
        aura = player.transform.Find("ForceBlast").gameObject;
        aura.SetActive(false);
        source = GetComponent<AudioSource>();
        
    }

    public void GroundBashOn()
    {
        aura.SetActive(true);
        source.clip = groundBash;
        Debug.Log("On Event triggered");
        source.Play();
    }

    public void GroundBashOff()
    {
        Debug.Log("Off Event triggered");
        aura.SetActive(false);
    }
}
