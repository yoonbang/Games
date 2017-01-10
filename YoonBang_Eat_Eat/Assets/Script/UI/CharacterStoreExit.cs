using UnityEngine;
using System.Collections;

public class CharacterStoreExit : MonoBehaviour {

    public GameObject characterStore;
    CharacterStoreButton characterStoreButton;

    public void CharacterExit()
    {
        characterStoreButton = GameObject.Find("CharacterStoreButton").GetComponent<CharacterStoreButton>();
        characterStoreButton.buttonClick = 0;
        characterStore.SetActive(false);
    }
}
