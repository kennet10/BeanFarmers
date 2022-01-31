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
        // instantiate animal when bought
    }
}
