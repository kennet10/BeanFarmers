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

    public Animal chicken = null;
    public Animal cow = null;
    public Animal duck = null;
    public Animal pig = null;
    public Animal sheep = null;

    private int chickCost = 10;
    private int cowCost = 15;
    private int duckCost = 20;
    private int pigCost = 25;
    private int sheepCost = 30;

    // Sets the button functions for the feeding menu
    private void Awake()
    {
        chickenButton.onClick.AddListener(chickGoesCluck);
        cowButton.onClick.AddListener(cowGoesMoo);
        duckButton.onClick.AddListener(duckGoesQuack);
        pigButton.onClick.AddListener(pigGoesOink);
        sheepButton.onClick.AddListener(sheepGoesBaa);
    }

    // Checks whether the animal's product is on cooldown or if the player does not have the animal
    public void checkButton()
    {

        if (chicken == null || chicken.getOnCD()) {
            chickenButton.gameObject.SetActive(false);
        }
        if (cow == null || cow.getOnCD()) {
            cowButton.gameObject.SetActive(false);
        }
        if (duck == null || duck.getOnCD()) {
            duckButton.gameObject.SetActive(false);
        }
        if (pig == null || pig.getOnCD()) {
            pigButton.gameObject.SetActive(false);
        }
        if (sheep == null || sheep.getOnCD()) {
            sheepButton.gameObject.SetActive(false);
        }
    }

    // These methods all check if the player has enough money to feed them: if they do, the player pays that money, they gain the resource, and the animal goes on cooldown
    private void chickGoesCluck()
    {
        if(ResourceManager.money >= chickCost && !chicken.getOnCD()) {
            chicken.StartCooldown();
            ResourceManager.eggs++;
            ResourceManager.money -= chickCost;
        }
    }

    private void cowGoesMoo()
    {
        if (ResourceManager.money >= cowCost && !cow.getOnCD()) {
            cow.StartCooldown();
            ResourceManager.milk++;
            ResourceManager.money -= cowCost;
        }
    }

    private void duckGoesQuack()
    {
        if (ResourceManager.money >= duckCost && !duck.getOnCD()) {
            duck.StartCooldown();
            ResourceManager.feathers++;
            ResourceManager.money -= duckCost;
        }
    }

    private void pigGoesOink()
    {
        if (ResourceManager.money >= pigCost && !pig.getOnCD()) {
            pig.StartCooldown();
            ResourceManager.bacon++;
            ResourceManager.money -= pigCost;
        }
    }

    private void sheepGoesBaa()
    {
        if (ResourceManager.money >= sheepCost && !sheep.getOnCD()) {
            sheep.StartCooldown();
            ResourceManager.wool++;
            ResourceManager.money -= sheepCost;
        }
    }

}
