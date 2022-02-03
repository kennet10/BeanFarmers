using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Haley Vlahos
public class SetChicken : MonoBehaviour
{
    // Sets the animal component for the FeedUI
    private void Awake()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.SetChicken(gameObject.GetComponent<Animal>());
    }
}
