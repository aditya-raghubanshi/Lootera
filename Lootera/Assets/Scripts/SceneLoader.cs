using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public int sceneIndex;

    public void LoadLevel(int sceneIndex)
    {
        sceneIndex = Random.Range(1, 5);
      //  SceneManager.LoadScene(sceneIndex);
        Debug.Log("Scene Loaded");
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01( (float) operation.progress / .9f);

            slider.value = progress;
     
            yield return null;
        }
    }
}
