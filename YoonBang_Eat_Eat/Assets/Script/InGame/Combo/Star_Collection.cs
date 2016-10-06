using UnityEngine;
using System.Collections;

public class Star_Collection : MonoBehaviour {
    public GameObject[] starCollection = new GameObject[3];
    // Use this for initialization
    public float fireRate = 0f;
    private float nextFire = 0.0f;
    public int randomIndex = 0;

    public Transform position;

    void Start()
    {
        nextFire = Random.Range(1, 10);
        fireRate = Random.Range(1, 10);
    }

    void Update()
    {
        if(Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            MakeStar();
        }
    }
    public void MakeStar()
    {
        fireRate = Random.Range(1, 10);
        randomIndex = Random.Range(0, 3);
        GameObject star = Instantiate(starCollection[randomIndex],Vector3.zero, Quaternion.identity) as GameObject;
        star.transform.SetParent(position.transform,false);
        star.transform.position = position.transform.position;
    }
}
