using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public float smothrate = 0.5f;
    private Transform thisTransform;
    public Vector2 velocity;


    // Use this for initialization
    void Start()
    {
        thisTransform = transform;
        velocity = new Vector2(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= 17.0f)
        {
            NeolttwigiCamera();
        }
        else
        {
            IdleCamere();
        }
    }

    public void NeolttwigiCamera()
    {
        Vector2 newPos2D = Vector2.zero;
        newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, player.position.x, ref velocity.x, smothrate);
        newPos2D.y = Mathf.SmoothDamp(thisTransform.position.y, player.position.y, ref velocity.y, smothrate);

        Vector3 newPos = new Vector3(newPos2D.x + 9f, newPos2D.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
    }

    public void IdleCamere()
    {
        Vector2 newPos2D = Vector2.zero;
        newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, player.position.x, ref velocity.x, smothrate);
        newPos2D.y = 3.0f;

        Vector3 newPos = new Vector3(newPos2D.x + 9f, newPos2D.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
    }
}

