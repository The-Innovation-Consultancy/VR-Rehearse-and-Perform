using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;


[RequireComponent (typeof (AudioSource))]
public class AudioSourceBinauralFilter : MonoBehaviour 
{
    private float  _azimuth = -500;
    [Range(-180, 180)]
    public float azimuth    = 0.0f;

    private float _distance  = 0.1f;
    [Range(0.01f, 20)]
    public float distance   = 0.1f;

    private float _elevation = 0.0f;
    [Range(-90, 90)]
    public float elevation  = 0.0f;
    
    private int  _reverbSize = -1;
    [Range(0, 2)]
    public  int   reverbSize;

    private BinauralProcessor context = null;

    public void Awake()
    {
        int numFrames = 512;
        int numBuffers = 256;
        AudioSettings.GetDSPBufferSize (out numFrames, out numBuffers);
        Debug.Log("Buffer size: " + numFrames);
        int sampleRate = 44100;
       
        context = new BinauralProcessor (sampleRate, numFrames);
        context.SetReverbSize (reverbSize);
    }

    // Update is called once per frame
	public void Update() 
    {
        if (_azimuth != azimuth)
        {
            context.SetAzimuth (azimuth);
            _azimuth = azimuth;
        }

        if (_distance != distance)
        {
            context.SetDistance (distance);
            _distance = distance;
        }

        if (_elevation != elevation)
        {
            context.SetElevation (elevation);
            _elevation = elevation;
        }

        if (_reverbSize != reverbSize)
        {
            if (context.SetReverbSize (reverbSize))
                _reverbSize = reverbSize;
        }
	}

    private void OnAudioFilterRead(float[] buffer, int numChannels) 
    {
        context.ProcessAudio (buffer, numChannels);
    }

    public void SetReverbSize(SliderEventData eventData)
    {
        int Size = (int)(eventData.NewValue *2.49f);
        Debug.Log("reverbSize" + Size);
        reverbSize = Size;
    }
}