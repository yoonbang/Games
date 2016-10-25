using UnityEngine;
using System.Collections;

public class StateTabbarButton : MonoBehaviour {
    public GameObject StateLobby;
    int buttonClick = 0;

    public void StateLobbyViewOpen()
    {
        buttonClick += 1;

        if (buttonClick % 2 == 1)
        {
            StateLobby.SetActive(true);
        }
        else
        {
            StateLobby.SetActive(false);
            buttonClick = 0;
        }
          
    }
}
