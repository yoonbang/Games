using UnityEngine;
using System.Collections;

public class CharacterStoreButton : MonoBehaviour {

    public GameObject CharacterStoreLobby;
    public int buttonClick = 0;
    public GameObject another1, another2, another3;

    TheDishesStore theDishesTabbarButton;
    GoldStoreOpen goldStoreOpen;
    StateTabbarButton stateTabbarButton;

    public void CharacterStoreLobbyViewOpen()
    {
        buttonClick += 1;

        if (buttonClick % 2 == 1)
        {
            CharacterStoreLobby.SetActive(true);
            another1.SetActive(false);
            another2.SetActive(false);
            another3.SetActive(false);

            stateTabbarButton = GameObject.Find("StateTabbarButton").GetComponent<StateTabbarButton>();
            stateTabbarButton.buttonClick = 0;
            goldStoreOpen = GameObject.Find("GoldStoreButton").GetComponent<GoldStoreOpen>();
            goldStoreOpen.buttonClick = 0;
            theDishesTabbarButton = GameObject.Find("TheDishesTabbarButton").GetComponent<TheDishesStore>();
            theDishesTabbarButton.buttonClick = 0;

        }
        else
        {
            CharacterStoreLobby.SetActive(false);
            buttonClick = 0;
        }

    }
}
