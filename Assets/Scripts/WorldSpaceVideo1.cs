using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using Microsoft.MixedReality.Toolkit.UI;

public class WorldSpaceVideo1 : MonoBehaviour
{
   
    public VideoPlayer videoPlayer;
    
    public AudioSource audioSource;
    // Start is called before the first frame update

    public void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip = StaticVariables.passed_clip;
        videoPlayer.Play();


        //audioSource= GetComponent<AudioSource>();
       // audioSource.clip = StaticVariables.passed_audio;
        //audioSource.Play();


    }

    private void Start()
    {

        videoPlayer.clip = StaticVariables.passed_clip;
        videoPlayer.Play();

        //added
        //audioSource.clip = StaticVariables.passed_audio;
        //audioSource.Play();

    }

    public void SetClip()
    {

    }
   
    public void Pause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();

        }

        //added

       // if (audioSource.isPlaying)
       // {
          //  audioSource.Pause();

       // }
    }
   public void Play()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
           
        }

        //added
       // if (!audioSource.isPlaying)
       // {
           // audioSource.Play();

       // }
    }

    public void SetDirectAudioVolume(SliderEventData eventData)
    {
       audioSource.volume = eventData.NewValue;
    }



}
