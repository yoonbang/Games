using UnityEngine;
using System.Collections;

public class GoldTreasureExit : MonoBehaviour {
    public GameObject goldTreasureExit;

    public void GoldTreasureOut()
    {
        goldTreasureExit.SetActive(false);
    }
}
