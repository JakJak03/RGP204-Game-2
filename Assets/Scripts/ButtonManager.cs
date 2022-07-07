using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("Input Variables")]
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private KeyCode inputKey;
    [SerializeField]
    private bool isStartingButton;

    [Header("Score Variables")]
    [SerializeField]
    private float countdown;
    private int scoreMultiplier;

    Event currentEvent;
    private ScoreManager scoreManager;
    Coroutine currentCountdown;

    private void OnEnable()
    {
        currentCountdown = StartCoroutine(Countdown());
    }

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (!isStartingButton)
        {
            StopCoroutine(currentCountdown);
            gameObject.SetActive(false);
        }
    }
    private void OnGUI()
    {
        currentEvent = Event.current;
        if (currentEvent.type == EventType.KeyDown)
            ButtonPushed();
    }
    private void ButtonPushed()
    {
        if (currentEvent.keyCode == inputKey)
        {
            StopCoroutine(currentCountdown);
            scoreManager.IncreaseScore(scoreMultiplier);
            nextButton.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (currentEvent.keyCode.ToString().Length == 1 && char.IsLetter(currentEvent.keyCode.ToString()[0]))
            scoreManager.GetStabbed();
    }

    private IEnumerator Countdown()
    {
        float currentCountdown = countdown;
        scoreMultiplier = 10;
        do
        {
            yield return new WaitForSeconds(0.1f);
            currentCountdown -= 0.1f;
            if(scoreMultiplier > 1)
                scoreMultiplier--;

        } while (currentCountdown > 0);
        scoreManager.GetStabbed();
        nextButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
