using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Kenneth Tang
public class PauseMenuManager : MonoBehaviour
{
    public static bool gamePaused;
    [SerializeField] private Canvas pauseCanvas;

    private void Start()
    {
        gamePaused = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(gamePaused == false)
            {
                PauseGame();
                Debug.Log(gamePaused);
            }
            else if(gamePaused == true)
            {
                ResumeGame();
                Debug.Log(gamePaused);
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
        pauseCanvas.gameObject.SetActive(true);
    }

    public void ResumeGame()
    { 
        Time.timeScale = 1;
        gamePaused = false;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void QuitToTitle()
    {
        GameStateManager.QuitToTitle();
    }
}
