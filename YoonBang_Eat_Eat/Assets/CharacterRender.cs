using UnityEngine;
using System.Collections;

public class CharacterRender : MonoBehaviour {
    public Sprite Image;
    public SpriteRenderer spriteRender;
	// Use this for initialization
	void Start () {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
