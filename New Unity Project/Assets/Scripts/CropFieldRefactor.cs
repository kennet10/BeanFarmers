using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//Made by Ben Hamilton and Haley Vlahos
public class CropFieldRefactor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI triggerText;
    [SerializeField] private int fieldNumber;
    [SerializeField] private GameObject cropMenu;
    [SerializeField] private CropCoroutine currentCrop;
    [SerializeField] private CropManagerRefactor CM;

    private int playerNum = 1;
    private bool harvestable = false;


    // Updates the triggerText based on the current playerNum
    private void Update()
    {
        if (currentCrop == null) {
            if (playerNum == 1) {
                triggerText.text = "Press Space to plant!";
            }
            if (playerNum == 2) {
                triggerText.text = "Press Enter to plant!";
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
    }

    public void setCurrentCrop(CropCoroutine cc)
    {
        currentCrop = cc;
    }

    // Updates the playerNum and enables the triggerText
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !harvestable) {
            PlayerMovement PM = collision.GetComponent<PlayerMovement>();
            playerNum = PM.playerNum;

            triggerText.gameObject.SetActive(true);
        }
    }

    // Disables instruction text
    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player") {
            triggerText.gameObject.SetActive(false);
        //}
    }


    private void OnTriggerStay(Collider other)
    {
        if(currentCrop != null)
            triggerText.gameObject.SetActive(false);
        if(harvestable)
            triggerText.gameObject.SetActive(true);
        

        if (playerNum == 1) {

            // If the crops are harvestable and player1 presses space, it will harvest the crop
            if ((harvestable) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))) {
                increaseCrop();
                CM.disableField();
                currentCrop = null;
                harvestable = false;

                // otherwise, if they have a seed and press space, the cropMenu is enabled
            } else if ((!harvestable) && !ResourceManager.seeds.All(o => o == 0) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))) {
                CM.setButtons();
                cropMenu.SetActive(true);
            }
        } else if (playerNum == 2) {

            // If the crops are harvestable and player2 presses enter, it will harvest the crop
            if ((harvestable) && (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return))) {
                increaseCrop();
                CM.disableField();
                currentCrop = null;
                harvestable = false;

                // otherwise, if they have a seed and press enter, the cropMenu is enabled
            } else if ((!harvestable) && !ResourceManager.seeds.All(o => o == 0) && (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return))) {
                CM.setButtons();
                cropMenu.SetActive(true);
            }
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
