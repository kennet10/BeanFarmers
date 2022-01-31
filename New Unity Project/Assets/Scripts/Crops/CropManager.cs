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
        oneCarrot.SetActive(true);
        oneCorn.SetActive(false);
        onePumpkin.SetActive(false);
        oneTurnip.SetActive(false);
        oneTomato.SetActive(false);
        currentCrop = oneCarrot.GetComponentInChildren<CropCoroutine>();
        field1.setCurrentCrop(currentCrop);
    }

    private void oneCornButton()
    {
        oneCarrot.SetActive(false);
        oneCorn.SetActive(true);
        onePumpkin.SetActive(false);
        oneTurnip.SetActive(false);
        oneTomato.SetActive(false);
        currentCrop = oneCorn.GetComponentInChildren<CropCoroutine>();
        field1.setCurrentCrop(currentCrop);
    }

    private void onePumpkinButton()
    {
        oneCarrot.SetActive(false);
        oneCorn.SetActive(false);
        onePumpkin.SetActive(true);
        oneTurnip.SetActive(false);
        oneTomato.SetActive(false);
        currentCrop = onePumpkin.GetComponentInChildren<CropCoroutine>();
        field1.setCurrentCrop(currentCrop);
    }

    private void oneTurnipButton()
    {
        oneCarrot.SetActive(false);
        oneCorn.SetActive(false);
        onePumpkin.SetActive(false);
        oneTurnip.SetActive(true);
        oneTomato.SetActive(false);
        currentCrop = oneTurnip.GetComponentInChildren<CropCoroutine>();
        field1.setCurrentCrop(currentCrop);
    }

    private void oneTomatoButton()
    {
        oneCarrot.SetActive(false);
        oneCorn.SetActive(false);
        onePumpkin.SetActive(false);
        oneTurnip.SetActive(false);
        oneTomato.SetActive(true);
        currentCrop = oneTomato.GetComponentInChildren<CropCoroutine>();
        field1.setCurrentCrop(currentCrop);
    }

    // Field 2
    private void twoCarrotButton()
    {
        twoCarrot.SetActive(true);
        twoCorn.SetActive(false);
        twoPumpkin.SetActive(false);
        twoTurnip.SetActive(false);
        twoTomato.SetActive(false);
        currentCrop = twoCarrot.GetComponentInChildren<CropCoroutine>();
        field2.setCurrentCrop(currentCrop);
    }

    private void twoCornButton()
    {
        twoCarrot.SetActive(false);
        twoCorn.SetActive(true);
        twoPumpkin.SetActive(false);
        twoTurnip.SetActive(false);
        twoTomato.SetActive(false);
        currentCrop = twoCorn.GetComponentInChildren<CropCoroutine>();
        field2.setCurrentCrop(currentCrop);
    }

    private void twoPumpkinButton()
    {
        twoCarrot.SetActive(false);
        twoCorn.SetActive(false);
        twoPumpkin.SetActive(true);
        twoTurnip.SetActive(false);
        twoTomato.SetActive(false);
        currentCrop = twoPumpkin.GetComponentInChildren<CropCoroutine>();
        field2.setCurrentCrop(currentCrop);
    }

    private void twoTurnipButton()
    {
        twoCarrot.SetActive(false);
        twoCorn.SetActive(false);
        twoPumpkin.SetActive(false);
        twoTurnip.SetActive(true);
        twoTomato.SetActive(false);
        currentCrop = twoTurnip.GetComponentInChildren<CropCoroutine>();
        field2.setCurrentCrop(currentCrop);
    }

    private void twoTomatoButton()
    {
        twoCarrot.SetActive(false);
        twoCorn.SetActive(false);
        twoPumpkin.SetActive(false);
        twoTurnip.SetActive(false);
        twoTomato.SetActive(true);
        currentCrop = twoTomato.GetComponentInChildren<CropCoroutine>();
        field2.setCurrentCrop(currentCrop);
    }

    //Field 3
    private void threeCarrotButton()
    {
        threeCarrot.SetActive(true);
        threeCorn.SetActive(false);
        threePumpkin.SetActive(false);
        threeTurnip.SetActive(false);
        threeTomato.SetActive(false);
        currentCrop = threeCarrot.GetComponentInChildren<CropCoroutine>();
        field3.setCurrentCrop(currentCrop);
    }

    private void threeCornButton()
    {
        threeCarrot.SetActive(false);
        threeCorn.SetActive(true);
        threePumpkin.SetActive(false);
        threeTurnip.SetActive(false);
        threeTomato.SetActive(false);
        currentCrop = threeCorn.GetComponentInChildren<CropCoroutine>();
        field3.setCurrentCrop(currentCrop);
    }

    private void threePumpkinButton()
    {
        threeCarrot.SetActive(false);
        threeCorn.SetActive(false);
        threePumpkin.SetActive(true);
        threeTurnip.SetActive(false);
        threeTomato.SetActive(false);
        currentCrop = threePumpkin.GetComponentInChildren<CropCoroutine>();
        field3.setCurrentCrop(currentCrop);
    }

    private void threeTurnipButton()
    {
        threeCarrot.SetActive(false);
        threeCorn.SetActive(false);
        threePumpkin.SetActive(false);
        threeTurnip.SetActive(true);
        threeTomato.SetActive(false);
        currentCrop = threeTurnip.GetComponentInChildren<CropCoroutine>();
        field3.setCurrentCrop(currentCrop);
    }

    private void threeTomatoButton()
    {
        threeCarrot.SetActive(false);
        threeCorn.SetActive(false);
        threePumpkin.SetActive(false);
        threeTurnip.SetActive(false);
        threeTomato.SetActive(true);
        currentCrop = threeTomato.GetComponentInChildren<CropCoroutine>();
        field3.setCurrentCrop(currentCrop);
    }

    //Field 4
    private void fourCarrotButton()
    {
        fourCarrot.SetActive(true);
        fourCorn.SetActive(false);
        fourPumpkin.SetActive(false);
        fourTurnip.SetActive(false);
        fourTomato.SetActive(false);
        currentCrop = fourCarrot.GetComponentInChildren<CropCoroutine>();
        field4.setCurrentCrop(currentCrop);
    }

    private void fourCornButton()
    {
        fourCarrot.SetActive(false);
        fourCorn.SetActive(true);
        fourPumpkin.SetActive(false);
        fourTurnip.SetActive(false);
        fourTomato.SetActive(false);
        currentCrop = fourCorn.GetComponentInChildren<CropCoroutine>();
        field4.setCurrentCrop(currentCrop);
    }

    private void fourPumpkinButton()
    {
        fourCarrot.SetActive(false);
        fourCorn.SetActive(false);
        fourPumpkin.SetActive(true);
        fourTurnip.SetActive(false);
        fourTomato.SetActive(false);
        currentCrop = fourPumpkin.GetComponentInChildren<CropCoroutine>();
        field4.setCurrentCrop(currentCrop);
    }

    private void fourTurnipButton()
    {
        fourCarrot.SetActive(false);
        fourCorn.SetActive(false);
        fourPumpkin.SetActive(false);
        fourTurnip.SetActive(true);
        fourTomato.SetActive(false);
        currentCrop = fourTurnip.GetComponentInChildren<CropCoroutine>();
        field4.setCurrentCrop(currentCrop);
    }

    private void fourTomatoButton()
    {
        fourCarrot.SetActive(false);
        fourCorn.SetActive(false);
        fourPumpkin.SetActive(false);
        fourTurnip.SetActive(false);
        fourTomato.SetActive(true);
        currentCrop = fourTomato.GetComponentInChildren<CropCoroutine>();
        field4.setCurrentCrop(currentCrop);
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
