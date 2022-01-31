using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Made by Kenneth Tang
public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;

    //States of the game
    enum GAMESTATE
    {
        TITLE,
        PLAYING,
        GAMEEND,
    }

    private static GAMESTATE m_State;

    private void Awake()
    {
        //Create the instance
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    //Start a new game
    public static void NewGame()
    {
        m_State = GAMESTATE.PLAYING;
        SceneManager.LoadScene(1);

        // Haley Vlahos
        ResourceManager.SetupResources();
    }

    //End the game
    public static void EndGame()
    {
        m_State = GAMESTATE.GAMEEND;
        SceneManager.LoadScene(2);
    }

    //QuitToTitle
    public static void QuitToTitle()
    {
        m_State = GAMESTATE.TITLE;
        SceneManager.LoadScene(0);
    }
}
