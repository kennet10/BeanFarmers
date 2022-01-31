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

    //public void PlantCrop()
    //{
    //    for (int i = 0; i < (columnLength * rowLength); i++) {
    //        Vector3 position;
    //        position = new Vector3((xStart + (xSpace * (i % columnLength))), 0, (zStart + (zSpace * (i / columnLength))));
    //        Instantiate(cropPrefab, position, Quaternion.identity);
    //    }
    //    StartCoroutine(Growing());
    //}

    //public bool IsGrowing()
    //{
    //    return cropGrowing;
    //}

    //private IEnumerator Growing()
    //{
    //    cropGrowing = true;

    //    Vector3 originalScale = new Vector3(startingSize, startingSize, startingSize);
    //    Vector3 endScale = new Vector3(scaleSize, scaleSize, scaleSize);

    //    float currentTime = 0.0f;
    //    while (currentTime < growthTime)
    //    {
    //        cropPrefab.transform.localScale = Vector3.Lerp(originalScale, endScale, currentTime / growthTime);
    //        currentTime += Time.deltaTime;

    //        yield return null;
    //    }

    //    transform.localScale = endScale;
    //    cropGrowing = false;
    //}
}
