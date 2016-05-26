using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
    public Camera camera;
    public GameObject player;

    public float speed = 0.5f;
    float cameraSize = 6f;

    public float MaxSize = 30f;
    public float Minsize = -6;
    void Update()
    {
        cameraSize = 6f + player.transform.position.y;

        if(cameraSize>=MaxSize)
        {
            cameraSize = MaxSize;
        }
        if(cameraSize<=Minsize)
        {
            cameraSize = Minsize;
        }
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraSize, Time.deltaTime / speed);
    }
}
