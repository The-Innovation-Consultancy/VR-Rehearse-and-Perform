using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour
{

    public GameObject VideoPanel;
    public GameObject closedPanel1;
    public GameObject closedPanel2;
    public GameObject closedPanel3;
  

    public void RCM()
    {
        SceneManager.LoadScene(3);
    }

    public void RCM_musician()
    {
        SceneManager.LoadScene(4);
    }

    public void OpenPanel()
    {
        if (VideoPanel != null)
        { VideoPanel.SetActive(true);
           closedPanel2.SetActive(false);
           closedPanel3.SetActive(false);
           closedPanel1.SetActive(false);
        }
    }


}


