using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedShopUIManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    private AnimalSO[] seeds;

    public void Start()
    {
        seeds = Resources.LoadAll<AnimalSO>("ScriptableObjects");
        for(int i = 0; i < seeds.Length; i++)
        {
            GameObject button = Instantiate(buttonTemplate);
            button.SetActive(true);

            // button.GetComponent<SeedListButton>().SetUp(seeds[i]);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
        Destroy(buttonTemplate);
    }
}
