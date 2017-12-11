using UnityEngine;
using System.Collections;

public class GoldStoreOpen : MonoBehaviour
{
    public GameObject goldStore;
    public int buttonClick = 0;
    public GameObject another1, another2, another3;

    CharacterStoreButton characterStoreButton;
    TheDishesStore theDishesTabbarButton;
    StateTabbarButton stateTabbarButton;
    // Use this for initialization
    public void goldStoreOpen()
    {
        buttonClick += 1;
        if (buttonClick % 2 == 1)
        {
            goldStore.SetActive(true);
            another1.SetActive(false);
            another2.SetActive(false);
            another3.SetActive(false);
            stateTabbarButton = GameObject.Find("StateTabbarButton").GetComponent<StateTabbarButton>();
            stateTabbarButton.buttonClick = 0;
            characterStoreButton = GameObject.Find("CharacterStoreButton").GetComponent<CharacterStoreButton>();
            characterStoreButton.buttonClick = 0;
            theDishesTabbarButton = GameObject.Find("TheDishesTabbarButton").GetComponent<TheDishesStore>();
            theDishesTabbarButton.buttonClick = 0;
        }
        else
        {
            goldStore.SetActive(false);
            buttonClick = 0;
        }
    }
}
