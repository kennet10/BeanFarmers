using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Haley Vlahos
public class SetDuck : MonoBehaviour
{
    // Sets the animal component for the FeedUI
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.SetDuck(gameObject.GetComponent<Animal>());
    }
}
