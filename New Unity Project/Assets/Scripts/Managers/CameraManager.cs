using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private int numPlayers;
    private GameObject[] players;
    [SerializeField] private CinemachineTargetGroup targetGroup;

    public void Start()
    {
        numPlayers = GameStateManager.GetNumPlayers();
        players = GameObject.FindGameObjectsWithTag("Player");

        if(numPlayers == 1)
        {
            players[0].SetActive(false);
        }
        else if(numPlayers == 2)
        {
            targetGroup.AddMember(players[0].transform, 1, 1);
        }
    }
}
