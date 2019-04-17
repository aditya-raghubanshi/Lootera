using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger: MonoBehaviour
{
    public void changeToScene(int changeToScene)
    {
        SceneManager.LoadScene(changeToScene);
    }
}
