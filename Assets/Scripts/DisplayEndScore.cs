using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEndScore : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = FindObjectOfType<ScoreManager>().scoreText.text;
    }
}
