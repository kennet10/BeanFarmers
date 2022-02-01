using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCow : MonoBehaviour
{
    [SerializeField] private FeedUI ui;
    private void OnEnable()
    {
        ui.cow = GetComponent<Animal>();
    }
}
