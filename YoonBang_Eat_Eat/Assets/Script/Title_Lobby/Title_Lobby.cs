using UnityEngine;
using System.Collections;

public class Title_Lobby : MonoBehaviour {

	// Use this for initialization
	void Update () {
	  if (Input.GetMouseButtonDown(0))
      {
            Application.LoadLevel("InGame");
      }
	}
}
