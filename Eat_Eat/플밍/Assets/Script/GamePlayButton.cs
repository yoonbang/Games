using UnityEngine;
using System.Collections;

public class GamePlayButton : MonoBehaviour {

	public void OnMouseButtonClick()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Stage1");
    }
}
