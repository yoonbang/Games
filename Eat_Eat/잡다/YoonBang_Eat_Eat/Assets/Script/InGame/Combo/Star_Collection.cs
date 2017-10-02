using UnityEngine;
using System.Collections;

public class Star_Collection : MonoBehaviour {
    public GameObject[] starCollection = new GameObject[3];
    // Use this for initialization
    public float fireRate = 0.1f;
    public float nextFire = 0.1f;
    public int randomIndex = 0;

    public Transform position;
    public GameObject star;
    void Start()
    {
        nextFire = Random.Range(1, 8);
        fireRate = Random.Range(1, 8);   
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
        fireRate = Random.Range(1, 8);
        randomIndex = Random.Range(0, 3);
        star = Instantiate(starCollection[randomIndex],Vector3.zero, Quaternion.identity) as GameObject;
        star.transform.SetParent(position.transform,false);
        star.transform.position = position.transform.position;
    }
}
