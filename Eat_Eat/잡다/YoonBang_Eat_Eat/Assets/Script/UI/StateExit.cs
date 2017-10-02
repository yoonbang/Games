using UnityEngine;
using System.Collections;

public class StateExit : MonoBehaviour {
    public GameObject stateLobby;
    StateTabbarButton stateTabbarButton;

    public void StateLobbyExit()
    {
        stateTabbarButton= GameObject.Find("StateTabbarButton").GetComponent<StateTabbarButton>();
        stateTabbarButton.buttonClick = 0;
        stateLobby.SetActive(false);
    }
}
