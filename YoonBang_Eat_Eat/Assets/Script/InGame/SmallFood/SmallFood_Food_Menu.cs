using UnityEngine;
using System.Collections;

public class SmallFood_Food_Menu : MonoBehaviour {
    SmallFood_Collection smallFood_Collection;
    public GameObject food;
    public Transform food_Position;
    public int foodrandomIndexMax;
    public int randomFood = 0;
    // Use this for initialization
    void Start () {
        smallFood_Collection = GameObject.FindGameObjectWithTag("SmallFood_Collection").GetComponent<SmallFood_Collection>();
        //FoodSetting();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void FoodSetting()
    {
        smallFood_Collection = GameObject.FindGameObjectWithTag("SmallFood_Collection").GetComponent<SmallFood_Collection>();
        foodrandomIndexMax = smallFood_Collection.smallFood_Menu.Length;
        randomFood = Random.Range(0, foodrandomIndexMax);

        food = Instantiate(smallFood_Collection.smallFood_Menu[randomFood]) as GameObject;
        food.transform.SetParent(food_Position.transform, false);
        food.transform.position = food_Position.transform.position;

        /*if (randomIndex == 0)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.SetParent(food_Position.transform,false);
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 1)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.SetParent(food_Position.transform, false);
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 2)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.SetParent(food_Position.transform, false);
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 3)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.SetParent(food_Position.transform, false);
            food.transform.position = food_Position.transform.position;
        }
        if (randomIndex == 4)
        {
            food = Instantiate(smallFood_Collection.smallFood_Menu[randomIndex]) as GameObject;
            food.transform.SetParent(food_Position.transform, false);
            food.transform.position = food_Position.transform.position;
        }*/
    }
}
