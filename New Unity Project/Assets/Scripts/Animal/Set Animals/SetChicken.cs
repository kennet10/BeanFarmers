using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChicken : MonoBehaviour
{
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.chicken = gameObject.GetComponent<Animal>();
    }
}
