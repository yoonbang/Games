using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{

    public float ScrollSpeed = 0.5f;
    float Target_Offset;
    public Renderer rend;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        Target_Offset += Time.deltaTime * ScrollSpeed;
        rend.material.mainTextureOffset = new Vector2(Target_Offset, 0);
    }
}
