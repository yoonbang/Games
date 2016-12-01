using UnityEngine;
using System.Collections;

public class RenderImage : MonoBehaviour {
    public Sprite Image;
    public CharacterRender cr;
    // Use this for initialization
    void Start()
    {
        cr = GameObject.FindGameObjectWithTag("PlayerRender").GetComponent<CharacterRender>();
    }
    public void RenderChange()
    {
        cr.spriteRender.sprite = Image;
    }
}
