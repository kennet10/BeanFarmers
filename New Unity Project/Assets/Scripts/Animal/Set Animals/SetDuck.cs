using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDuck : MonoBehaviour
{
    private void Start()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("FeedUI");
        FeedUI ui = menu.GetComponent<FeedUI>();
        ui.SetDuck(gameObject.GetComponent<Animal>());
    }
}
