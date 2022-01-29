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
    [SerializeField] CropSO currentCrop;
    private int playerNum;

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
                //do a check if they have seed, -> -1 seed
            }
        }
            //if there's a plant here
            //if its grown
            //press {} to harvest
            //+1 crop
            //set current crop to null
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
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
                cropMenu.SetActive(true);
            }
        }
        else if (playerNum == 2)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return))
            {
                cropMenu.SetActive(true);
            }
        }
    }
}
