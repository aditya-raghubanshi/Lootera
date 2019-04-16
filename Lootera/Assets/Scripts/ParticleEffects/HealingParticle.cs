using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingParticle : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject aura;
    public AudioSource source;
    public AudioClip healingSound;

    void Start()
    {
        player = GameObject.Find("Player");
        aura = player.transform.Find("HealingParticle").gameObject;
        aura.SetActive(false);
        source = GetComponent<AudioSource>();
        
        


    }

    public void HealingParticleOn()
    {
        source.clip = healingSound;
        aura.SetActive(true);
        source.Play();
    }

    public void HealingParticleOff()
    {
        
        aura.SetActive(false);
    }
}
