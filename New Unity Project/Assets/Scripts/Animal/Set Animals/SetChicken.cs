using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChicken : MonoBehaviour
{
    private void Awake()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.SetChicken(gameObject.GetComponent<Animal>());
    }
}
