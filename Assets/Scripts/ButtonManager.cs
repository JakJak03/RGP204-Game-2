using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private KeyCode inputKey;

    [SerializeField]
    private bool isStartingButton;

    Event currentEvent;

    private void Start()
    {
        if (!isStartingButton)
            gameObject.SetActive(false);
    }
    private void OnGUI()
    {
        currentEvent = Event.current;
        if (currentEvent.type == EventType.KeyDown)
            Clicked();
    }
    private void Clicked()
    {
        if (currentEvent.keyCode == inputKey)
        {
            nextButton.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (currentEvent.keyCode.ToString().Length == 1 && char.IsLetter(currentEvent.keyCode.ToString()[0]))
            FindObjectOfType<ScoreManager>().GetStabbed();
    }
}
