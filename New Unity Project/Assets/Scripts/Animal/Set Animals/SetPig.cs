using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPig : MonoBehaviour
{
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.pig = gameObject.GetComponent<Animal>();
    }
}
