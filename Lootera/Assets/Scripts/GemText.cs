using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text1;
    Gems gems;
    void Start()
    {
        gems = FindObjectOfType<Gems>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(gems.GetGems());
        text1.text = gems.GetGems().ToString("0");
    }
}
