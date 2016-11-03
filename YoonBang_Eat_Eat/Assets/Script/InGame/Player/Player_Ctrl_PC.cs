using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum PlayerState
{
    Idle,
    Skill,
    Combo,
    Eat,
    SuperMode,
    False,
}

public class Player_Ctrl_PC : MonoBehaviour
{
    SmallFood_Setting smallFood_Setting;
    SmallFood_Food_Menu smallFood_Food_Menu;
    Dish_Node_Id dish_Node_Id;
    SmallFood_Dish_Id smallFood_Dish_Id;
    MainFood_Setting mainFood_Setting;
    Combo_System combo_system;

    public PlayerState ps;
    int layerMask;

    public string DishLayer = "Dish";
    public string SkillLayer = "Skill";
    // Use this for initialization

    public int combo_Count=1;
    public float power=10.0f;

    public float superComboMode_Count = 1f;
    public float maxCombo = 20f;
    public AudioClip eat_Sound;

    public GameObject eat_Effect;
    public Transform eat_Transform;
    public StageManager stage;

    public Text goldText;
    public int level;
    public int gold;

    

    void Awake()
    {
        smallFood_Setting = GameObject.FindGameObjectWithTag("SmallMenu_Setting").GetComponent<SmallFood_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        combo_system = GameObject.FindGameObjectWithTag("Combo_System").GetComponent<Combo_System>();
        stage = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
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
                    if (ps == PlayerState.Combo)
                    {
                        Combo_Mode();
                    }
                    else {
                        ps = PlayerState.Eat;
                        Eat_Mode();
                    }
                }
                if (layer == LayerMask.NameToLayer(DishLayer) && dish_Node_Id.id != smallFood_Dish_Id.id)
                {
                    if (ps == PlayerState.Combo)
                    {
                        Combo_Mode();
                    }
                    else {
                        ps = PlayerState.False;
                        Flase_Mode();
                    }
                }
                //if (layer==LayerMask.NameToLayer(DishLayer) && superComboMode_Count == 20)
                if(superComboMode_Count>=20)
                {
                    if (ps != PlayerState.Skill)
                    {
                        ps = PlayerState.Combo;
                    }
                }
            }
        }

        if(smallFood_Setting.smallFood_Index[0]==null)
        {
            smallFood_Setting.smallFood_Index[0] = Instantiate(smallFood_Setting.smallFood_Index[1]) as GameObject;
            smallFood_Setting.smallFood_Index[0].transform.parent= smallFood_Setting.smallfood_Postion.smallFood_Position[0].transform;
            smallFood_Setting.smallFood_Index[0].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[00].transform.position;

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
    public void Combo_Mode()
    {
        if(ps==PlayerState.Combo)
        {
            Food_Shot();
            Destroy(smallFood_Setting.smallFood_Index[0]);
            mainFood_Setting.GetComponentInChildren<MainFood>().Damage();
            combo_Count += 1;
            int randomGold = Random.Range(stage.stageCount, stage.stageCount+stage.stageCount);
            gold = gold + randomGold;
            goldText.text = gold.ToString();
            GetComponent<AudioSource>().clip = eat_Sound;
            GetComponent<AudioSource>().Play();
            eat_Effect=Instantiate(Resources.Load("Eat_Effect"), Vector3.zero, Quaternion.identity) as GameObject;
            eat_Effect.transform.SetParent(eat_Transform.transform);
            eat_Effect.transform.position = eat_Transform.transform.position;
            combo_system.Combo_Mode();
        }
    }
    public void Eat_Mode()
    {
        if(ps == PlayerState.Eat)
        {
            if(superComboMode_Count>maxCombo)
            {
                superComboMode_Count = maxCombo;
            }
            else
            {
                superComboMode_Count += 1f;
            }
            Food_Shot();
            combo_Count += 1;
            Destroy(smallFood_Setting.smallFood_Index[0]);
            mainFood_Setting.GetComponentInChildren<MainFood>().Damage();
            int randomGold = Random.Range(stage.stageCount, (stage.stageCount + stage.stageCount)+1);
            Debug.Log(randomGold);
            gold = gold + randomGold;
            goldText.text = gold.ToString();
            GetComponent<AudioSource>().clip = eat_Sound;
            GetComponent<AudioSource>().Play();
            eat_Effect = Instantiate(Resources.Load("Eat_Effect"), Vector3.zero, Quaternion.identity) as GameObject;
            eat_Effect.transform.SetParent(eat_Transform.transform);
            eat_Effect.transform.position = eat_Transform.transform.position;

            combo_system.combo_Strike();
        }
    }
    public void Flase_Mode()
    {
        if(ps==PlayerState.False)
        {
            mainFood_Setting.GetComponentInChildren<MainFood>().Heal();
            combo_Count = 0;
            superComboMode_Count = 1;
            combo_system.combo_Gaze.fillAmount = superComboMode_Count / maxCombo;
            combo_system.combo_Text.text = combo_Count.ToString()+" Combo";
            ps = PlayerState.Idle;
        }
    }

    public void Food_Shot()
    {
        if (smallFood_Setting.smallFood_Index[0].layer == 12)
        {
            GameObject shoot = Instantiate(Resources.Load("SmallFood_Red_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform);
            shoot.transform.position = eat_Transform.transform.position;
            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Red_Fly"), "time", 2));
        }
        else if (smallFood_Setting.smallFood_Index[0].layer == 11)
        {
            GameObject shoot = Instantiate(Resources.Load("SmallFood_Yellow_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform);
            shoot.transform.position = eat_Transform.transform.position;
            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Yellow_Fly"), "time", 2));
        }
        else if (smallFood_Setting.smallFood_Index[0].layer == 10)
        {
            GameObject shoot = Instantiate(Resources.Load("SmallFood_Green_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform);
            shoot.transform.position = eat_Transform.transform.position;
            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Green_Fly"), "time", 2));
        }
        else if (smallFood_Setting.smallFood_Index[0].layer == 9)
        {
            GameObject shoot = Instantiate(Resources.Load("SmallFood_Blue_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform);
            shoot.transform.position = eat_Transform.transform.position;
            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Blue_Fly"), "time", 2));
        }
    }
}
