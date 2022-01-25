using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AnimalSO : ScriptableObject
{
    [SerializeField] private int buy_cost;
    [SerializeField] private int product_price;
    [SerializeField] private int production_cd;
    [SerializeField] private GameObject animal_prefab;

    private bool onCooldown = false;

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
}
