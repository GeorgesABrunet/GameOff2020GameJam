using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private float PlayTime = 4f;
    public static bool GoTime = false;
    public void PlayLoad()
    {
        GoTime = true;
        Invoke("Play", PlayTime);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("You dun quit the game :(");
        Application.Quit();
    }
}
