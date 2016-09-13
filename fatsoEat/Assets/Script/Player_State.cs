using UnityEngine;
using System.Collections;

public class Player_State : MonoBehaviour {

    public GameObject red;
    public GameObject blue;
    public GameObject black;
    public GameObject yellow;

    void Update()
    {
        Instantiate(red, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

    }
}
