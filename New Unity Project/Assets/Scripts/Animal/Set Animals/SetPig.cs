using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Haley Vlahos
public class SetPig : MonoBehaviour
{
    // Sets the animal component for the FeedUI
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.SetPig(gameObject.GetComponent<Animal>());
    }
}
