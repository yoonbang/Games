using UnityEngine;
using System.Collections;

public class Red_Fly : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Red_Fly"), "time", 2));
	}
	
}
