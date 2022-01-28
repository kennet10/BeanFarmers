using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Kenneth Tang
public class Animal : MonoBehaviour
{
    [SerializeField] AnimalSO animalSO;

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

    public void FeedAnimal()
    {
        StartCoroutine(GoOnCooldown());
        //call function to increase product count by 1
    }

    private IEnumerator GoOnCooldown()
    {
        onCD = true;
        yield return new WaitForSeconds(productionCD);
        onCD = false;
    }
}
