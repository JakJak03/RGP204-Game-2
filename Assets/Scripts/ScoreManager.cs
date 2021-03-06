using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    [HideInInspector] private bool shouldPlaySounds;



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
        int randNum = Random.Range(0, FindObjectOfType<BloodManager>().missPos.Length);
        FindObjectOfType<KnifeControl>().MoveKnife(FindObjectOfType<BloodManager>().missPos[randNum].transform, true);
        currentHealth--;
        if (currentHealth <= 0)
            SceneManager.LoadScene("EndMenu");
    }
}
