using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    Gems gem;
    void Start()
    {
        gem = GetComponent<Gems>();
        gem.SetGems(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
