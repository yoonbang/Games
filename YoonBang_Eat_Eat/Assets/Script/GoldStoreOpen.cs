using UnityEngine;
using System.Collections;

public class GoldStoreOpen : MonoBehaviour
{
    public GameObject goldStore;
    int buttonClick = 0;
    // Use this for initialization
    public void goldStoreOpen()
    {
        buttonClick += 1;
        if (buttonClick % 2 == 1)
        {
            goldStore.SetActive(true);
        }
        else
        {
            goldStore.SetActive(false);
            buttonClick = 0;
        }
    }
}
