using UnityEngine;
using System.Collections;

public class LoadingButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ButtonClick()
    {
        Debug.Log("앙");
        Application.LoadLevel("InGame");
    }
}
