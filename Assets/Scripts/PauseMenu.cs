using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    //public GameObject YouDiedUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        /*if (PlayerHealth.Lives <= 0)
        {
            YouDiedUI.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            YouDiedUI.SetActive(false);
        }*/
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturnMainMenu()
    {
        Debug.Log ("Quitting Game...");
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        Debug.Log("Here we go again...");
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(1);
    }
}
//nice