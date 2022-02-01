using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDuck : MonoBehaviour
{
    [SerializeField] private FeedUI ui;
    private void OnEnable()
    {
        ui.duck = GetComponent<Animal>();
    }
}
