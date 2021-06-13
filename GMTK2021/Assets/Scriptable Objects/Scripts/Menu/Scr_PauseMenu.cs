using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    
    public static bool PausedState = false;


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausedState)
            {
                Resume();
            } 
            else
            {
                Paused();
            }
        }
    }

    void Resume ()
    {
        Debug.Log("Game UnPaused");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PausedState = false;
    }

    void Paused ()
    {
        Debug.Log("Game Paused");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.5f;
        PausedState = true;
    }
}
