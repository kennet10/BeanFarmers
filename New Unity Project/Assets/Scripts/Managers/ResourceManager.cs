using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Made by Haley Vlahos
public class ResourceManager : MonoBehaviour
{
    // Money by Kenneth Tang
    public static int money;
    [SerializeField] private TextMeshProUGUI moneyDisplay;

    //Crop and AnimalSOs by Kenneth Tang
    private AnimalSO[] animalSO;
    private CropSO[] cropSO;

    // Seeds
    public static int carrotSeeds;
    public static int cornSeeds;
    public static int pumpkinSeeds;
    public static int turnipSeeds;
    public static int tomatoSeeds;
    public static List<int> seeds = new List<int>{carrotSeeds, cornSeeds, pumpkinSeeds, turnipSeeds, tomatoSeeds};

    // Crops
    public static int carrots;
    public static int corn;
    public static int pumpkins;
    public static int tomatoes;
    public static int turnips;
    private static List<int> crops = new List<int> {carrots, corn, pumpkins, tomatoes, turnips};

    // Animal Products
    public static int eggs;
    public static int milk;
    public static int feathers;
    public static int bacon;
    public static int wool;
    private static List<int> animalProds = new List<int> {eggs, milk, feathers, bacon, wool};

    [SerializeField] private List<TextMeshProUGUI> counters = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> seedCounters = new List<TextMeshProUGUI>();
    private static List<int> displayRsrc = new List<int> {carrots, corn, pumpkins, tomatoes, turnips, eggs, milk , feathers, bacon, wool};

    [SerializeField] public Slider slide;

    //Get animal and cropSOs
    private void Start()
    {
        SetupResources();
        animalSO = Resources.LoadAll<AnimalSO>("Animal ScriptableObjects");
        cropSO = Resources.LoadAll<CropSO>("Crop ScriptableObjects");
    }

    // For game startup, sets all resources to 0 unless it is a seed, in which you are given 1
    public static void SetupResources()
    {
        money = 0;
        //Seeds
        carrotSeeds = 1;
        cornSeeds = 0;
        pumpkinSeeds = 0;
        turnipSeeds = 0;
        tomatoSeeds = 0;
        //Crops
        carrots = 0;
        corn = 0;
        pumpkins = 0;
        tomatoes = 0;
        turnips = 0;
        //Animal Products
        eggs = 0;
        milk = 0;
        feathers = 0;
        bacon = 0;
        wool = 0;
    }

    // Made by Kenneth Tang, sells all crops and animal products, sets their counters to 0
    public void SellAll()
    {
        updateLists();

        for (int i = 0; i < crops.Count; i++)
        {
            money += crops[i] * cropSO[i].GetSellCost();
        }
        for (int i = 0; i < animalProds.Count; i++)
        {
            money += animalProds[i] * animalSO[i].GetSellPrice();
        }
        //Crops
        carrots = 0;
        corn = 0;
        pumpkins = 0;
        tomatoes = 0;
        turnips = 0;
        //Animal Products
        eggs = 0;
        milk = 0;
        feathers = 0;
        bacon = 0;
        wool = 0;
    }


    // Updates each of the text counters to match the variables, both lists are in alphabetical order, if wool > 0, end the game!
    private void Update()
    {
        updateLists();
        displayRsrc = new List<int> {carrots, corn, pumpkins, tomatoes, turnips, eggs, milk, feathers, bacon, wool };
        if (counters.Count == displayRsrc.Count) {
            for(int i = 0; i < counters.Count; i++) {
                counters[i].text = displayRsrc[i].ToString();
            }
        }

        seeds = new List<int> { carrotSeeds, cornSeeds, pumpkinSeeds, turnipSeeds, tomatoSeeds };
        if (seedCounters.Count == seeds.Count) {
            for (int i = 0; i < seedCounters.Count; i++) {
                seedCounters[i].text = "Seeds: " + seeds[i].ToString();
            }
        }
        moneyDisplay.text = "$: " + money.ToString(); // Kenneth Tang

        if (wool > 0)
        {
            GameStateManager.EndGame();
        }
    }

    private void updateLists()
    {
        seeds = new List<int>{carrotSeeds, cornSeeds, pumpkinSeeds, turnipSeeds, tomatoSeeds};
        crops = new List<int> { carrots, corn, pumpkins, tomatoes, turnips };
        animalProds = new List<int> { eggs, milk, feathers, bacon, wool };
    }
}
