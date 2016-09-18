using UnityEngine;
using System.Collections;

public class FoodArrange : MonoBehaviour {
    int id = 0;
    public float nextRate = 0.2f;
    public float nextNode=0.0f;
    public GameObject red;
    public GameObject blue;
    public GameObject black;
    public GameObject yellow;

    void Update()
    {
        NodeCreate();
    }
    public void NodeCreate()
    {
        if (Time.time > nextNode)
        {
            nextNode = Time.time + nextRate;
            id = Random.Range(1, 5);
            Debug.Log(id);
            if (id == 1)
            {
                Instantiate(red, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            }
            if(id == 2)
            {
                Instantiate(blue, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            }
            if (id == 3)
            {
                Instantiate(black, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            }

            if (id == 4)
            {
                Instantiate(yellow, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            }

        }
    }
}
