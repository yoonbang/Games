using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    public Color defaultColor;
    public Color selectedColor;
    private Material mat;
	// Use this for initialization
	void Start () {
        mat = gameObject.GetComponent<Renderer>().material;
	}

	// Update is called once per frame


    void OnTouchDown()
    {
        mat.color = selectedColor;
    }
    void OnTouchUp()
    {
        mat.color = defaultColor;
    }
    void OnTouchStay()
    {
        mat.color = selectedColor;
    }
    void OnTouchExit()
    {
        mat.color = defaultColor;
    }
}
