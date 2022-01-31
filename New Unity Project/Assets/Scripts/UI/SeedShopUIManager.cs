using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Kenneth Tang
public class SeedShopUIManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    private CropSO[] seeds;

    // Gets all the CropSOs and makes a button for each
    public void Start()
    {
        seeds = Resources.LoadAll<CropSO>("Crop ScriptableObjects");
        for(int i = 0; i < seeds.Length; i++)
        {
            GameObject button = Instantiate(buttonTemplate);
            button.SetActive(true);

            button.GetComponent<SeedListButton>().SetUp(seeds[i]);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
        Destroy(buttonTemplate);
    }
}
