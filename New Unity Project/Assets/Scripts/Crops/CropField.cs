using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Made by Ben Hamilton
public class CropField : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI triggerText;
    [SerializeField] private int fieldNumber;
    [SerializeField] GameObject cropMenu;
    [SerializeField] Crop currentCrop;
    private int playerNum;
    private bool harvestable = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (currentCrop == null)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerMovement PM = collision.GetComponent<PlayerMovement>();

                if (PM.playerNum == 1)
                {
                    triggerText.text = "Press Space to plant!";
                    playerNum = 1;
                }
                if (PM.playerNum == 2)
                {
                    triggerText.text = "Press Enter to plant!";
                    playerNum = 2;
                }

                triggerText.gameObject.SetActive(true);
                //do a check if they have seed, if so, -1 seed, else provide error message
            }
        }
        
        else
        {
            if (!currentCrop.IsGrowing())
            {
                if (collision.gameObject.tag == "Player")
                {
                    PlayerMovement PM = collision.GetComponent<PlayerMovement>();

                    if (PM.playerNum == 1)
                    {
                        triggerText.text = "Press Space to harvest!";
                        playerNum = 1;
                    }
                    if (PM.playerNum == 2)
                    {
                        triggerText.text = "Press Enter to harvest!";
                        playerNum = 2;
                    }

                    triggerText.gameObject.SetActive(true);
                    harvestable = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerNum == 1)
        {
            if ((harvestable) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
            {
                //+1 crop
                currentCrop = null;
            }
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
                cropMenu.SetActive(true);
            }
        }
        else if (playerNum == 2)
        {
            if ((harvestable) && (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return)))
            {
                //+1 crop
                currentCrop = null;
            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return))
            {
                cropMenu.SetActive(true);
            }
        }
    }
}
