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
    [SerializeField] private ResourceManager RM;

    public Animal chicken;
    public Animal cow;
    public Animal duck;
    public Animal pig;
    public Animal sheep;

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
    private void OnEnable()
    {
        if (chicken.gameObject == null || chicken.getOnCD()) {
            chickenButton.gameObject.SetActive(false);
        }
        if (cow.gameObject == null || cow.getOnCD()) {
            cowButton.gameObject.SetActive(false);
        }
        if (duck.gameObject == null || duck.getOnCD()) {
            duckButton.gameObject.SetActive(false);
        }
        if (pig.gameObject == null || pig.getOnCD()) {
            pigButton.gameObject.SetActive(false);
        }
        if (sheep.gameObject == null || sheep.getOnCD()) {
            sheepButton.gameObject.SetActive(false);
        }
    }

    // These methods all check if the player has enough money to feed them: if they do, the player pays that money, they gain the resource, and the animal goes on cooldown
    private void chickGoesCluck()
    {
        if(RM.money >= chickCost) {
            ResourceManager.eggs++;
            RM.money -= chickCost;
            chicken.StartCooldown();
        }
    }

    private void cowGoesMoo()
    {
        if (RM.money >= cowCost) {
            ResourceManager.milk++;
            RM.money -= cowCost;
            cow.StartCooldown();
        }
    }

    private void duckGoesQuack()
    {
        if (RM.money >= duckCost) {
            ResourceManager.feathers++;
            RM.money -= duckCost;
            duck.StartCooldown();
        }
    }

    private void pigGoesOink()
    {
        if (RM.money >= pigCost) {
            ResourceManager.bacon++;
            RM.money -= pigCost;
            pig.StartCooldown();
        }
    }

    private void sheepGoesBaa()
    {
        if (RM.money >= sheepCost) {
            ResourceManager.wool++;
            RM.money -= sheepCost;
            sheep.StartCooldown();
        }
    }

}
