using UnityEngine;
using System.Collections;

public class SmallFood_Food_Menu : MonoBehaviour {
    SmallFood_Collection smallFood_Collection;
    public GameObject food;
    public Transform food_Position;
    int randomIndex = 0;
    // Use this for initialization
    void Start () {
        smallFood_Collection = GameObject.FindGameObjectWithTag("SmallFood_Collection").GetComponent<SmallFood_Collection>();
        FoodSetting();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void FoodSetting()
    {
        randomIndex = Random.Range(0, 5);

        if (randomIndex == 0)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.parent = food_Position.transform;
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 1)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.parent = food_Position.transform;
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 2)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.parent = food_Position.transform;
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 3)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.parent = food_Position.transform;
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 4)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.parent = food_Position.transform;
            food.transform.position = food_Position.transform.position;
        }
    }
}
