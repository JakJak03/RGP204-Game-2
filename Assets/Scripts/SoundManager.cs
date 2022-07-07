using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private GameObject audioClipPrefab;

    public static IEnumerator PlayClip(ushort clipId, float clipVol, Vector3 clipTrans)
    {
        SoundManager currentManager = FindObjectOfType<SoundManager>();
        AudioSource source = Instantiate(currentManager.audioClipPrefab, clipTrans, Quaternion.identity).GetComponent<AudioSource>();
        source.clip = currentManager.audioClips[clipId];
        source.volume = clipVol;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        Destroy(source.gameObject);
    }
}
