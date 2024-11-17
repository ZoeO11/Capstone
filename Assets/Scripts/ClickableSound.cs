using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSound : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.playOnAwake = false;
    }

    void OnMouseDown()
    {
        audioSource.Play();
    }
}
