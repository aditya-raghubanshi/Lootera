using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSelection : MonoBehaviour
{
    public void LoadRandomScene()
    {
        int index = Random.Range(1, 2);
        SceneManager.LoadScene(index);
        Debug.Log("Scene Loaded");
    }
}
