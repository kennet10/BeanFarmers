using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Made by Ben Hamilton
[CreateAssetMenu]
public class CropSO : ScriptableObject
{
    [SerializeField] private string cropName;
    [SerializeField] private int buyCost;
    [SerializeField] private int sellCost;
    [SerializeField] private int growthTime;
    [SerializeField] private GameObject cropPrefab;
    [SerializeField] private Sprite cropSprite;

    public string GetCropName()
    {
        return cropName;
    }
    public int GetBuyCost()
    {
        return buyCost;
    }

    public int GetSellCost()
    {
        return sellCost;
    }

    public int GetGrowthTime()
    {
        return growthTime;
    }

    public GameObject GetCropPrefab()
    {
        return cropPrefab;
    }

    public Sprite GetCropImage()
    {
        return cropSprite;
    }
}
