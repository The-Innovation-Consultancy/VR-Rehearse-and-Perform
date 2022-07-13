using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VRUiKits.Utils;

public class AudioSelection : MonoBehaviour
{
    //public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public GameObject Canvas;


    void Start()
    {



        // Subscribing to OnCardClick method
        GetComponent<CardItem>().OnCardClicked += videochange;
    }


    public void videochange(Card card)
    {
        //videoPlayer.clip = card.videoClip;
        //videoPlayer.Play();
        audioSource.clip = card.audioClip;
        audioSource.Play();

        Canvas.SetActive(false);
    }
}





