using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Kenneth Tang
public class TItleMenuManager : MonoBehaviour
{
    public void OnClickNewGame()
    {
        GameStateManager.NewGame();
    }

    public void OnClickQuitGame()
    {
        Application.Quit();
    }
}
