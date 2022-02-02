using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSheep : MonoBehaviour
{
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.SetSheep(gameObject.GetComponent<Animal>());
    }
}
