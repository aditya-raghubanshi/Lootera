using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelKeepers : MonoBehaviour
{
    // Start is called before the first frame update
    Dropdown dropdown;
    Level level;
    void Start()
    {
        level = FindObjectOfType<Level>();
        dropdown = GetComponent<Dropdown>();
       


    }
    private void Update()
    {
        level.SetLevel(dropdown.
        value + 1);
    }

}
