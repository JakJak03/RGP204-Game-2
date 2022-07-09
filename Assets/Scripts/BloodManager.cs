using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bloodAnimPrefab;
    [SerializeField]
    private GameObject bloodSplatPrefab;

    public Transform[] missPos;


    [System.Serializable]
    public struct Finger
    {
        public Finger(Vector3 pos, Vector3 rot)
        {
            position = pos;
            rotation = rot;
        }

        [SerializeField]
        public Vector3 position;
        [SerializeField]
        public Vector3 rotation;
    }

    [SerializeField]
    private Finger thumb = new Finger(new Vector3(-2.9f, -2.7f, 3), new Vector3(0, 0, 60));
    //index
    [SerializeField]
    private Finger finger1 = new Finger(new Vector3(-1.6f, -0.3f, 3), new Vector3(0, 0, 40));
    [SerializeField]
    private Finger finger2 = new Finger(new Vector3(-0.1f, -0.1f, 3), new Vector3(0, 0, 28));
    [SerializeField]
    private Finger finger3 = new Finger(new Vector3(1.4f, -0.55f, 3), new Vector3(0, 0, 10));
    [SerializeField]
    private Finger finger4 = new Finger(new Vector3(2.75f, -1.3f, 3), new Vector3(0, 0, -10));

    Coroutine currentCountdown;
    private float countdown = 4.0f;

    //public void Blood_Instance5()
    //{
    //    InstantiateBlood(finger4.position, finger4.rotation);
    //}
    //
    //public void Blood_Instance4()
    //{
    //    InstantiateBlood(finger3.position, finger3.rotation);
    //}
    //
    //public void Blood_Instance3()
    //{
    //    InstantiateBlood(finger2.position, finger2.rotation);
    //}
    //
    ////index
    //public void Blood_Instance2()
    //{
    //    InstantiateBlood(finger1.position, finger1.rotation);
    //}
    //
    //public void Blood_Instance1()
    //{
    //    InstantiateBlood(thumb.position, thumb.rotation);
    //}

    public void InstantiateBlood(Vector3 position,Transform rotation)
    {
        GameObject blood = Instantiate(bloodAnimPrefab, position, rotation.rotation);
        GameObject bloodSplat = Instantiate(bloodSplatPrefab, position, rotation.rotation);

        bloodSplat.transform.position = new Vector3(position.x, position.y, position.z - 6);

        blood.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
        //destroy only the splatter and leave the blood
        currentCountdown = StartCoroutine(Countdown(bloodSplat));
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
        //Color bloodColour = blood.GetComponent<SpriteRenderer>().color;
        //for (float i = 255; i >= 0; i--)
        //{
        //    blood.GetComponent<SpriteRenderer>().color = new Color(bloodColour.r, bloodColour.g, bloodColour.b, i);
        //}
        Destroy(blood);
    }
}
