using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made by Haley Vlahos
public class CropManager : MonoBehaviour
{
    // Field 1
    [SerializeField] private GameObject oneCarrot;
    [SerializeField] private GameObject oneCorn;
    [SerializeField] private GameObject onePumpkin;
    [SerializeField] private GameObject oneTurnip;
    [SerializeField] private GameObject oneTomato;
    // Field 2
    [SerializeField] private GameObject twoCarrot;
    [SerializeField] private GameObject twoCorn;
    [SerializeField] private GameObject twoPumpkin;
    [SerializeField] private GameObject twoTurnip;
    [SerializeField] private GameObject twoTomato;
    // Field 3
    [SerializeField] private GameObject threeCarrot;
    [SerializeField] private GameObject threeCorn;
    [SerializeField] private GameObject threePumpkin;
    [SerializeField] private GameObject threeTurnip;
    [SerializeField] private GameObject threeTomato;
    // Field 4
    [SerializeField] private GameObject fourCarrot;
    [SerializeField] private GameObject fourCorn;
    [SerializeField] private GameObject fourPumpkin;
    [SerializeField] private GameObject fourTurnip;
    [SerializeField] private GameObject fourTomato;
    // Buttons
    [SerializeField] private Button carrotButton;
    [SerializeField] private Button cornButton;
    [SerializeField] private Button pumpkinButton;
    [SerializeField] private Button turnipButton;
    [SerializeField] private Button tomatoButton;
    // Crop Fields
    [SerializeField] private CropField field1;
    [SerializeField] private CropField field2;
    [SerializeField] private CropField field3;
    [SerializeField] private CropField field4;

    private CropCoroutine currentCrop;
    private int fieldNum;

    public int cropTypeOne { get; private set; }
    public int cropTypeTwo { get; private set; }
    public int cropTypeThree { get; private set; }
    public int cropTypeFour { get; private set; }

    private const int carrotNum = 1;
    private const int cornNum = 2;
    private const int pumpkinNum = 3;
    private const int turnipNum = 4;
    private const int tomatoNum = 5;

    private const int zeroConst = 0;

    public void setFieldNum(int num)
    {
        fieldNum = num;
        setButtons();
    }

    private void setButtons()
    {
        // Removes all listeners from the buttons
        carrotButton.onClick.RemoveAllListeners();
        cornButton.onClick.RemoveAllListeners();
        pumpkinButton.onClick.RemoveAllListeners();
        turnipButton.onClick.RemoveAllListeners();
        tomatoButton.onClick.RemoveAllListeners();

        // Sets the buttons based on the field
        switch (fieldNum) {
            case 1:
                carrotButton.onClick.AddListener(oneCarrotButton);
                cornButton.onClick.AddListener(oneCornButton);
                pumpkinButton.onClick.AddListener(onePumpkinButton);
                turnipButton.onClick.AddListener(oneTurnipButton);
                tomatoButton.onClick.AddListener(oneTomatoButton);
                break;
            case 2:
                carrotButton.onClick.AddListener(twoCarrotButton);
                cornButton.onClick.AddListener(twoCornButton);
                pumpkinButton.onClick.AddListener(twoPumpkinButton);
                turnipButton.onClick.AddListener(twoTurnipButton);
                tomatoButton.onClick.AddListener(twoTomatoButton);
                break;
            case 3:
                carrotButton.onClick.AddListener(threeCarrotButton);
                cornButton.onClick.AddListener(threeCornButton);
                pumpkinButton.onClick.AddListener(threePumpkinButton);
                turnipButton.onClick.AddListener(threeTurnipButton);
                tomatoButton.onClick.AddListener(threeTomatoButton);
                break;
            case 4:
                carrotButton.onClick.AddListener(fourCarrotButton);
                cornButton.onClick.AddListener(fourCornButton);
                pumpkinButton.onClick.AddListener(fourPumpkinButton);
                turnipButton.onClick.AddListener(fourTurnipButton);
                tomatoButton.onClick.AddListener(fourTomatoButton);
                break;

        }
    }

    // Field 1
    private void oneCarrotButton()
    {
        if (ResourceManager.carrotSeeds > zeroConst) {
            oneCarrot.SetActive(true);
            oneCorn.SetActive(false);
            onePumpkin.SetActive(false);
            oneTurnip.SetActive(false);
            oneTomato.SetActive(false);

            ResourceManager.carrotSeeds--;
            cropTypeOne = carrotNum;
            currentCrop = oneCarrot.GetComponentInChildren<CropCoroutine>();
            field1.setCurrentCrop(currentCrop);
        }
    }

    private void oneCornButton()
    {
        if (ResourceManager.cornSeeds > zeroConst) {
            oneCarrot.SetActive(false);
            oneCorn.SetActive(true);
            onePumpkin.SetActive(false);
            oneTurnip.SetActive(false);
            oneTomato.SetActive(false);

            ResourceManager.cornSeeds--;
            cropTypeOne = cornNum;
            currentCrop = oneCorn.GetComponentInChildren<CropCoroutine>();
            field1.setCurrentCrop(currentCrop);
        }
    }

    private void onePumpkinButton()
    {
        if (ResourceManager.pumpkinSeeds > zeroConst) {
            oneCarrot.SetActive(false);
            oneCorn.SetActive(false);
            onePumpkin.SetActive(true);
            oneTurnip.SetActive(false);
            oneTomato.SetActive(false);

            ResourceManager.pumpkinSeeds--;
            cropTypeOne = pumpkinNum;
            currentCrop = onePumpkin.GetComponentInChildren<CropCoroutine>();
            field1.setCurrentCrop(currentCrop);
        }
    }

    private void oneTurnipButton()
    {
        if (ResourceManager.turnipSeeds > zeroConst) {
            oneCarrot.SetActive(false);
            oneCorn.SetActive(false);
            onePumpkin.SetActive(false);
            oneTurnip.SetActive(true);
            oneTomato.SetActive(false);

            ResourceManager.turnipSeeds--;
            cropTypeOne = turnipNum;
            currentCrop = oneTurnip.GetComponentInChildren<CropCoroutine>();
            field1.setCurrentCrop(currentCrop);
        }
    }

    private void oneTomatoButton()
    {
        if (ResourceManager.tomatoSeeds > zeroConst) {
            oneCarrot.SetActive(false);
            oneCorn.SetActive(false);
            onePumpkin.SetActive(false);
            oneTurnip.SetActive(false);
            oneTomato.SetActive(true);

            ResourceManager.tomatoSeeds--;
            cropTypeOne = tomatoNum;
            currentCrop = oneTomato.GetComponentInChildren<CropCoroutine>();
            field1.setCurrentCrop(currentCrop);
        }
    }

    // Field 2
    private void twoCarrotButton()
    {
        if (ResourceManager.carrotSeeds > zeroConst) {
            twoCarrot.SetActive(true);
            twoCorn.SetActive(false);
            twoPumpkin.SetActive(false);
            twoTurnip.SetActive(false);
            twoTomato.SetActive(false);

            ResourceManager.carrotSeeds--;
            cropTypeTwo = carrotNum;
            currentCrop = twoCarrot.GetComponentInChildren<CropCoroutine>();
            field2.setCurrentCrop(currentCrop);
        }
    }

    private void twoCornButton()
    {
        if (ResourceManager.cornSeeds > zeroConst) {
            twoCarrot.SetActive(false);
            twoCorn.SetActive(true);
            twoPumpkin.SetActive(false);
            twoTurnip.SetActive(false);
            twoTomato.SetActive(false);

            ResourceManager.cornSeeds--;
            cropTypeTwo = cornNum;
            currentCrop = twoCorn.GetComponentInChildren<CropCoroutine>();
            field2.setCurrentCrop(currentCrop);
        }
    }

    private void twoPumpkinButton()
    {
        if (ResourceManager.pumpkinSeeds > zeroConst) {
            twoCarrot.SetActive(false);
            twoCorn.SetActive(false);
            twoPumpkin.SetActive(true);
            twoTurnip.SetActive(false);
            twoTomato.SetActive(false);

            ResourceManager.pumpkinSeeds--;
            cropTypeTwo = pumpkinNum;
            currentCrop = twoPumpkin.GetComponentInChildren<CropCoroutine>();
            field2.setCurrentCrop(currentCrop);
        }
    }

    private void twoTurnipButton()
    {
        if (ResourceManager.turnipSeeds > zeroConst) {
            twoCarrot.SetActive(false);
            twoCorn.SetActive(false);
            twoPumpkin.SetActive(false);
            twoTurnip.SetActive(true);
            twoTomato.SetActive(false);

            ResourceManager.turnipSeeds--;
            cropTypeTwo = turnipNum;
            currentCrop = twoTurnip.GetComponentInChildren<CropCoroutine>();
            field2.setCurrentCrop(currentCrop);
        }
    }

    private void twoTomatoButton()
    {
        if (ResourceManager.tomatoSeeds > zeroConst) {
            twoCarrot.SetActive(false);
            twoCorn.SetActive(false);
            twoPumpkin.SetActive(false);
            twoTurnip.SetActive(false);
            twoTomato.SetActive(true);

            ResourceManager.tomatoSeeds--;
            cropTypeTwo = tomatoNum;
            currentCrop = twoTomato.GetComponentInChildren<CropCoroutine>();
            field2.setCurrentCrop(currentCrop);
        }
    }

    //Field 3
    private void threeCarrotButton()
    {
        if (ResourceManager.carrotSeeds > zeroConst) {
            threeCarrot.SetActive(true);
            threeCorn.SetActive(false);
            threePumpkin.SetActive(false);
            threeTurnip.SetActive(false);
            threeTomato.SetActive(false);

            ResourceManager.carrotSeeds--;
            cropTypeThree = carrotNum;
            currentCrop = threeCarrot.GetComponentInChildren<CropCoroutine>();
            field3.setCurrentCrop(currentCrop);
        }
    }

    private void threeCornButton()
    {
        if (ResourceManager.cornSeeds > zeroConst) {
            threeCarrot.SetActive(false);
            threeCorn.SetActive(true);
            threePumpkin.SetActive(false);
            threeTurnip.SetActive(false);
            threeTomato.SetActive(false);

            ResourceManager.cornSeeds--;
            cropTypeThree = cornNum;
            currentCrop = threeCorn.GetComponentInChildren<CropCoroutine>();
            field3.setCurrentCrop(currentCrop);
        }
    }

    private void threePumpkinButton()
    {
        if (ResourceManager.pumpkinSeeds > zeroConst) {
            threeCarrot.SetActive(false);
            threeCorn.SetActive(false);
            threePumpkin.SetActive(true);
            threeTurnip.SetActive(false);
            threeTomato.SetActive(false);

            ResourceManager.pumpkinSeeds--;
            cropTypeThree = pumpkinNum;
            currentCrop = threePumpkin.GetComponentInChildren<CropCoroutine>();
            field3.setCurrentCrop(currentCrop);
        }
    }

    private void threeTurnipButton()
    {
        if (ResourceManager.turnipSeeds > zeroConst) {
            threeCarrot.SetActive(false);
            threeCorn.SetActive(false);
            threePumpkin.SetActive(false);
            threeTurnip.SetActive(true);
            threeTomato.SetActive(false);

            ResourceManager.turnipSeeds--;
            cropTypeThree = turnipNum;
            currentCrop = threeTurnip.GetComponentInChildren<CropCoroutine>();
            field3.setCurrentCrop(currentCrop);
        }
    }

    private void threeTomatoButton()
    {
        if (ResourceManager.tomatoSeeds > zeroConst) {
            threeCarrot.SetActive(false);
            threeCorn.SetActive(false);
            threePumpkin.SetActive(false);
            threeTurnip.SetActive(false);
            threeTomato.SetActive(true);

            ResourceManager.tomatoSeeds--;
            cropTypeThree = tomatoNum;
            currentCrop = threeTomato.GetComponentInChildren<CropCoroutine>();
            field3.setCurrentCrop(currentCrop);
        }
    }

    //Field 4
    private void fourCarrotButton()
    {
        if (ResourceManager.carrotSeeds > zeroConst) {
            fourCarrot.SetActive(true);
            fourCorn.SetActive(false);
            fourPumpkin.SetActive(false);
            fourTurnip.SetActive(false);
            fourTomato.SetActive(false);

            ResourceManager.carrotSeeds--;
            cropTypeFour = carrotNum;
            currentCrop = fourCarrot.GetComponentInChildren<CropCoroutine>();
            field4.setCurrentCrop(currentCrop);
        }
    }

    private void fourCornButton()
    {
        if (ResourceManager.cornSeeds > zeroConst) {
            fourCarrot.SetActive(false);
            fourCorn.SetActive(true);
            fourPumpkin.SetActive(false);
            fourTurnip.SetActive(false);
            fourTomato.SetActive(false);

            ResourceManager.cornSeeds--;
            cropTypeFour = cornNum;
            currentCrop = fourCorn.GetComponentInChildren<CropCoroutine>();
            field4.setCurrentCrop(currentCrop);
        }
    }

    private void fourPumpkinButton()
    {
        if (ResourceManager.pumpkinSeeds > zeroConst) {
            fourCarrot.SetActive(false);
            fourCorn.SetActive(false);
            fourPumpkin.SetActive(true);
            fourTurnip.SetActive(false);
            fourTomato.SetActive(false);

            ResourceManager.pumpkinSeeds--;
            cropTypeFour = pumpkinNum;
            currentCrop = fourPumpkin.GetComponentInChildren<CropCoroutine>();
            field4.setCurrentCrop(currentCrop);
        }
    }

    private void fourTurnipButton()
    {
        if (ResourceManager.turnipSeeds > zeroConst) {
            fourCarrot.SetActive(false);
            fourCorn.SetActive(false);
            fourPumpkin.SetActive(false);
            fourTurnip.SetActive(true);
            fourTomato.SetActive(false);

            ResourceManager.turnipSeeds--;
            cropTypeFour = turnipNum;
            currentCrop = fourTurnip.GetComponentInChildren<CropCoroutine>();
            field4.setCurrentCrop(currentCrop);
        }
    }

    private void fourTomatoButton()
    {
        if (ResourceManager.tomatoSeeds > zeroConst) {
            fourCarrot.SetActive(false);
            fourCorn.SetActive(false);
            fourPumpkin.SetActive(false);
            fourTurnip.SetActive(false);
            fourTomato.SetActive(true);

            ResourceManager.tomatoSeeds--;
            cropTypeFour = tomatoNum;
            currentCrop = fourTomato.GetComponentInChildren<CropCoroutine>();
            field4.setCurrentCrop(currentCrop);
        }
    }

    // Disables all crops in a field
    public void disableField1()
    {
        oneCarrot.SetActive(false);
        oneCorn.SetActive(false);
        onePumpkin.SetActive(false);
        oneTurnip.SetActive(false);
        oneTomato.SetActive(false);
    }

    public void disableField2()
    {
        twoCarrot.SetActive(false);
        twoCorn.SetActive(false);
        twoPumpkin.SetActive(false);
        twoTurnip.SetActive(false);
        twoTomato.SetActive(false);
    }

    public void disableField3()
    {
        threeCarrot.SetActive(false);
        threeCorn.SetActive(false);
        threePumpkin.SetActive(false);
        threeTurnip.SetActive(false);
        threeTomato.SetActive(false);
    }

    public void disableField4()
    {
        fourCarrot.SetActive(false);
        fourCorn.SetActive(false);
        fourPumpkin.SetActive(false);
        fourTurnip.SetActive(false);
        fourTomato.SetActive(false);
    }

}
