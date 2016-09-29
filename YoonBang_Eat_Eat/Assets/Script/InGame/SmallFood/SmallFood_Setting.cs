using UnityEngine;
using System.Collections;

public class SmallFood_Setting : MonoBehaviour
{
    public GameObject small_Red_Dish, small_Blue_Dish, small_Yellow_Dish, small_Green_Dish;
    public GameObject[] smallFood_Index = new GameObject[7];
    int randomIndex=0;
    int foodCount=0;

    public SmallFood_Position smallfood_Postion;
    // Use this for initialization
    void Start()
    {
        foodCount = smallFood_Index.Length;
        smallfood_Postion = GameObject.FindGameObjectWithTag("SmallFood_Position").GetComponent<SmallFood_Position>();
        FoodSetting();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FoodSetting()
    {
        for (int index = 0; index < foodCount; index++)
        {
            randomIndex = Random.Range(1, 5);

            if(randomIndex==1)
            {
                smallFood_Index[index] = Instantiate(small_Red_Dish) as GameObject;
                smallFood_Index[index].transform.parent = smallfood_Postion.smallFood_Position[index].transform;
                smallFood_Index[index].transform.position = smallfood_Postion.smallFood_Position[index].transform.position;
            }
            if (randomIndex == 2)
            {
                smallFood_Index[index] = Instantiate(small_Blue_Dish) as GameObject;
                smallFood_Index[index].transform.parent = smallfood_Postion.smallFood_Position[index].transform;
                smallFood_Index[index].transform.position = smallfood_Postion.smallFood_Position[index].transform.position;
            }
            if (randomIndex == 3)
            {
                smallFood_Index[index] = Instantiate(small_Yellow_Dish) as GameObject;
                smallFood_Index[index].transform.parent = smallfood_Postion.smallFood_Position[index].transform;
                smallFood_Index[index].transform.position = smallfood_Postion.smallFood_Position[index].transform.position;
            }
            if (randomIndex == 4)
            {
                smallFood_Index[index] = Instantiate(small_Green_Dish) as GameObject;
                smallFood_Index[index].transform.parent = smallfood_Postion.smallFood_Position[index].transform;
                smallFood_Index[index].transform.position = smallfood_Postion.smallFood_Position[index].transform.position;
            }
        }
    }
}
