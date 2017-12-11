using UnityEngine;
using System.Collections;

public class StateTabbarButton : MonoBehaviour {
    public GameObject StateLobby;
    public GameObject another1, another2, another3;
    public int buttonClick = 0;
    CharacterStoreButton characterStoreButton;
    TheDishesStore theDishesTabbarButton;
    GoldStoreOpen goldStoreOpen;
    public void StateLobbyViewOpen()
    {
        buttonClick += 1;

        if (buttonClick % 2 == 1)
        {
            StateLobby.SetActive(true);
            another1.SetActive(false);
            another2.SetActive(false);
            another3.SetActive(false);
            theDishesTabbarButton = GameObject.Find("TheDishesTabbarButton").GetComponent<TheDishesStore>();
            theDishesTabbarButton.buttonClick = 0;
            characterStoreButton = GameObject.Find("CharacterStoreButton").GetComponent<CharacterStoreButton>();
            characterStoreButton.buttonClick = 0;
            goldStoreOpen = GameObject.Find("GoldStoreButton").GetComponent<GoldStoreOpen>();
            goldStoreOpen.buttonClick = 0;
        }
        else
        {
            StateLobby.SetActive(false);
            buttonClick = 0;
        }
     } 
}
