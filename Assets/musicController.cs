
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class musicController : MonoBehaviour
{
    public AudioClip menuLoop;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {

            audioSource.clip = menuLoop;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
}