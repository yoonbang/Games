using UnityEngine;
using System.Collections;

public class TheDishesExit : MonoBehaviour {
    public GameObject theDishesLobby;
    TheDishesStore theDishesTabbarButton;

    public void TheDishesLobbyExit()
    {
        theDishesTabbarButton = GameObject.Find("TheDishesTabbarButton").GetComponent<TheDishesStore>();
        theDishesTabbarButton.buttonClick = 0;
        theDishesLobby.SetActive(false);
    }
}
