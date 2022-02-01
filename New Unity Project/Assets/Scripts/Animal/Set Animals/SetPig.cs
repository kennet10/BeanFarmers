using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPig : MonoBehaviour
{
    [SerializeField] private FeedUI ui;
    private void OnEnable()
    {
        ui.pig = GetComponent<Animal>();
    }
}
