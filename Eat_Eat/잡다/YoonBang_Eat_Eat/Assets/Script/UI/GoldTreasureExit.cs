using UnityEngine;
using System.Collections;

public class GoldTreasureExit : MonoBehaviour {
    public GameObject goldTreasureExit;
    GoldStoreOpen goldStoreOpen;

    public void GoldTreasureOut()
    {
        goldStoreOpen = GameObject.Find("GoldStoreButton").GetComponent<GoldStoreOpen>();
        goldStoreOpen.buttonClick = 0;
        goldTreasureExit.SetActive(false);
    }
}
