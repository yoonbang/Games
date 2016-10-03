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
public class Player_Ctrl : MonoBehaviour
{
    SmallFood_Setting smallFood_Setting;
    Dish_Node_Id dish_Node_Id;
    SmallFood_Dish_Id smallFood_Dish_Id;

    int layerMask;

    public string DishLayer = "Dish";
    public string SkillLayer = "Skill";

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    // Use this for initialization
    void Start()
    {
        smallFood_Setting = GameObject.FindGameObjectWithTag("SmallMenu_Setting").GetComponent<SmallFood_Setting>();
    }
    void Awake()
    {
        layerMask = LayerMask.GetMask(DishLayer, SkillLayer);
    }

    // Update is called once per frame
    void Update()
    {
        MouseButtonClick();
    }
    public void MouseButtonClick()
    {
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 100f, layerMask))
                {
                    int layer = hitInfo.transform.gameObject.layer;

                    GameObject recipient = hitInfo.transform.gameObject;
                    touchList.Add(recipient);

                    dish_Node_Id = hitInfo.collider.transform.GetComponent<Dish_Node_Id>();
                    smallFood_Dish_Id = GameObject.FindGameObjectWithTag("SmallFood").GetComponent<SmallFood_Dish_Id>();


                    if (touch.phase == TouchPhase.Began && layer == LayerMask.NameToLayer(DishLayer) && dish_Node_Id.id == smallFood_Dish_Id.id)
                    {

                        Destroy(smallFood_Setting.smallFood_Index[0]);

                    }
                }
            }
        }
    }
}
