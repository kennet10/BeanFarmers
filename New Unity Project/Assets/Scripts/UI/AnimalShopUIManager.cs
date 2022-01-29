using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Kenneth Tang
public class AnimalShopUIManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    private AnimalSO[] animals;

    public void Start()
    {
        animals = Resources.LoadAll<AnimalSO>("Animal ScriptableObjects");
        for (int i = 0; i < animals.Length; i++)
        {
            GameObject button = Instantiate(buttonTemplate);
            button.SetActive(true);

            button.GetComponent<AnimalListButton>().SetUp(animals[i]);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
        Destroy(buttonTemplate);
    }
}
