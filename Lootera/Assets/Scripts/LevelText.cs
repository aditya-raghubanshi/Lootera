using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text1;
   Level level;
    void Start()
    {
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(gems.GetGems());
        text1.text = level.GetLevel().ToString("0");
    }
}