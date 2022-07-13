using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class VideotoAudio : MonoBehaviour
{
    void Awake()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        var samplesLength = AudioSettings.outputSampleRate;

        audioSource.clip = AudioClip.Create("", samplesLength, 2, AudioSettings.outputSampleRate, true, null);
        audioSource.loop = false;
        audioSource.Play();
    }
}