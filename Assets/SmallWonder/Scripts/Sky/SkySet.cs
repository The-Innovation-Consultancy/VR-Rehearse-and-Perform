using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySet : MonoBehaviour
{
    public Material sky;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = sky;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
