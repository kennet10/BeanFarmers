using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;

// Made by Kenneth Tang
public class CameraManager : MonoBehaviour
{
    private int numPlayers;
    private GameObject[] players;
    [SerializeField] private CinemachineTargetGroup targetGroup;

    // Sets the proper players active and assigns them to the targetGroup of the camera
    public void Start()
    {
        numPlayers = GameStateManager.GetNumPlayers();
        players = GameObject.FindGameObjectsWithTag("Player");

        if(numPlayers == 1)
        {
            players[0].gameObject.tag = "Untagged";
        }
        else if(numPlayers == 2)
        {
            targetGroup.AddMember(players[0].transform, 1, 1);
            NavMeshAgent nav = players[0].GetComponent<NavMeshAgent>();
            PlayerAI aiScript = players[0].GetComponent<PlayerAI>();
            nav.enabled = false;
            aiScript.enabled = false;
        }
    }
}
