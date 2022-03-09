using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Kenneth Tang
public class AnimalListButton : MonoBehaviour
{
    private Text[] texts;
    private Image[] images;
    private AnimalSO myAnimalSO;

    // Get all text and image components of button
    public void Awake()
    {
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
    }

    // Set name, buy cost, and image of button
    public void SetUp(AnimalSO animalSO)
    {
        myAnimalSO = animalSO;
        texts[0].text = animalSO.GetAnimalName();
        texts[1].text = animalSO.GetBuyCost().ToString();
        images[1].sprite = animalSO.GetAnimalImage();
    }

    public void OnClick()
    {
        int money = ResourceManager.money;
        if (money >= myAnimalSO.GetBuyCost())
        {
            GameObject spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint");
            GameObject animal = Instantiate(myAnimalSO.GetAnimalPrefab(), spawnpoint.transform.position, spawnpoint.transform.rotation);
            animal.transform.parent = spawnpoint.transform.parent;
            Destroy(spawnpoint);
            Destroy(this.gameObject);
            ResourceManager.money = money - myAnimalSO.GetBuyCost();
            PlayerAI.AnyAnimalsBought = true;
        }
    }
}
