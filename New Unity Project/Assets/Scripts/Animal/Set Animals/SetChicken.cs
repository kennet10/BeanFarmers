using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChicken : MonoBehaviour
{
    [SerializeField] private FeedUI ui;
    private void OnEnable()
    {
        ui.chicken = GetComponent<Animal>();
    }
}
