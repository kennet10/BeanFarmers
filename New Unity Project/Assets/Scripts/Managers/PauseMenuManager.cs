using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    private static bool gamePaused;

    private void Start()
    {
        gamePaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused == false)
            {
                PauseGame();
            }
            if(gamePaused == true)
            {
                ResumeGame();
            }
        }
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
    }

    public static void ResumeGame()
    { 
        Time.timeScale = 1;
        gamePaused = false;
    }
}
