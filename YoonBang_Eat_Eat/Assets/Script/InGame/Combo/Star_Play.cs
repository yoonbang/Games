using UnityEngine;
using System.Collections;

public class Star_Play : MonoBehaviour {
    //public int randomSecond;
	// Use this for initialization
	void Start () {
        /*randomSecond = Random.Range(8, 30);
        iTween.MoveTo(this.gameObject, iTween.Hash("y", 20.0f, "time", randomSecond));*/
        Destroy(this.gameObject, 7f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
