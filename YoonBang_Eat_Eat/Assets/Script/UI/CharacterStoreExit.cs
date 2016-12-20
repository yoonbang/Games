using UnityEngine;
using System.Collections;

public class CharacterStoreExit : MonoBehaviour {

    public GameObject characterStore;

    public void CharacterExit()
    {
        characterStore.SetActive(false);
    }
}
