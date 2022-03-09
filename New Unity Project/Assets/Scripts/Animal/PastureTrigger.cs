using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

// Made by Haley Vlahos
public class PastureTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI triggerText;
    [SerializeField] private GameObject animalMenu;
    [SerializeField] private FeedUI Feeding;
    private int playerNum = 1;


    // Sets the text and activation key depending on which player last entered the range
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player") {
            PlayerMovement PM = collision.GetComponent<PlayerMovement>();

            playerNum = PM.playerNum;
            if (PM.playerNum == 1) {
                triggerText.text = "Press Space to feed animals!";
                triggerText.gameObject.SetActive(true);
            }
            if (PM.playerNum == 2 && PM.gameObject.GetComponent<NavMeshAgent>().enabled == false) {
                triggerText.text = "Press Enter to feed animals!";
                triggerText.gameObject.SetActive(true);
            }
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
        string button = "Submit" + playerNum;
        if (Input.GetButtonDown(button) || Input.GetButton(button)) {
                animalMenu.SetActive(true);
                triggerText.gameObject.SetActive(false);
                Feeding.checkButton();
        }
        
    }
}
