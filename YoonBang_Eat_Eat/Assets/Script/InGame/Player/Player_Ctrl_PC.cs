using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum PlayerState1
{
    Idle,
    Skill,
    Combo,
    Eat,
    SuperMode,
}

public class Player_Ctrl_PC : MonoBehaviour
{
    SmallFood_Setting smallFood_Setting;
    SmallFood_Food_Menu smallFood_Food_Menu;
    Dish_Node_Id dish_Node_Id;
    SmallFood_Dish_Id smallFood_Dish_Id;
    MainFood_Setting mainFood_Setting;
    Combo_System combo_system;


    int layerMask;

    public string DishLayer = "Dish";
    public string SkillLayer = "Skill";
    // Use this for initialization

    public int combo_Count=1;
    public float power=10.0f;
    void Awake()
    {
        smallFood_Setting = GameObject.FindGameObjectWithTag("SmallMenu_Setting").GetComponent<SmallFood_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        combo_system = GameObject.FindGameObjectWithTag("Combo_System").GetComponent<Combo_System>();
        layerMask = LayerMask.GetMask(DishLayer, SkillLayer);
    }

    // Update is called once per frame
    void Update()
    {
        MouseButtonClick();
    }
    public void MouseButtonClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f, layerMask))
            {
                int layer = hitInfo.transform.gameObject.layer;
                dish_Node_Id = hitInfo.collider.transform.GetComponent<Dish_Node_Id>();
                smallFood_Dish_Id = GameObject.FindGameObjectWithTag("SmallFood").GetComponent<SmallFood_Dish_Id>();

                //Debug.Log("Dish_Node_Id="); Debug.Log(dish_Node_Id.id);
                //Debug.Log("smallFood_Dish_Id="); Debug.Log(smallFood_Dish_Id.id);
                if (layer == LayerMask.NameToLayer(DishLayer) && dish_Node_Id.id == smallFood_Dish_Id.id)
                {
                    combo_Count += 1;
                    Destroy(smallFood_Setting.smallFood_Index[0]);
                    mainFood_Setting.GetComponentInChildren<MainFood>().Damage();
                    combo_system.combo_Strike();
                }
                if (layer == LayerMask.NameToLayer(DishLayer) && dish_Node_Id.id != smallFood_Dish_Id.id)
                {
                    mainFood_Setting.GetComponentInChildren<MainFood>().Damage();
                    mainFood_Setting.GetComponentInChildren<MainFood>().Heal();
                    combo_Count = 0;
                }
            }
        }

        if(smallFood_Setting.smallFood_Index[0]==null)
        {
            smallFood_Setting.smallFood_Index[0] = Instantiate(smallFood_Setting.smallFood_Index[1]) as GameObject;
            smallFood_Setting.smallFood_Index[0].transform.parent= smallFood_Setting.smallfood_Postion.smallFood_Position[0].transform;
            smallFood_Setting.smallFood_Index[0].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[0].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[1]);
            smallFood_Setting.smallFood_Index[1] = Instantiate(smallFood_Setting.smallFood_Index[2]) as GameObject;
            smallFood_Setting.smallFood_Index[1].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[1].transform;
            smallFood_Setting.smallFood_Index[1].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[1].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[2]);
            smallFood_Setting.smallFood_Index[2] = Instantiate(smallFood_Setting.smallFood_Index[3]) as GameObject;
            smallFood_Setting.smallFood_Index[2].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[2].transform;
            smallFood_Setting.smallFood_Index[2].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[2].transform.position;


            Destroy(smallFood_Setting.smallFood_Index[3]);
            smallFood_Setting.smallFood_Index[3] = Instantiate(smallFood_Setting.smallFood_Index[4]) as GameObject;
            smallFood_Setting.smallFood_Index[3].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[3].transform;
            smallFood_Setting.smallFood_Index[3].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[3].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[4]);
            smallFood_Setting.smallFood_Index[4] = Instantiate(smallFood_Setting.smallFood_Index[5]) as GameObject;
            smallFood_Setting.smallFood_Index[4].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[4].transform;
            smallFood_Setting.smallFood_Index[4].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[4].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[5]);
            smallFood_Setting.smallFood_Index[5] = Instantiate(smallFood_Setting.smallFood_Index[6]) as GameObject;
            smallFood_Setting.smallFood_Index[5].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[5].transform;
            smallFood_Setting.smallFood_Index[5].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[5].transform.position;

            int randomFood = Random.Range(1, 5);

            if(randomFood == 1)
            {
                Destroy(smallFood_Setting.smallFood_Index[6]);
                smallFood_Setting.smallFood_Index[6] = Instantiate(smallFood_Setting.small_Red_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[6].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform;
                smallFood_Setting.smallFood_Index[6].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform.position;
                smallFood_Setting.smallFood_Index[6].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
            if (randomFood == 2)
            {
                Destroy(smallFood_Setting.smallFood_Index[6]);
                smallFood_Setting.smallFood_Index[6] = Instantiate(smallFood_Setting.small_Blue_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[6].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform;
                smallFood_Setting.smallFood_Index[6].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform.position;
                smallFood_Setting.smallFood_Index[6].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
            if (randomFood == 3)
            {
                Destroy(smallFood_Setting.smallFood_Index[6]);
                smallFood_Setting.smallFood_Index[6] = Instantiate(smallFood_Setting.small_Yellow_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[6].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform;
                smallFood_Setting.smallFood_Index[6].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform.position;
                smallFood_Setting.smallFood_Index[6].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
            if (randomFood == 4)
            {
                Destroy(smallFood_Setting.smallFood_Index[6]);
                smallFood_Setting.smallFood_Index[6] = Instantiate(smallFood_Setting.small_Green_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[6].transform.parent = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform;
                smallFood_Setting.smallFood_Index[6].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform.position;
                smallFood_Setting.smallFood_Index[6].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
        }
    }
}
