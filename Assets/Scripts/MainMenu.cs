using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameA ()
    {
        SceneManager.LoadScene("Buttons");
    }

    public void PlayGameB ()
    {
        SceneManager.LoadScene("Buttons2");
    }

    public void PlayGameC()
    {
        SceneManager.LoadScene("Buttons3");
    }

    public void QuitGame()
    {
        Debug.Log("Game has QUIT");
        Application.Quit();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
