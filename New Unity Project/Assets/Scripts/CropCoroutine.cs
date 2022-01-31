using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Ben Hamilton
public class CropCoroutine : MonoBehaviour
{
    private bool cropGrowing;
    [SerializeField] private CropGrowthSO cropGrowth;

    public bool isGrowing()
    {
        return cropGrowing;
    }

    private void OnEnable()
    {
        StartCoroutine(Growing());
    }

    private IEnumerator Growing()
    {
        cropGrowing = true;

        Vector3 originalScale = new Vector3(cropGrowth.startingSize, cropGrowth.startingSize, cropGrowth.startingSize);
        Vector3 endScale = new Vector3(cropGrowth.scaleSize, cropGrowth.scaleSize, cropGrowth.scaleSize);
        Debug.Log(originalScale);
        Debug.Log(endScale);

        float currentTime = 0.0f;
        while (currentTime < cropGrowth.growthTime)
        {
            //Debug.Log("${currentTime}");
            transform.localScale = Vector3.Lerp(originalScale, endScale, currentTime / cropGrowth.growthTime);
            currentTime += Time.deltaTime;

            yield return null;
        }

        transform.localScale = endScale;
        cropGrowing = false;
    }
}
