using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//Original by Ben Hamilton and Haley Vlahos, Refactored by Haley Vlahos
public class CropField_Refactored : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI triggerText;
    [SerializeField] private GameObject cropMenu;
    [SerializeField] private CropCoroutine currentCrop;
    [SerializeField] private CropManager_Refactored CM;

    private static int playerNum = 1;
    private bool harvestable = false;


    // Updates the triggerText based on the current playerNum
    private void updateText()
    {
        // Sets the text based on harvestable and 
        if (currentCrop == null) {
            if (!ResourceManager.seeds.All(o => o == 0)) {
                if (playerNum == 1) {
                    triggerText.text = "Press Space to plant!";
                    triggerText.gameObject.SetActive(true);
                }
                if (playerNum == 2) {
                    triggerText.text = "Press Enter to plant!";
                    triggerText.gameObject.SetActive(true);
                }
            }
        } else {
            if (playerNum == 1) {
                triggerText.text = "Press Space to harvest!";
            }
            if (playerNum == 2) {
                 triggerText.text = "Press Enter to harvest!";
            }

             if (!currentCrop.isGrowing())
                harvestable = true;
        }

        if (currentCrop != null)
            triggerText.gameObject.SetActive(false);
        if (harvestable)
            triggerText.gameObject.SetActive(true);

    }

    public void setCurrentCrop(CropCoroutine cc)
    {
        currentCrop = cc;
    }

    // Updates the playerNum and enables the triggerText
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player") {
            PlayerMovement PM = collision.GetComponent<PlayerMovement>();
            playerNum = PM.playerNum;
            updateText();

            if (!ResourceManager.seeds.All(o => o == 0))
                triggerText.gameObject.SetActive(true);
        }
    }

    // Disables instruction text
    private void OnTriggerExit(Collider other)
    {
            triggerText.gameObject.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        updateText();

        string button = "Submit" + playerNum;

        if ((harvestable) && (Input.GetButtonDown(button) || Input.GetButtonDown(button))) {
            increaseCrop();
            CM.disableField();
            currentCrop = null;
            harvestable = false;

            if (!ResourceManager.seeds.All(o => o == 0))
                triggerText.gameObject.SetActive(true);
            else
                triggerText.gameObject.SetActive(false);

            // otherwise, if they have a seed and press space, the cropMenu is enabled
        } else if ((!harvestable) && !ResourceManager.seeds.All(o => o == 0) && (Input.GetButtonDown(button) || Input.GetButtonDown(button))) {
            CM.setButtons();
            cropMenu.SetActive(true);
        }

    }

    private void increaseCrop()
    {
        switch (CM.cropType) {
            case 1:
                ResourceManager.carrots++;
                break;
            case 2:
                ResourceManager.corn++;
                break;
            case 3:
                ResourceManager.pumpkins++;
                break;
            case 4:
                ResourceManager.turnips++;
                break;
            case 5:
                ResourceManager.tomatoes++;
                break;
        }
    }

}
