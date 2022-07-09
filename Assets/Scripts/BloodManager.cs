using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bloodAnimPrefab;

    public struct Finger
    {
        public Finger(Vector3 pos, Vector3 rot)
        {
            position = pos;
            rotation = rot;
        }

        public Vector3 position;
        public Vector3 rotation;
    }

    [SerializeField]
    private Finger thumb;
    [SerializeField]
    private Finger finger1;
    [SerializeField]
    private Finger finger2;
    [SerializeField]
    private Finger finger3;
    [SerializeField]
    private Finger finger4 = new Finger(new Vector3(-2.9f, -2.7f, -2), new Vector3(0, 0, 65));

    Coroutine currentCountdown;
    private float countdown;

    public void Blood_Instance5()
    {
        GameObject blood = GameObject.Instantiate(bloodAnimPrefab);
        blood.transform.position = finger4.position;
        blood.transform.Rotate(finger4.rotation);
        currentCountdown = StartCoroutine(Countdown(blood));
    }

    public void Blood_Instance4()
    {
        GameObject blood = GameObject.Instantiate(bloodAnimPrefab);
        blood.transform.position = finger3Pos;
        blood.transform.Rotate(finger3Rot);
        currentCountdown = StartCoroutine(Countdown(blood));
    }

    public void Blood_Instance3()
    {
        GameObject blood = GameObject.Instantiate(bloodAnimPrefab);
        blood.transform.position = finger3Pos;
        blood.transform.Rotate(finger3Rot);
        currentCountdown = StartCoroutine(Countdown(blood));
    }

    public void Blood_Instance2()
    {
        GameObject blood = GameObject.Instantiate(bloodAnimPrefab);
        blood.transform.position = finger3Pos;
        blood.transform.Rotate(finger3Rot);
        currentCountdown = StartCoroutine(Countdown(blood));
    }

    public void Blood_Instance1()
    {
        GameObject blood = GameObject.Instantiate(bloodAnimPrefab);
        blood.transform.position = finger3Pos;
        blood.transform.Rotate(finger3Rot);
        currentCountdown = StartCoroutine(Countdown(blood));
    }

    private IEnumerator Countdown( GameObject blood )
    {
        float newCountdown = countdown;
        do
        {
            yield return new WaitForSeconds(0.1f);
            newCountdown -= 0.1f;
        } while (newCountdown > 0);
        Fade(blood);
        StopCoroutine(currentCountdown);
    }

    private void Fade(GameObject blood)
    {
        Color bloodColour = blood.GetComponent<SpriteRenderer>().color;
        for (float i = 255 * Time.deltaTime; i >= 0; i++)
            blood.GetComponent<SpriteRenderer>().color = new Color(bloodColour.r, bloodColour.g, bloodColour.b, i);
        Destroy(blood);
    }
}
