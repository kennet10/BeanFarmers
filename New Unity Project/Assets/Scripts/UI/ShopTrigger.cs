using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

// Made by Haley Vlahos
public class ShopTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI triggerText;
    [SerializeField] GameObject shopMenu;
    private int num = 1;

    // Shows and sets the text instructions to match the button of the player who entered
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            PlayerMovement PM = other.GetComponent<PlayerMovement>();

            if(PM.playerNum == 1) {
                triggerText.text = "Press space to open the shop";
                num = PM.playerNum;
                triggerText.gameObject.SetActive(true);
            }
            if (PM.playerNum == 2) {
                triggerText.text = "Press enter to open the shop";
                num = PM.playerNum;
                triggerText.gameObject.SetActive(true);
            }
        }
    }

    // Hides the text when player leaves the area
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            triggerText.gameObject.SetActive(false);
        }
    }

    // Depending on which player was the last to enter the trigger, pressing their submit button will open the shop menu
    private void OnTriggerStay(Collider other)
    {
        string button = "Submit" + num;
        if (Input.GetButtonDown(button) || Input.GetButton(button)) {
            shopMenu.SetActive(true);
        }
    }
}
