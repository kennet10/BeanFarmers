using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Haley Vlahos
public class CropManager_Refactored : MonoBehaviour
{
    // Buttons
    [SerializeField] private Button carrotButton;
    [SerializeField] private Button cornButton;
    [SerializeField] private Button pumpkinButton;
    [SerializeField] private Button turnipButton;
    [SerializeField] private Button tomatoButton;

    // Crops
    [SerializeField] private GameObject Carrot;
    [SerializeField] private GameObject Corn;
    [SerializeField] private GameObject Pumpkin;
    [SerializeField] private GameObject Tomato;
    [SerializeField] private GameObject Turnip;

    [SerializeField] private CropField_Refactored field;
    public int cropType { get; private set; }

    private const int carrotNum = 1;
    private const int cornNum = 2;
    private const int pumpkinNum = 3;
    private const int turnipNum = 4;
    private const int tomatoNum = 5;

    private CropCoroutine currentCrop;

    private const int zeroConst = 0;

    public void setButtons()
    {
        // Removes all listeners from the buttons
        carrotButton.onClick.RemoveAllListeners();
        cornButton.onClick.RemoveAllListeners();
        pumpkinButton.onClick.RemoveAllListeners();
        turnipButton.onClick.RemoveAllListeners();
        tomatoButton.onClick.RemoveAllListeners();

        // Adds the listeners for this field
        carrotButton.onClick.AddListener(CarrotButton);
        cornButton.onClick.AddListener(CornButton);
        pumpkinButton.onClick.AddListener(PumpkinButton);
        turnipButton.onClick.AddListener(TurnipButton);
        tomatoButton.onClick.AddListener(TomatoButton);
    }

    public void disableField()
    {
        Carrot.SetActive(false);
        Corn.SetActive(false);
        Pumpkin.SetActive(false);
        Turnip.SetActive(false);
        Tomato.SetActive(false);
    }

    // If you have the proper seed, each button deactivates all crops except for the proper one,
    // decrements the seed amount, and sets the current crop for the CropManager
    private void CarrotButton()
    {
        if (ResourceManager.carrotSeeds > zeroConst) {
            Carrot.SetActive(true);
            Corn.SetActive(false);
            Pumpkin.SetActive(false);
            Turnip.SetActive(false);
            Tomato.SetActive(false);

            ResourceManager.carrotSeeds--;
            cropType = carrotNum;
            currentCrop = Carrot.GetComponentInChildren<CropCoroutine>();
            field.setCurrentCrop(currentCrop);
        }
    }

    private void CornButton()
    {
        if (ResourceManager.cornSeeds > zeroConst) {
            Carrot.SetActive(false);
            Corn.SetActive(true);
            Pumpkin.SetActive(false);
            Turnip.SetActive(false);
           Tomato.SetActive(false);

            ResourceManager.cornSeeds--;
            cropType = cornNum;
            currentCrop = Corn.GetComponentInChildren<CropCoroutine>();
            field.setCurrentCrop(currentCrop);
        }
    }

    private void PumpkinButton()
    {
        if (ResourceManager.pumpkinSeeds > zeroConst) {
            Carrot.SetActive(false);
            Corn.SetActive(false);
            Pumpkin.SetActive(true);
            Turnip.SetActive(false);
            Tomato.SetActive(false);

            ResourceManager.pumpkinSeeds--;
            cropType = pumpkinNum;
            currentCrop = Pumpkin.GetComponentInChildren<CropCoroutine>();
            field.setCurrentCrop(currentCrop);
        }
    }

    private void TurnipButton()
    {
        if (ResourceManager.turnipSeeds > zeroConst) {
            Carrot.SetActive(false);
            Corn.SetActive(false);
            Pumpkin.SetActive(false);
            Turnip.SetActive(true);
            Tomato.SetActive(false);

            ResourceManager.turnipSeeds--;
            cropType = turnipNum;
            currentCrop = Turnip.GetComponentInChildren<CropCoroutine>();
            field.setCurrentCrop(currentCrop);
        }
    }

    private void TomatoButton()
    {
        if (ResourceManager.tomatoSeeds > zeroConst) {
            Carrot.SetActive(false);
            Corn.SetActive(false);
            Pumpkin.SetActive(false);
            Turnip.SetActive(false);
            Tomato.SetActive(true);

            ResourceManager.tomatoSeeds--;
            cropType = tomatoNum;
            currentCrop = Tomato.GetComponentInChildren<CropCoroutine>();
            field.setCurrentCrop(currentCrop);
        }
    }
}
