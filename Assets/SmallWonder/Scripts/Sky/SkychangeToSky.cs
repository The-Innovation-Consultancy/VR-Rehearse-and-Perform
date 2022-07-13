using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkychangeToSky : MonoBehaviour
{
    public Material sky;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skychange()
    {
        RenderSettings.skybox = sky;
    }
}
