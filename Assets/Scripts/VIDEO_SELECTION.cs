using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VRUiKits.Utils;

public class VIDEO_SELECTION : MonoBehaviour
{
    public void Start()
    {
        // Subscribing to OnCardClick method
        GetComponent<CardItem>().OnCardClicked += videochange;
       
     
    }

    public void videochange(Card card)
    {
        StaticVariables.passed_clip = card.videoClip;
        Debug.Log(StaticVariables.passed_clip);
    }
}

