using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSheep : MonoBehaviour
{
    [SerializeField] private FeedUI ui;
    private void OnEnable()
    {
        ui.sheep = GetComponent<Animal>();
    }
}
