using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    static int count = 1;
    int[] sequences = { 1, 2 };
    public static int selected;

    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject button2;
    [SerializeField]
    private GameObject button3;
    [SerializeField]
    private GameObject button4;
    [SerializeField]
    private GameObject button5;
    [SerializeField]
    private GameObject button6;

    private void OnEnable()
    {
        selected = Random.Range(1, sequences.Length + 1);
    }
    
    public void Sequence2()
    {
        switch (count)
        {
            case 0:
                {
                    button1.SetActive(true);
                    count++;
                    break;
                }
            case 1:
                {
                    button6.SetActive(true);
                    count++;
                    break;
                }
            case 2:
                {
                    button2.SetActive(true);
                    count++;
                    break;
                }
            case 3:
                {
                    button5.SetActive(true);
                    count++;
                    break;
                }
            case 4:
                {
                    button3.SetActive(true);
                    count++;
                    break;
                }
            case 5:
                {
                    button4.SetActive(true);
                    count = 0;
                    break;
                }
        }
    }
}
