using UnityEngine;
using System.Collections;

public class Title_Lobby : MonoBehaviour {
    public GPGSBtn GPGSBtn;
    // Use this for initialization
    void Start()
    {
        GPGSBtn = GameObject.Find("LoginManager").GetComponent<GPGSBtn>();
    }
    void Update () {
	  if (Input.GetMouseButtonDown(0))
      {
            GPGSBtn.ClickEvent();
            //Application.LoadLevel("InGame");
      }
	}
}
