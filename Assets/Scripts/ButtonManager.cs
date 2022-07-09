using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("Input Variables")]
    public GameObject nextButton;
    [SerializeField]
    private KeyCode inputKey;
    [SerializeField]
    private bool isStartingButton;

    [SerializeField]
    private GameObject startingButton;

    [Header("Score Variables")]
    [SerializeField]
    private float countdown;
    private int scoreMultiplier;

    Event currentEvent;
    private ScoreManager scoreManager;
    private BloodManager bloodManager;
    Coroutine currentCountdown;

    private void OnEnable()
    {
        currentCountdown = StartCoroutine(Countdown());

    }

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        bloodManager = FindObjectOfType<BloodManager>();
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
            if (isStartingButton)
                nextButton.SetActive(true);
            else
            {
                startingButton.GetComponent<ButtonManager>().nextButton = nextButton;
                startingButton.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        else if (currentEvent.keyCode.ToString().Length == 1 && char.IsLetter(currentEvent.keyCode.ToString()[0]))
        {
            scoreManager.GetStabbed();
            switch(inputKey)
            {
                case KeyCode.A:
                    {
                        bloodManager.Blood_Instance5();
                        break;
                    }
                case KeyCode.S:
                    {
                        break;
                    }
                case KeyCode.D:
                    {
                        break;
                    }
                case KeyCode.F:
                        {
                            break;
                        }
                case KeyCode.G:
                        {
                            break;
                        }
                case KeyCode.H:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
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
