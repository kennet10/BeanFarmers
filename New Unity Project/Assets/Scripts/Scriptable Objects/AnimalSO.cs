using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Kenneth Tang
[CreateAssetMenu]
public class AnimalSO : ScriptableObject
{
    [SerializeField] private string animalName;
    [SerializeField] private int buy_cost;
    [SerializeField] private int product_price;
    [SerializeField] private int production_cd;
    [SerializeField] private GameObject animal_prefab;
    [SerializeField] private Sprite animalImage;

    public string GetAnimalName()
    {
        return animalName;
    }
    public int GetBuyCost()
    {
        return buy_cost;
    }

    public int GetSellPrice()
    {
        return product_price;
    }

    public int GetProductionCD()
    {
        return production_cd;
    }

    public GameObject GetAnimalPrefab()
    {
        return animal_prefab;
    }

    public Sprite GetAnimalImage()
    {
        return animalImage;
    }
}
