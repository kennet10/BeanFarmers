using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Made by Haley Vlahos
public class PastureTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI triggerText;
    [SerializeField] private GameObject animalMenu;
    [SerializeField] private FeedUI Feeding;
    private int playerNum;


    // Sets the text and activation key depending on which player last entered the range
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player") {
            PlayerMovement PM = collision.GetComponent<PlayerMovement>();

            if (PM.playerNum == 1) {
                triggerText.text = "Press Space to feed animals!";
                playerNum = 1;
            }
            if (PM.playerNum == 2) {
                triggerText.text = "Press Enter to feed animals!";
                playerNum = 2;
            }

            triggerText.gameObject.SetActive(true);

        }
    }

    // Disables the instructions text when a player leaves
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            triggerText.gameObject.SetActive(false);
        }
    }

    // Pressing your submit key will open the animalMenu
    private void OnTriggerStay(Collider other)
    {
        if (playerNum == 1) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)) {
                animalMenu.SetActive(true);
                triggerText.gameObject.SetActive(false);
                Feeding.checkButton();
            }
        } else if (playerNum == 2) {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Return)) {
                animalMenu.SetActive(true);
                triggerText.gameObject.SetActive(false);
                Feeding.checkButton();
            }
        }
    }
}
