using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public void AUDIENCE()
    {
        SceneManager.LoadScene(5);
    }

    public void PERFORMER()
    {
        SceneManager.LoadScene(4);
    }

    public void Hall()
    {
        SceneManager.LoadScene(1);
    }

    public void Flat()
    {
        SceneManager.LoadScene(3);
    }

    public void NoMans()
    {
        SceneManager.LoadScene(2);
    }
}
