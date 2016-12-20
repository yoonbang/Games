using UnityEngine;
using System.Collections;

public class GameOutNo : MonoBehaviour {

    public GameObject gameOut;

    public void GameOut()
    {
        gameOut.SetActive(false);
    }
}
