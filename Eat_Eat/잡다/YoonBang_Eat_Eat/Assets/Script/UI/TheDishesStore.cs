using UnityEngine;
using System.Collections;

public class TheDishesStore : MonoBehaviour {

    public GameObject theDishesStore;
    public GameObject another1, another2, another3;
    public int buttonClick = 0;

    StateTabbarButton stateTabbarButton;
    CharacterStoreButton characterStoreButton;
    GoldStoreOpen goldStoreOpen;
    // Use this for initialization
    public void theDishesStoreOpen()
    {
        buttonClick += 1;
        if (buttonClick % 2 == 1)
        {
            theDishesStore.SetActive(true);
            another1.SetActive(false);
            another2.SetActive(false);
            another3.SetActive(false);

            stateTabbarButton = GameObject.Find("StateTabbarButton").GetComponent<StateTabbarButton>();
            stateTabbarButton.buttonClick = 0;
            characterStoreButton = GameObject.Find("CharacterStoreButton").GetComponent<CharacterStoreButton>();
            characterStoreButton.buttonClick = 0;
            goldStoreOpen = GameObject.Find("GoldStoreButton").GetComponent<GoldStoreOpen>();
            goldStoreOpen.buttonClick = 0;
        }
        else
        {
            theDishesStore.SetActive(false);
            buttonClick = 0;
        }
    }
}
