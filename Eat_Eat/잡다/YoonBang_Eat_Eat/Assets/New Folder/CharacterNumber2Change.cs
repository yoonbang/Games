using UnityEngine;
using System.Collections;

public class CharacterNumber2Change : MonoBehaviour {
    Player_Ctrl_PC player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();

    }
	
	public void ButtonClick()
    {

    }
}
