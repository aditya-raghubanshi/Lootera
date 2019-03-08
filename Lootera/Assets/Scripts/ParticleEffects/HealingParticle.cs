using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingParticle : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject aura;
    public AudioSource source;

    void Start()
    {
        player = GameObject.Find("Player");
        aura = player.transform.Find("HealingParticle").gameObject;
        aura.SetActive(false);
        source = GetComponent<AudioSource>();
        


    }

    public void HealingParticleOn()
    {
        aura.SetActive(true);
        Debug.Log("On Event triggered");
        source.Play();
    }

    public void HealingParticleOff()
    {
        Debug.Log("Off Event triggered");
        aura.SetActive(false);
    }
}
