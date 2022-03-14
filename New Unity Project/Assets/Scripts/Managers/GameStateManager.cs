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

    enum NUMPLAYERS
    {
        ONE = 1,
        TWO = 2
    }

    private static GAMESTATE m_State;
    private static NUMPLAYERS m_Num_Players;

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
            AudioSource aud = GetComponent<AudioSource>();
            Destroy(aud);
            Destroy(this);
        }
        m_Num_Players = NUMPLAYERS.ONE;
    }

    public static int GetNumPlayers()
    {
        return (int)(m_Num_Players);
    }

    //Start a new game
    public static void NewGame1P()
    {
        m_State = GAMESTATE.PLAYING;
        m_Num_Players = NUMPLAYERS.ONE;
        SceneManager.LoadScene(1);

    }

    public static void NewGame2P()
    {
        m_State = GAMESTATE.PLAYING;
        m_Num_Players = NUMPLAYERS.TWO;
        SceneManager.LoadScene(1);

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
