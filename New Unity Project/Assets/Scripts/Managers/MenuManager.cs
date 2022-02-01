using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Kenneth Tang
public class MenuManager : MonoBehaviour
{
    // Start new game
    public void OnClickNewGame()
    {
        GameStateManager.NewGame();
    }

    // Quit Game
    public void OnClickQuitGame()
    {
        Application.Quit();
    }
}
