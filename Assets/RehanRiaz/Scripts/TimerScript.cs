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
        PlayerPrefs.SetFloat("highscore", 0);
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
        if (timeRemaining > PlayerPrefs.GetFloat("highscore"))
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
