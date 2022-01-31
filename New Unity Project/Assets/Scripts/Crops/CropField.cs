using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Made by Ben Hamilton and Haley Vlahos
public class CropField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI triggerText;
    [SerializeField] private int fieldNumber;
    [SerializeField] private GameObject cropMenu;
    [SerializeField] private CropCoroutine currentCrop;
    [SerializeField] private CropManager CM;
    private int playerNum;
    private bool harvestable = false;

    public void setCurrentCrop(CropCoroutine cc)
    {
        currentCrop = cc;
    }

    // Checks if there is a crop currently planted, if not: shows instructions to pull up menu. If yes: checks if the crops are done, if yes, lets players harvest
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
            if (!currentCrop.isGrowing())
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

    // Disables instruction text
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerText.gameObject.SetActive(false);
        }
    }

    // If the crops are done growing, increments their variable and sets the currentCrop to null
    private void OnTriggerStay(Collider other)
    {
        if (playerNum == 1)
        {
            if ((harvestable) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
            {
                //+1 crop
                disableCrops();
                currentCrop = null;
                harvestable = false;
            }
            else if ((!harvestable) && Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
                cropMenu.SetActive(true);
                CM.setFieldNum(fieldNumber);
            }
        }
        else if (playerNum == 2)
        {
            if ((harvestable) && (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return)))
            {
                //+1 crop
                disableCrops();
                currentCrop = null;
                harvestable = false;
            }
            else if ((!harvestable) && Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return))
            {
                cropMenu.SetActive(true);
                CM.setFieldNum(fieldNumber);
            }
        }
    }

    private void disableCrops()
    {
        switch (fieldNumber) {
            case 1:
                CM.disableField1();
                break;
            case 2:
                CM.disableField2();
                break;
            case 3:
                CM.disableField3();
                break;
            case 4:
                CM.disableField4();
                break;
        }
    }

}
