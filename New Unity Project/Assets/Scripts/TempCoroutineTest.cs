using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCoroutineTest : MonoBehaviour
{
    private bool cropGrowing;
    [SerializeField] private GameObject cropPrefab;
    [SerializeField] private float startingSize;
    [SerializeField] private float scaleSize;
    [SerializeField] private int growthTime;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Growing());
        }
    }

    private IEnumerator Growing()
    {
        cropGrowing = true;

        Vector3 originalScale = new Vector3(startingSize, startingSize, startingSize);
        Vector3 endScale = new Vector3(scaleSize, scaleSize, scaleSize);
        Debug.Log(originalScale);
        Debug.Log(endScale);

        float currentTime = 0.0f;
        while (currentTime <= growthTime)
        {
            //Debug.Log("${currentTime}");
            cropPrefab.transform.localScale = Vector3.Lerp(originalScale, endScale, currentTime / growthTime);
            currentTime += Time.deltaTime;
        }
        yield return null;
        cropGrowing = false;
    }
}
