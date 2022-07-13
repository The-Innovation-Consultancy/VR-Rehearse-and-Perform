using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hand_Menu : MonoBehaviour
{
    public GameObject VideoCanvas;
    public GameObject Settings;
    public GameObject OnOff;
    public GameObject Reverb;
    public GameObject VideoReverb;

    public void OpenCanvas()
    {
        if (VideoCanvas != null)
        { bool isActive = VideoCanvas.activeSelf;

            VideoCanvas.SetActive(!isActive);
        }
    }
    public void HomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Settings_Open()
    {
        if (Settings != null)
        {
            bool isActive = Settings.activeSelf;

            Settings.SetActive(!isActive);
        }
    }

    public void Reverb_on()
    {
        if (Reverb != null)
        {
            bool isActive = Reverb.GetComponent<MicrophoneBinauralFilter>().enabled;
            Reverb.GetComponent<MicrophoneBinauralFilter>().enabled = !isActive;
        }
    }

    public void Mic_on()
    {
        if (VideoReverb != null)
        {
            bool isActive = VideoReverb.GetComponent<AudioSourceBinauralFilter>().enabled;
            VideoReverb.GetComponent<AudioSourceBinauralFilter>().enabled = !isActive;
        }
    }

    public void Objects_On()
    {
        if (OnOff != null)
        {
            bool isActive = OnOff.activeSelf;

            OnOff.SetActive(!isActive);
        }
    }


    public void Exit()
    {
        Application.Quit();
    }
}