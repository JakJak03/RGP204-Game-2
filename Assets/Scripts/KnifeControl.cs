using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
    public Transform Buttons;
    //public enum ButtonLabels
    //{
    // A = 0,
    //}

    public List<Vector3> ButtonsList;

    void Start()
    {
        ButtonsList = new List<Vector3>();

        for (int i = 0; i < Buttons.childCount; i++)
        {
            ButtonsList.Add(Buttons.GetChild(i).transform.position);
        }
    }
    
    //A //S //D //F //G //H
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(ButtonsList[0].x, ButtonsList[0].y, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(ButtonsList[1].x, ButtonsList[1].y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(ButtonsList[2].x, ButtonsList[2].y, 0);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.position = new Vector3(ButtonsList[3].x, ButtonsList[3].y, 0);
        }
        if (Input.GetKey(KeyCode.G))
        {
            transform.position = new Vector3(ButtonsList[4].x, ButtonsList[4].y, 0);
        }
        if (Input.GetKey(KeyCode.H))
        {
            transform.position = new Vector3(ButtonsList[5].x, ButtonsList[5].y, 0);
        }
    }
}
