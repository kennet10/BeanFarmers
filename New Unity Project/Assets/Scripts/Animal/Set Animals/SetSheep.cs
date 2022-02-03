using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Haley Vlahos
public class SetSheep : MonoBehaviour
{
    // Sets the animal component for the FeedUI
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.SetSheep(gameObject.GetComponent<Animal>());
    }
}
