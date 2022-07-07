using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Debug.Log("Game has QUIT");
        Application.Quit();
    }

    public void ReplayGame()
    {
        //Not sure if this works yet ??
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, 0);
    }
}
