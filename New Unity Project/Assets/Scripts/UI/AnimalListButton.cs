using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Kenneth Tang
public class AnimalListButton : MonoBehaviour
{
    private Text[] texts;
    private Image[] images;

    public void Awake()
    {
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
    }

    public void SetUp(AnimalSO animalSO)
    {
        texts[0].text = animalSO.GetAnimalName();
        texts[1].text = animalSO.GetBuyCost().ToString();
        images[1].sprite = animalSO.GetAnimalImage();
    }
}
