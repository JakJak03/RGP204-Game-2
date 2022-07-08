using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public AudioSource Ouch;
    public AudioSource Stab;
    public AudioSource Silly;

    public static ScoreManager instance;

    [SerializeField]
    private int scoreIncrease;

    [SerializeField]
    private int health;

    private int currentHealth;

    private int currentScore;
    private int highScore;

    [HideInInspector]
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }
    public void ResetGame()
    {
        currentScore = 0;
        currentHealth = health;
    }
    public void IncreaseScore(int multiplier)
    {
        currentScore += scoreIncrease * multiplier;
        PlayStab();
        scoreText.text = currentScore.ToString("0000");
       
    }

    public void GetStabbed()
    {
        currentHealth--;
        PlayOuch();
        print("You stabbed yourself");
        if (currentHealth <= 0)
            SceneManager.LoadScene("EndMenu");

    }

    public void PlayOuch()
    {
        //Change sound depending on scene
        Ouch.Play();
    }

    public void PlayStab()
    {
        Stab.Play();
    }
}
