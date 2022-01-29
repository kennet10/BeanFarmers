using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by Ben Hamilton
public class Crop : MonoBehaviour
{
    [SerializeField] CropSO cropSO;
    [SerializeField] private float scaleSize;

    private int buyCost;
    private int sellCost;
    private float growthTime;
    private bool cropGrowing;
    private GameObject cropPrefab;

    void Start()
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

    public void PlantCrop()
    {
        StartCoroutine(Growing());
    }

    public bool IsGrowing()
    {
        return cropGrowing;
    }

    private IEnumerator Growing()
    {
        cropGrowing = true;

        Vector3 originalScale = cropPrefab.transform.localScale;
        Vector3 endScale = new Vector3(scaleSize, scaleSize, scaleSize);

        float currentTime = 0.0f;

        while (currentTime <= growthTime)
        {
            cropPrefab.transform.localScale = Vector3.Lerp(originalScale, endScale, currentTime / growthTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
        cropGrowing = false;
    }
}
