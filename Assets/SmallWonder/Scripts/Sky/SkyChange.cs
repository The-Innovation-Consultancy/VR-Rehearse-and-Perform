using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyChange : MonoBehaviour
{
    public Material skyboxDay;

    public Material skyboxDefault;

    public void Start()
    {
        RenderSettings.skybox = skyboxDefault;
    }

    public void SkyboxChange()
    {

        RenderSettings.skybox = skyboxDay;
    }
    
}
