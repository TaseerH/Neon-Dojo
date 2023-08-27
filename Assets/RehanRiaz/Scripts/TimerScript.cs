using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeRunning = true;
    public TMP_Text timeText;
    public TMP_Text highScoreText;
    private bool highScoreReached=false;
    // Start is called before the first frame update
    void Start()
    {
        timeRunning = true;
        // PlayerPrefs.SetFloat("highscore", 0);
        float hsminutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("highscore", 0) / 60);
        float hsseconds = Mathf.FloorToInt(PlayerPrefs.GetFloat("highscore", 0) % 60);
        highScoreText.text = string.Format("{0:00} : {1:00}", hsminutes, hsseconds);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                displayTime(timeRemaining);
                updateHighScore();
            }
        }
    }
    void displayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes,seconds);
        if (highScoreReached)
        {

            highScoreText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }

    }

    

    void updateHighScore()
    {
        if (timeRemaining > PlayerPrefs.GetFloat("highscore",0))
        {
            PlayerPrefs.SetFloat("highscore", timeRemaining);
            highScoreReached = true;
        }
        else
        {
            highScoreReached = false;
        }
    }
}
