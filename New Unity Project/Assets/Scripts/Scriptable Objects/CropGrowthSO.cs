using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Haley Vlahos
[CreateAssetMenu]
public class CropGrowthSO : ScriptableObject
{
    [SerializeField] public float startingSize;
    [SerializeField] public float scaleSize;
    [SerializeField] public int growthTime;
}
