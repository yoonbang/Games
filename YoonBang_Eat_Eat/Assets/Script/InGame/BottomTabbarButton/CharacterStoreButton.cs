using UnityEngine;
using System.Collections;

public class CharacterStoreButton : MonoBehaviour {

    public GameObject CharacterStoreLobby;
    int buttonClick = 0;

    public void CharacterStoreLobbyViewOpen()
    {
        buttonClick += 1;

        if (buttonClick % 2 == 1)
        {
            CharacterStoreLobby.SetActive(true);
        }
        else
        {
            CharacterStoreLobby.SetActive(false);
            buttonClick = 0;
        }

    }
}
