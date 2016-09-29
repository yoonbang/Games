using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    Dish_Node_Id dish_Node_Id;
    SmallFood_Dish_Id smallFood_Dish_Id;

    int layerMask;

    public string DishLayer = "Dish";
    public string SkillLayer = "Skill";

    int dishid;
    int nodeid;

    // Use this for initialization
    void Start()
    {
        //smallFood_Setting = GameObject.FindGameObjectWithTag("SmallMenu_Setting").GetComponent<SmallFood_Setting>();
    }
    void Awake()
    {
        smallFood_Setting = GameObject.FindGameObjectWithTag("SmallMenu_Setting").GetComponent<SmallFood_Setting>();
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

                if (layer == LayerMask.NameToLayer(DishLayer) && dish_Node_Id.id == smallFood_Dish_Id.id)
                {

                    Destroy(smallFood_Setting.smallFood_Index[0]);
                    
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
        }
    }
}
