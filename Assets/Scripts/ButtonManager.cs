using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : SequenceManager
{
    [SerializeField]
    private KeyCode inputKey;

    [Header("Input Variables")]
    public GameObject nextButton;
    [SerializeField]
    protected bool isStartingButton;

    [SerializeField]
    protected GameObject startingButton;

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
            StartCoroutine(SoundManager.PlayClip(0, 1));

            switch (selected)
            {
                case 1:
                    {
                        if (isStartingButton)
                            nextButton.SetActive(true);
                        else
                        {
                            startingButton.GetComponent<ButtonManager>().nextButton = nextButton;
                            startingButton.SetActive(true);
                        }
                        break;
                    }
                case 2:
                    {
                        Sequence2();
                        break;
                    }
            }

            FindObjectOfType<KnifeControl>().MoveKnife(transform, false);
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
