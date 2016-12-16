using UnityEngine;
using System.Collections;

public class StateExit : MonoBehaviour {
    public GameObject stateLobby;
	
    public void StateLobbyExit()
    {
        stateLobby.SetActive(false);
    }
}
