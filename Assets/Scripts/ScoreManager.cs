using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
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
        scoreText.text = currentScore.ToString("0000");
    }

    public void GetStabbed()
    {
        health--;
        print("You stabbed yourself");
        //if(health <= 0)
            //Die
    }
}
