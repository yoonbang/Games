using UnityEngine;
using System.Collections;

public class Star_Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(this.gameObject, iTween.Hash("y", 15.0f, "time", 10.0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
