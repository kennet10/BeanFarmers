using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by Ben Hamilton
public class Crop : MonoBehaviour
{
    [SerializeField] CropSO cropSO;
    [SerializeField] private float startingSize;
    [SerializeField] private float scaleSize;
    
    [SerializeField] private int columnLength;
    [SerializeField] private int rowLength;
    [SerializeField] private float xSpace;
    [SerializeField] private float zSpace;
    [SerializeField] private float xStart;
    [SerializeField] private float zStart;

    private int buyCost;
    private int sellCost;
    private float growthTime;
    private bool cropGrowing;
    private GameObject cropPrefab;

    void Awake()
    {
        buyCost = cropSO.GetBuyCost();
        sellCost = cropSO.GetSellCost();
        growthTime = cropSO.GetGrowthTime();
        cropPrefab = cropSO.GetCropPrefab();
    }

    public int GetBuyCost()
    {
        return buyCost;
    }

}
