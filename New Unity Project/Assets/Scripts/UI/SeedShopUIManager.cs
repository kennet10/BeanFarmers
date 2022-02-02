using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            switch (i)
            {
                case 0:
                    button.GetComponent<Button>().onClick.AddListener(SetCarrotSeed);
                    break;
                case 1:
                    button.GetComponent<Button>().onClick.AddListener(SetCornSeed);
                    break;
                case 2:
                    button.GetComponent<Button>().onClick.AddListener(SetPumpkinSeed);
                    break;
                case 3:
                    button.GetComponent<Button>().onClick.AddListener(SetTomatoSeed);
                    break;
                case 4:
                    button.GetComponent<Button>().onClick.AddListener(SetTurnipSeed);
                    break;
            }
            button.GetComponent<SeedListButton>().SetUp(seeds[i]);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
        Destroy(buttonTemplate);
    }

    // The following 5 functions check to see if players have the money to buy a seed, and if they do, takes their money and gives them a seed
    public void SetCarrotSeed()
    {
        if (ResourceManager.money >= seeds[0].GetBuyCost())
        {
            ResourceManager.money -= seeds[0].GetBuyCost();
            ResourceManager.carrotSeeds++;
        }
    }

    public void SetCornSeed()
    {
        if(ResourceManager.money >= seeds[1].GetBuyCost())
        {
            ResourceManager.money -= seeds[1].GetBuyCost();
            ResourceManager.cornSeeds++;
        }
    }

    public void SetPumpkinSeed()
    {
        if (ResourceManager.money >= seeds[2].GetBuyCost())
        {
            ResourceManager.money -= seeds[2].GetBuyCost();
            ResourceManager.pumpkinSeeds++;
        }
    }

    public void SetTomatoSeed()
    {
        if (ResourceManager.money >= seeds[3].GetBuyCost())
        {
            ResourceManager.money -= seeds[3].GetBuyCost();
            ResourceManager.tomatoSeeds++;
        }
    }

    public void SetTurnipSeed()
    {
        if (ResourceManager.money >= seeds[4].GetBuyCost())
        {
            ResourceManager.money -= seeds[4].GetBuyCost();
            ResourceManager.turnipSeeds++;
        }
    }
}
