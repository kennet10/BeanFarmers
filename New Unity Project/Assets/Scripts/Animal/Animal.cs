using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Kenneth Tang
public class Animal : MonoBehaviour
{
    [SerializeField] private AnimalSO animalSO;
    [SerializeField] private int product;

    private int buy_cost;
    private int sell_price;
    private float productionCD;
    private bool onCD;

    private void Start()
    {
        buy_cost = animalSO.GetBuyCost();
        sell_price = animalSO.GetSellPrice();
        productionCD = animalSO.GetProductionCD();
        onCD = false;
    }

    public int GetBuyCost()
    {
        return buy_cost;
    }

    // Feed the animal for and get one of their products
    public void StartCooldown()
    {
        StartCoroutine(GoOnCooldown());
    }

    // Go on cooldown. While oncooldown, unable to get any products.
    private IEnumerator GoOnCooldown()
    {
        onCD = true;
        yield return new WaitForSeconds(productionCD);
        onCD = false;
    }
}
