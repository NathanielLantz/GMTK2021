using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_MainMenu : MonoBehaviour
{
    public void NavigateScene(string level)
    {
        Debug.Log("Scene Transitioned");
        SceneManager.LoadScene(level);
    }

    public void QuitApplication ()
    {
        Debug.Log("Application Ended");
        Application.Quit();
    }
}
