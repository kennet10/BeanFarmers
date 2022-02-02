using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Haley Vlahos
public class FeedUI : MonoBehaviour
{
    [SerializeField] private Button chickenButton;
    [SerializeField] private Button cowButton;
    [SerializeField] private Button duckButton;
    [SerializeField] private Button pigButton;
    [SerializeField] private Button sheepButton;

    private Animal chicken = null;
    private Animal cow = null;
    private Animal duck = null;
    private Animal pig = null;
    private Animal sheep = null;

    private int chickCost = 10;
    private int cowCost = 15;
    private int duckCost = 20;
    private int pigCost = 25;
    private int sheepCost = 30;

    // Following functions set their respective animal variable to a gameObject and adds a listener to their corresponding button
    // Kenneth Tang
    public void SetChicken(Animal chickenScript)
    {
        chicken = chickenScript;
        chickenButton.onClick.AddListener(chickGoesCluck);
    }

    public void SetCow(Animal cowScript)
    {
        chicken = cowScript;
        cowButton.onClick.AddListener(cowGoesMoo);
    }

    public void SetDuck(Animal duckScript)
    {
        chicken = duckScript;
        duckButton.onClick.AddListener(duckGoesQuack);
    }

    public void SetPig(Animal pigScript)
    {
        chicken = pigScript;
        pigButton.onClick.AddListener(pigGoesOink);
    }

    public void SetSheep(Animal sheepScript)
    {
        sheep = sheepScript;
        sheepButton.onClick.AddListener(sheepGoesBaa);
    }

    // Checks whether the animal's product is on cooldown or if the player does not have the animal
    public void checkButton()
    {

        if (chicken == null || chicken.getOnCD()) {
            chickenButton.gameObject.SetActive(false);
        }
        else
        {
            chickenButton.gameObject.SetActive(true);
        }
        if (cow == null || cow.getOnCD()) {
            cowButton.gameObject.SetActive(false);
        }
        else
        {
            cowButton.gameObject.SetActive(true);
        }
        if (duck == null || duck.getOnCD()) {
            duckButton.gameObject.SetActive(false);
        }
        else
        {
            duckButton.gameObject.SetActive(true);
        }
        if (pig == null || pig.getOnCD()) {
            pigButton.gameObject.SetActive(false);
        }
        else
        {
            pigButton.gameObject.SetActive(true);
        }
        if (sheep == null || sheep.getOnCD()) {
            sheepButton.gameObject.SetActive(false);
        }
        else
        {
            sheepButton.gameObject.SetActive(true);
        }
    }

    // These methods all check if the player has enough money to feed them: if they do, the player pays that money, they gain the resource, and the animal goes on cooldown
    private void chickGoesCluck()
    {
        if(ResourceManager.money >= chickCost && !chicken.getOnCD()) {
            chicken.StartCooldown();
            ResourceManager.eggs++;
            ResourceManager.money -= chickCost;
            checkButton();
            chickenButton.gameObject.SetActive(false);
        }
    }

    private void cowGoesMoo()
    {
        if (ResourceManager.money >= cowCost && !cow.getOnCD()) {
            cow.StartCooldown();
            ResourceManager.milk++;
            ResourceManager.money -= cowCost;
            checkButton();
            cowButton.gameObject.SetActive(false);
        }
    }

    private void duckGoesQuack()
    {
        if (ResourceManager.money >= duckCost && !duck.getOnCD()) {
            duck.StartCooldown();
            ResourceManager.feathers++;
            ResourceManager.money -= duckCost;
            checkButton();
            duckButton.gameObject.SetActive(false);
        }
    }

    private void pigGoesOink()
    {
        if (ResourceManager.money >= pigCost && !pig.getOnCD()) {
            pig.StartCooldown();
            ResourceManager.bacon++;
            ResourceManager.money -= pigCost;
            pigButton.gameObject.SetActive(false);
        }
    }

    private void sheepGoesBaa()
    {
        if (ResourceManager.money >= sheepCost && !sheep.getOnCD()) {
            sheep.StartCooldown();
            ResourceManager.wool++;
            ResourceManager.money -= sheepCost;
            checkButton();
            sheepButton.gameObject.SetActive(false);
        }
    }

}
