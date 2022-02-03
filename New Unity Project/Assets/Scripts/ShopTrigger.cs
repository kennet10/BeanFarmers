using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Made by Haley Vlahos
public class ShopTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI triggerText;
    [SerializeField] GameObject shopMenu;
    private int num;

    // Shows and sets the text instructions to match the button of the player who entered
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            PlayerMovement PM = other.GetComponent<PlayerMovement>();

            if(PM.playerNum == 1) {
                triggerText.text = "Press space to open the shop";
                num = 1;
            }
            if (PM.playerNum == 2) {
                triggerText.text = "Press enter to open the shop";
                num = 2;
            }

            triggerText.gameObject.SetActive(true);
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
        if(num == 1) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)) {
                shopMenu.SetActive(true);
            }
        } else if(num == 2) {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return)) {
                shopMenu.SetActive(true);
            }
        }
    }
}
