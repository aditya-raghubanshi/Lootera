using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer = 300;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    GameObject gameOver;

    void Start()
    {
        timer = mainTimer;
        gameOver = GameObject.Find("Game Over 2");
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            GameOver();
        }
    }

    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }

    void GameOver()
    {
        animate.SetFloat("dead", 1f);
        mvmnt.canMove = 0;
        StartCoroutine(DelayedDeath(2));
    }

    public float getTimer()
    {
        return timer;
    }

    public float getMaxTimer()
    {
        return mainTimer;
    }

    IEnumerator DelayedDeath(int time)
    {
        yield return new WaitForSeconds(time);
        
        gameOver.SetActive(true);
    }
}
