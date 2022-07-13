using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using Microsoft.MixedReality.Toolkit.UI;


#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class MicrophoneBinauralFilter : MonoBehaviour 
{
    public bool microphoneEnabled = false;
    public bool playTestNoise = false;

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
    [Range(0, 3)]
    public  int   reverbSize;

    GameObject dialog = null;
    
    private NativeAudioIO audioIO = null;
    private BinauralProcessor binauralProcessor = null;

    public void Awake()
    {
        Debug.Log("Awake");

        if (audioIO != null || binauralProcessor != null) return;

        int numFrames  = 512;
        int sampleRate = 44100;
        int numBuffers = 128;

        AudioSettings.GetDSPBufferSize(out numFrames, out numBuffers);
        audioIO = new NativeAudioIO (sampleRate, numFrames);

        numFrames  = audioIO.GetBlockSize();
        sampleRate = audioIO.GetSampleRate();
        Debug.Log("Num Frames: " + numFrames);
        Debug.Log("Sample Rate: " + sampleRate);

        audioIO.SetBlockSize(512);
       
        numFrames  = audioIO.GetBlockSize();
        Debug.Log("Num Frames: " + numFrames);
		
        binauralProcessor = new BinauralProcessor (sampleRate, numFrames);
        binauralProcessor.SetReverbSize (reverbSize);

        audioIO.SetProcessor (binauralProcessor._context);
    }

    void OnApplicationQuit()
    {
        if (audioIO == null || binauralProcessor == null) return;

        audioIO.Dispose();
        audioIO = null;

        binauralProcessor = null;
    }

    void OnDisable()
    {
        if (audioIO != null)
        {
            Debug.Log("On Disable");
            audioIO.EnableProcessing (false);
        }
    }

    void OnEnable()
    {
        if (audioIO != null)
        {
            Debug.Log("On Enable");
            audioIO.EnableProcessing (true);

        }
    }

    public IEnumerator Start()
    {   
        #if PLATFORM_ANDROID
        while (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            if (dialog == null)
            {
                Permission.RequestUserPermission(Permission.Microphone);
                dialog = new GameObject();
            }
            yield return null;
        }
        Destroy(dialog);
        #endif

        Debug.Log("Set channels 2 | 2");
        audioIO.SetupAudioDevice (2, 2);

        yield return 1;
    }

    // Update is called once per frame
	void Update() 
    {
        if (_azimuth != azimuth)
        {
            binauralProcessor.SetAzimuth (azimuth);
            _azimuth = azimuth;
        }

        if (_distance != distance)
        {
            binauralProcessor.SetDistance (distance);
            _distance = distance;
        }

        if (_elevation != elevation)
        {
            binauralProcessor.SetElevation (elevation);
            _elevation = elevation;
        }

        if (_reverbSize != reverbSize)
        {
            if (binauralProcessor.SetReverbSize (reverbSize))
                _reverbSize = reverbSize;
        }

        audioIO.EnableTestNoise (playTestNoise);

        audioIO.EnableMicrophone (microphoneEnabled);
	}

    public void SetReverbSize(SliderEventData eventData)
    {
        int Size = (int)(eventData.NewValue * 2.49f);
        Debug.Log("reverbSize" + Size);
        reverbSize = Size;
    }
}