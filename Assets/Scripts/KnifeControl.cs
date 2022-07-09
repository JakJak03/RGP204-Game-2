using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
    public void MoveKnife(Transform stabPoint, bool didHit)
    {
        transform.position = stabPoint.position;
        if(didHit)
        {
            FindObjectOfType<BloodManager>().InstantiateBlood(new Vector3 (stabPoint.position.x, stabPoint.position.y, 5f), stabPoint);
            StartCoroutine(SoundManager.PlayClip(1, 1));
        }
    }
}
