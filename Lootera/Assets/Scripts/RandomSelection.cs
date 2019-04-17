using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSelection : MonoBehaviour
{
    public void LoadRandomScene()
    {
        int index = Random.Range(1, 2);
        SceneManager.LoadScene(1);
        Debug.Log("Scene Loaded");
    }
}
