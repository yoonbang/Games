using UnityEngine;
using System.Collections;

public class Food_Dish_Rotation : MonoBehaviour {
    public GameObject food;
    public Transform food_Transform;

    public int stage = 1;
    public int food_Index = 0;

    Food_Gather food_Gather;
    Food food_1;
	// Use this for initialization
	void Awake () {
        food_Gather = GameObject.Find("Food_Gather").GetComponent<Food_Gather>();
        food_1 = GameObject.FindGameObjectWithTag("Food").GetComponent<Food>();
    }
    void Start()
    {
        food= Instantiate(food_Gather.food_Gather[food_Index]) as GameObject;
        food.transform.parent = food_Transform.transform;
        food.transform.position = food_Transform.position;

        food_Gather.food_Gather[food_Index].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Food_Change()
    {
        food_1.SetHealthBar();

        Destroy(food);

        stage++;
        food_Index++;
        food_Gather.food_Gather[food_Index].SetActive(true);

        food = Instantiate(food_Gather.food_Gather[food_Index]) as GameObject;
        food.transform.parent = food_Transform.transform;
        food.transform.position = food_Transform.position;

        food_Gather.food_Gather[food_Index].SetActive(false);

        food_1.Decreasehealth();
    }
}
