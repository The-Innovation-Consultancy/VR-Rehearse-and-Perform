using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VRUiKits.Utils;

public class Videoselection : MonoBehaviour
{
    public VideoPlayer videoPlayer;
   
    public GameObject Canvas;
  

    void Start()
    {
        
        
        
        // Subscribing to OnCardClick method
        GetComponent<CardItem>().OnCardClicked += videochange;
    }


    public void videochange(Card card)
    {
        videoPlayer.clip = card.videoClip;
        videoPlayer.Play();
        

        Canvas.SetActive(false);
    }
}




