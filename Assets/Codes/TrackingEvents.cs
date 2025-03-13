using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackingEvents : MonoBehaviour
{
    public string[] imageNames;
    public GameObject[] prefabs;
    private AudioSource audioSource;
    public AudioClip[] audioClips;


    GameObject spawnedObj;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        ARTrackedImage aRTracked = GetComponent<ARTrackedImage>();
        int i = Array.IndexOf(imageNames, aRTracked.referenceImage.name);
        Instantiate(prefabs[i], transform);
        if (i >= 0 && i < audioClips.Length && audioClips[i] != null)
        {
            audioSource.clip = audioClips[i];
            audioSource.Play();
        }
    }
}