using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<ScoreManager>().scoreText = GetComponent<TextMeshProUGUI>();
        FindObjectOfType<ScoreManager>().ResetGame();
    }
}
