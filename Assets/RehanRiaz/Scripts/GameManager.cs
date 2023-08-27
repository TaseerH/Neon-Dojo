using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu, GameOverMenu, hig;
    public TMP_Text highscoreText;
    public GameObject highscorePage, mainmenuPage;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        highscoreText.text ="Highest Score/n" + PlayerPrefs.GetFloat("highscore", 0).ToString();

    }

    // Update is called once per frame
   

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void highScorePage()
    {
        mainmenuPage.SetActive(false);
        highscorePage.SetActive(true);
        

    }

    public void MainmenuPage()
    {
        highscorePage.SetActive(false);
        mainmenuPage.SetActive(true);
    }




}
