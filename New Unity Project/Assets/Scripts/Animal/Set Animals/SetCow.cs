using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCow : MonoBehaviour
{
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.cow = gameObject.GetComponent<Animal>();
    }
}
