using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Kenneth Tang
public class SeedListButton : MonoBehaviour
{
    private Text[] texts;
    private Image[] images;

    // Get all text and image components of button
    public void Awake()
    {
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
    }

    // Set name, buy cost, and image of button
    public void SetUp(CropSO cropSO)
    {
        texts[0].text = cropSO.GetCropName();
        texts[1].text = cropSO.GetBuyCost().ToString();
        images[1].sprite = cropSO.GetCropImage();
    }
}
