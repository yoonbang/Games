using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum PlayerState
{
    Idle,
    Skill,
    Combo,
    Eat,
    SuperMode,
    False,
    SuperFiverMode,
}

public class Player_Ctrl_PC : MonoBehaviour
{
    SmallFood_Setting smallFood_Setting;
    SmallFood_Food_Menu smallFood_Food_Menu;
    Dish_Node_Id dish_Node_Id;
    SmallFood_Dish_Id smallFood_Dish_Id;
    MainFood_Setting mainFood_Setting;
    SmallStageMenu_Setting smallStageMenu_Setting;
    Combo_System combo_system;
    StartSmallFoodAnimation startSmallFoodAnimation;
    MainSpoonAnimation mainSpoonAnimation;
    SmallSpoonAnimation SmallSpoonAnimation;
    MainChopsticAnimation mainChopsticAnimation;
    MainForksAnimation mainForksAnimation;
    MainKnifeAnimation mainKnifeAnimation;
    BlueDishGather blueDishGather;
    YellowDishGather yellowDishGather;
    GreenDishGather greenDishGather;
    RedDishGather redDishGather;
    PlayerAnimation playerAnimation;
    SmallChopsticAnimation smallChopsticAnimation;
    SmallForksAnimation smallForksAnimation;
    SmallKnifeAnimation smallKnifeAnimation;
    DamageTextManager damegeTextManager;
    MainCamara mainCamara;
    SustainmentTime stt;

    public PlayerState ps;
    int layerMask;

    public string DishLayer = "Dish";
    public string SkillLayer = "Skill";
    // Use this for initialization

    public int combo_Count=1;
    public float power=10.0f;

    public float superComboMode_Count = 1f;
    public float maxCombo = 30f;
    public AudioClip eat_Sound;

    public GameObject eat_Effect;
    public Transform eat_Transform;
    public StageManager stage;

    public Text goldText;
    public int level;
    public float gold;

    public bool mainStage;
    public bool criticalMode;

    public int criticalInt = 10;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    public Transform eat_Effect1;
    public Transform dish_Effect1, dish_Effect2, dish_Effect3, dish_Effect4;

    public GameObject menu_Effect;
    public GameObject red_Dish_Effect,green_Dish_Effect,yellow_Dish_Effect,blue_Dish_Effect;

    public GameObject red_Point_Dish, yellow_Point_Dish, green_Point_Dish, blue_Dish_Point, firstDishPoint;
    public Transform dishPointShot;
    public bool goldGain=false;
    public float superFiverMode = 0f;
    public float maxSuperFiverMode = 50f;
    //void Awake()
  
    void Awake()
    {
        damegeTextManager = GameObject.FindGameObjectWithTag("DamageText").GetComponent<DamageTextManager>();
        smallFood_Setting = GameObject.FindGameObjectWithTag("SmallMenu_Setting").GetComponent<SmallFood_Setting>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        combo_system = GameObject.FindGameObjectWithTag("Combo_System").GetComponent<Combo_System>();
        stage = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        layerMask = LayerMask.GetMask(DishLayer, SkillLayer);
        startSmallFoodAnimation = GameObject.FindGameObjectWithTag("StartSmallFoodPosition").GetComponent<StartSmallFoodAnimation>();
        mainSpoonAnimation = GameObject.FindGameObjectWithTag("MainSpoon").GetComponent<MainSpoonAnimation>();
        mainChopsticAnimation = GameObject.FindGameObjectWithTag("MainChopstic").GetComponent<MainChopsticAnimation>();
        SmallSpoonAnimation = GameObject.FindGameObjectWithTag("SmallSpoonAnimation").GetComponent<SmallSpoonAnimation>();
        mainForksAnimation = GameObject.FindGameObjectWithTag("MainForks").GetComponent<MainForksAnimation>();
        mainKnifeAnimation = GameObject.FindGameObjectWithTag("MainKnife").GetComponent<MainKnifeAnimation>();
        blueDishGather = GameObject.FindGameObjectWithTag("Blue_Dish_Gather").GetComponent<BlueDishGather>();
        yellowDishGather = GameObject.FindGameObjectWithTag("Yellow_Dish_Gather").GetComponent<YellowDishGather>();
        greenDishGather = GameObject.FindGameObjectWithTag("Green_Dish_Gather").GetComponent<GreenDishGather>();
        redDishGather = GameObject.FindGameObjectWithTag("Red_Dish_Gather").GetComponent<RedDishGather>();
        playerAnimation = GameObject.FindGameObjectWithTag("PlayerRender").GetComponent<PlayerAnimation>();
        smallChopsticAnimation = GameObject.FindGameObjectWithTag("SmallChopstic").GetComponent<SmallChopsticAnimation>();
        smallForksAnimation = GameObject.FindGameObjectWithTag("SmallForks").GetComponent<SmallForksAnimation>();
        smallKnifeAnimation = GameObject.FindGameObjectWithTag("SmallKnife").GetComponent<SmallKnifeAnimation>();
        mainCamara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamara>();
        stt = GameObject.FindGameObjectWithTag("STI").GetComponent<SustainmentTime>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseButtonClick();
        
    }
    public void MouseButtonClick()
    {
        int cnt = Input.touchCount;

        for (int i = 0; i < cnt; ++i)
        {
            if (EventSystem.current.IsPointerOverGameObject(i) == false)
            {
                
                Vector2 pos = Input.GetTouch(0).position;
                Vector3 theTouch = new Vector3(pos.x, pos.y, 0.0f);

                Ray ray = Camera.main.ScreenPointToRay(theTouch);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    int layer = hit.transform.gameObject.layer;

                    dish_Node_Id = hit.collider.transform.GetComponent<Dish_Node_Id>();
                    smallFood_Dish_Id = GameObject.FindGameObjectWithTag("SmallFood").GetComponent<SmallFood_Dish_Id>();
                    
                    if (Input.GetTouch(0).phase == TouchPhase.Began && layer == LayerMask.NameToLayer(DishLayer) && dish_Node_Id.id == smallFood_Dish_Id.id)
                    {
                        //Destroy(smallFood_Setting.smallFood_Index[0]);
                        if (ps == PlayerState.Combo)
                        {
                            Combo_Mode();
                        }
                        else if(ps==PlayerState.SuperFiverMode)
                        {
                            Super_Fiver_Mode();
                        }
                        else {
                            ps = PlayerState.Eat;
                            Eat_Mode();
                        }
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Began && layer == LayerMask.NameToLayer(DishLayer) && dish_Node_Id.id != smallFood_Dish_Id.id)
                    {
                        if (ps == PlayerState.Combo)
                        {
                            Combo_Mode();
                        }
                        else if (ps == PlayerState.SuperFiverMode)
                        {
                            Super_Fiver_Mode();
                        }
                        else {
                            ps = PlayerState.False;
                            Flase_Mode();
                        }
                    }

                    if (superComboMode_Count >= maxCombo)
                    {
                        if (superFiverMode >= maxSuperFiverMode)
                        {
                            ps = PlayerState.SuperFiverMode;
                            superComboMode_Count = 0f;
                            SustainmentTimeInformationIcon2();
                            Super_Fiver_Mode();
                        }
                        else {
                            if (ps != PlayerState.SuperFiverMode || ps!=PlayerState.Skill)
                            {
                                superFiverMode += 10f;
                                combo_system.superModeGaze.fillAmount = superFiverMode / maxSuperFiverMode;
                                SustainmentTimeInformationIcon();
                                ps = PlayerState.Combo;
                                combo_Count -= 1;
                                Combo_Mode();
                            }
                        }
                    }
                }
            } 
        }





        if (smallFood_Setting.smallFood_Index[0]==null)
        {
            smallFood_Setting.smallFood_Index[0] = Instantiate(smallFood_Setting.smallFood_Index[1]) as GameObject;
            smallFood_Setting.smallFood_Index[0].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[0].transform,false);
            smallFood_Setting.smallFood_Index[0].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[0].transform.position;
            DishPoint();

            Destroy(smallFood_Setting.smallFood_Index[1]);
            smallFood_Setting.smallFood_Index[1] = Instantiate(smallFood_Setting.smallFood_Index[2]) as GameObject;
            smallFood_Setting.smallFood_Index[1].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[1].transform, false);
            smallFood_Setting.smallFood_Index[1].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[1].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[2]);
            smallFood_Setting.smallFood_Index[2] = Instantiate(smallFood_Setting.smallFood_Index[3]) as GameObject;
            smallFood_Setting.smallFood_Index[2].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[2].transform, false);
            smallFood_Setting.smallFood_Index[2].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[2].transform.position;


            Destroy(smallFood_Setting.smallFood_Index[3]);
            smallFood_Setting.smallFood_Index[3] = Instantiate(smallFood_Setting.smallFood_Index[4]) as GameObject;
            smallFood_Setting.smallFood_Index[3].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[3].transform, false);
            smallFood_Setting.smallFood_Index[3].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[3].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[4]);
            smallFood_Setting.smallFood_Index[4] = Instantiate(smallFood_Setting.smallFood_Index[5]) as GameObject;
            smallFood_Setting.smallFood_Index[4].transform.transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[4].transform, false);
            smallFood_Setting.smallFood_Index[4].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[4].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[5]);
            smallFood_Setting.smallFood_Index[5] = Instantiate(smallFood_Setting.smallFood_Index[6]) as GameObject;
            smallFood_Setting.smallFood_Index[5].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[5].transform, false);
            smallFood_Setting.smallFood_Index[5].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[5].transform.position;

            Destroy(smallFood_Setting.smallFood_Index[6]);
            smallFood_Setting.smallFood_Index[6] = Instantiate(smallFood_Setting.smallFood_Index[7]) as GameObject;
            smallFood_Setting.smallFood_Index[6].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform, false);
            smallFood_Setting.smallFood_Index[6].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[6].transform.position;

            int randomFood = Random.Range(1, 5);

            if(randomFood == 1)
            {
                Destroy(smallFood_Setting.smallFood_Index[7]);
                smallFood_Setting.smallFood_Index[7] = Instantiate(smallFood_Setting.small_Red_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[7].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform,false);
                smallFood_Setting.smallFood_Index[7].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform.position;
                smallFood_Setting.smallFood_Index[7].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
            if (randomFood == 2)
            {
                Destroy(smallFood_Setting.smallFood_Index[7]);
                smallFood_Setting.smallFood_Index[7] = Instantiate(smallFood_Setting.small_Blue_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[7].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform, false);
                smallFood_Setting.smallFood_Index[7].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform.position;
                smallFood_Setting.smallFood_Index[7].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
            if (randomFood == 3)
            {
                Destroy(smallFood_Setting.smallFood_Index[7]);
                smallFood_Setting.smallFood_Index[7] = Instantiate(smallFood_Setting.small_Yellow_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[7].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform, false);
                smallFood_Setting.smallFood_Index[7].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform.position;
                smallFood_Setting.smallFood_Index[7].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
            if (randomFood == 4)
            {
                Destroy(smallFood_Setting.smallFood_Index[7]);
                smallFood_Setting.smallFood_Index[7] = Instantiate(smallFood_Setting.small_Green_Dish) as GameObject;
                smallFood_Setting.smallFood_Index[7].transform.SetParent(smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform, false);
                smallFood_Setting.smallFood_Index[7].transform.position = smallFood_Setting.smallfood_Postion.smallFood_Position[7].transform.position;
                smallFood_Setting.smallFood_Index[7].GetComponentInChildren<SmallFood_Food_Menu>().FoodSetting();
            }
        }
    }


    public void Combo_Mode()
    {
        if(ps==PlayerState.Combo)
        {
            if (mainStage == false)
            {
                if (Random.Range(1, 101) <= criticalInt)
                {
                    damegeTextManager.ciriticalMode = true;
                    smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage(power * 2);
                }
                else
                {
                    smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage(power);
                }
            }
            else
            {
                if (Random.Range(1, 101) <= criticalInt)
                {
                    damegeTextManager.ciriticalMode = true;
                    mainFood_Setting.GetComponentInChildren<MainFood>().Damage(power * 2);
                }
                else
                {
                    mainFood_Setting.GetComponentInChildren<MainFood>().Damage(power);
                }
            }
            Food_Shot();
            playerAnimation.SuperModeAnimation();
            Destroy(smallFood_Setting.smallFood_Index[0]);
            Destroy(firstDishPoint);
            combo_Count += 1;

            GameObject menuEffect = Instantiate(menu_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            menuEffect.transform.SetParent(eat_Effect1.transform, false);
            menuEffect.transform.position = eat_Effect1.transform.position;

            GameObject eatEffect = Instantiate(eat_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            eatEffect.transform.SetParent(eat_Transform.transform, false);
            eatEffect.transform.position = eat_Transform.transform.position;

            int randomGold = Random.Range(stage.mainStageCount, stage.mainStageCount + stage.mainStageCount);
            if (goldGain == true)
            {
                randomGold = randomGold * 2;
            }
            else
            {
                randomGold = randomGold * 1;
            }
            gold = gold + (randomGold * 2);
            goldText.text = CountModule(gold);
            GetComponent<AudioSource>().clip = eat_Sound;
            GetComponent<AudioSource>().Play();

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
                if (mainStage == false)
                {
                    if (Random.Range(1, 101) <= criticalInt)
                    {
                        damegeTextManager.ciriticalMode = true;
                        smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage(power * 2);
                    }
                    else
                    {
                        smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage(power);
                    }
                }
                else
                {
                    if (Random.Range(1, 101) <= criticalInt)
                    {
                        damegeTextManager.ciriticalMode = true;
                        mainFood_Setting.GetComponentInChildren<MainFood>().Damage(power*2);
                    }
                    else
                    {
                        mainFood_Setting.GetComponentInChildren<MainFood>().Damage(power);
                    }

                }
                    Food_Shot();
                    playerAnimation.AttackAnimation();
                    Destroy(smallFood_Setting.smallFood_Index[0]);
                    Destroy(firstDishPoint);
                    combo_Count += 1;
                    startSmallFoodAnimation.SmallFoodAnimation();

                    GameObject menuEffect = Instantiate(menu_Effect, Vector3.zero, Quaternion.identity) as GameObject;
                    menuEffect.transform.SetParent(eat_Effect1.transform, false);
                    menuEffect.transform.position = eat_Effect1.transform.position;
            
                    GameObject eatEffect = Instantiate(eat_Effect, Vector3.zero, Quaternion.identity) as GameObject;
                    eatEffect.transform.SetParent(eat_Transform.transform, false);
                    eatEffect.transform.position = eat_Transform.transform.position;

                    int randomGold = Random.Range(stage.mainStageCount, (stage.mainStageCount + stage.mainStageCount) + 1);
                    if (goldGain == true)
                    {
                        randomGold = randomGold * 2;
                    }
                    else
                    {
                        randomGold = randomGold * 1;
                    }
                    gold = gold + (randomGold * 2);
                    goldText.text = CountModule(gold);
                    GetComponent<AudioSource>().clip = eat_Sound;
                    GetComponent<AudioSource>().Play();

                    combo_system.combo_Strike();
        }
       
    }

    public void Super_Fiver_Mode()
    {
        if (ps == PlayerState.SuperFiverMode)
        {
            if (mainStage == false)
            {
                if (Random.Range(1, 101) <= criticalInt)
                {
                    damegeTextManager.ciriticalMode = true;
                    smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage(power * 3f);
                }
                else
                {
                    smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage(power*1.5f);
                }
            }
            else
            {
                if (Random.Range(1, 101) <= criticalInt)
                {
                    damegeTextManager.ciriticalMode = true;
                    mainFood_Setting.GetComponentInChildren<MainFood>().Damage(power * 2);
                }
                else
                {
                    mainFood_Setting.GetComponentInChildren<MainFood>().Damage(power);
                }
            }
            Food_Shot();
            playerAnimation.SuperModeAnimation();
            Destroy(smallFood_Setting.smallFood_Index[0]);
            Destroy(firstDishPoint);
            combo_Count += 1;

            GameObject menuEffect = Instantiate(menu_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            menuEffect.transform.SetParent(eat_Effect1.transform, false);
            menuEffect.transform.position = eat_Effect1.transform.position;

            GameObject eatEffect = Instantiate(eat_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            eatEffect.transform.SetParent(eat_Transform.transform, false);
            eatEffect.transform.position = eat_Transform.transform.position;

            int randomGold = Random.Range(stage.mainStageCount, stage.mainStageCount + stage.mainStageCount);
            if (goldGain == true)
            {
                randomGold = randomGold * 2;
            }
            else
            {
                randomGold = randomGold * 1;
            }
            gold = gold + (randomGold * 2);
            goldText.text = CountModule(gold);
            GetComponent<AudioSource>().clip = eat_Sound;
            GetComponent<AudioSource>().Play();

            combo_system.SuperFiver();
        }
    }


    public void Flase_Mode()
    {
        if(ps==PlayerState.False)
        {
            if (mainStage == false)
            {
                smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Heal();
            }
            else
            {
                mainFood_Setting.GetComponentInChildren<MainFood>().Heal();
            }
            mainCamara.MainCamaraAnimationStart();
            combo_Count = 0;
            superComboMode_Count = 0;
            superFiverMode = 0;
            combo_system.combo_Gaze.fillAmount = superComboMode_Count / maxCombo;
            combo_system.superModeGaze.fillAmount = superFiverMode / maxSuperFiverMode;
            combo_system.combo_Text.text = combo_Count.ToString()+" Combo";
            ps = PlayerState.Idle;
        }
    }

    public void Food_Shot()
    {
        if (smallFood_Setting.smallFood_Index[0].layer == 12)
        {
            //mainKnifeAnimation.MainSpoonAnimationStart();
            redDishGather.redDishGatherPlus();
            SmallSpoonAnimation.SmallSpoonAttackAnimation();

            //Debug.Log("스몰데미지="+ SmallSpoonAnimation.smallPower);

            GameObject shoot = Instantiate(Resources.Load("SmallFood_Red_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform,false);
            shoot.transform.position = eat_Transform.transform.position;
            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Red_Fly"), "time", 1));
            //Destroy();

            GameObject dishEffect = Instantiate(red_Dish_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            dishEffect.transform.SetParent(dish_Effect2.transform, false);
            dishEffect.transform.position = dish_Effect2.transform.position;

            smallFood_Setting = GameObject.FindGameObjectWithTag("SmallMenu_Setting").GetComponent<SmallFood_Setting>();
        }
        else if (smallFood_Setting.smallFood_Index[0].layer == 11)
        {
            //mainChopsticAnimation.MainSpoonAnimationStart();
            yellowDishGather.yellowDishGatherPlus();
            smallChopsticAnimation.SmallChopsticAttackAnimation();

            GameObject shoot = Instantiate(Resources.Load("SmallFood_Yellow_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform,false);
            shoot.transform.position = eat_Transform.transform.position;

            GameObject dishEffect = Instantiate(yellow_Dish_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            dishEffect.transform.SetParent(dish_Effect3.transform, false);
            dishEffect.transform.position = dish_Effect3.transform.position;

            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Yellow_Fly"), "time", 1));
        }
        else if (smallFood_Setting.smallFood_Index[0].layer == 10)
        {
            //mainForksAnimation.MainSpoonAnimationStart();
            greenDishGather.greenDishGatherPlus();
            smallForksAnimation.SmallForksAttackAnimation();

            GameObject shoot = Instantiate(Resources.Load("SmallFood_Green_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform,false);
            shoot.transform.position = eat_Transform.transform.position;

            GameObject dishEffect = Instantiate(green_Dish_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            dishEffect.transform.SetParent(dish_Effect4.transform, false);
            dishEffect.transform.position = dish_Effect4.transform.position;

            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Green_Fly"), "time", 1));
        }
        else if (smallFood_Setting.smallFood_Index[0].layer == 9)
        {
            smallKnifeAnimation.SmallKnifeAttackAnimation();
            //mainSpoonAnimation.MainSpoonAnimationStart();

            blueDishGather.blueDishGatherPlus();

            GameObject shoot = Instantiate(Resources.Load("SmallFood_Blue_Dish_Shoot"), Vector3.zero, Quaternion.identity) as GameObject;
            shoot.transform.SetParent(eat_Transform.transform,false);
            shoot.transform.position = eat_Transform.transform.position;

            GameObject dishEffect = Instantiate(blue_Dish_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            dishEffect.transform.SetParent(dish_Effect1.transform, false);
            dishEffect.transform.position = dish_Effect1.transform.position;

            iTween.MoveTo(shoot, iTween.Hash("path", iTweenPath.GetPath("Blue_Fly"), "time", 1));
        }
    }

    public void DishPoint()
    {
        if (smallFood_Setting.smallFood_Index[0].GetComponent<SmallFood_Dish_Id>().id == 1)
        {
            firstDishPoint = Instantiate(red_Point_Dish, Vector3.zero, Quaternion.identity) as GameObject;
            firstDishPoint.transform.SetParent(dishPointShot.transform, false);
            firstDishPoint.transform.position = dishPointShot.transform.position;
        }
        if (smallFood_Setting.smallFood_Index[0].GetComponent<SmallFood_Dish_Id>().id == 3)
        {
            firstDishPoint = Instantiate(yellow_Point_Dish, Vector3.zero, Quaternion.identity) as GameObject;
            firstDishPoint.transform.SetParent(dishPointShot.transform, false);
            firstDishPoint.transform.position = dishPointShot.transform.position;
        }
        if (smallFood_Setting.smallFood_Index[0].GetComponent<SmallFood_Dish_Id>().id == 2)
        {
            firstDishPoint = Instantiate(blue_Dish_Point, Vector3.zero, Quaternion.identity) as GameObject;
            firstDishPoint.transform.SetParent(dishPointShot.transform, false);
            firstDishPoint.transform.position = dishPointShot.transform.position;
        }
        if (smallFood_Setting.smallFood_Index[0].GetComponent<SmallFood_Dish_Id>().id == 4)
        {
            firstDishPoint = Instantiate(green_Point_Dish, Vector3.zero, Quaternion.identity) as GameObject;
            firstDishPoint.transform.SetParent(dishPointShot.transform, false);
            firstDishPoint.transform.position = dishPointShot.transform.position;
        }
    }

    public void SustainmentTimeInformationIcon()
    {
        for (int i = 0; i < stt.SustainmentTimeInformationIcon.Length; i++)
        {
            if (stt.SustainmentTimeInformationIcon[0] == null)
            {
                stt.SustainmentTimeInformationIcon[0] = Instantiate(stt.skillBlessTime[0]) as GameObject;
                stt.SustainmentTimeInformationIcon[0].transform.SetParent(stt.slotTransform[0].transform, false);
                stt.SustainmentTimeInformationIcon[0].transform.position = stt.slotTransform[0].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[1] == null)
            {
                stt.SustainmentTimeInformationIcon[1] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[1].transform.SetParent(stt.slotTransform[1].transform, false);
                stt.SustainmentTimeInformationIcon[1].transform.position = stt.slotTransform[1].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[2] == null)
            {
                stt.SustainmentTimeInformationIcon[2] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[2].transform.SetParent(stt.slotTransform[2].transform, false);
                stt.SustainmentTimeInformationIcon[2].transform.position = stt.slotTransform[2].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[3] == null)
            {
                stt.SustainmentTimeInformationIcon[3] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[3].transform.SetParent(stt.slotTransform[3].transform, false);
                stt.SustainmentTimeInformationIcon[3].transform.position = stt.slotTransform[3].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[4] == null)
            {
                stt.SustainmentTimeInformationIcon[4] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[4].transform.SetParent(stt.slotTransform[4].transform, false);
                stt.SustainmentTimeInformationIcon[4].transform.position = stt.slotTransform[4].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[5] == null)
            {
                stt.SustainmentTimeInformationIcon[5] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[5].transform.SetParent(stt.slotTransform[5].transform, false);
                stt.SustainmentTimeInformationIcon[5].transform.position = stt.slotTransform[5].transform.position;

                return;
            }
        }
    }

    public void SustainmentTimeInformationIcon2()
    {
        for (int i = 0; i < stt.SustainmentTimeInformationIcon.Length; i++)
        {
            if (stt.SustainmentTimeInformationIcon[0] == null)
            {
                stt.SustainmentTimeInformationIcon[0] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[0].transform.SetParent(stt.slotTransform[0].transform, false);
                stt.SustainmentTimeInformationIcon[0].transform.position = stt.slotTransform[0].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[1] == null)
            {
                stt.SustainmentTimeInformationIcon[1] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[1].transform.SetParent(stt.slotTransform[1].transform, false);
                stt.SustainmentTimeInformationIcon[1].transform.position = stt.slotTransform[1].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[2] == null)
            {
                stt.SustainmentTimeInformationIcon[2] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[2].transform.SetParent(stt.slotTransform[2].transform, false);
                stt.SustainmentTimeInformationIcon[2].transform.position = stt.slotTransform[2].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[3] == null)
            {
                stt.SustainmentTimeInformationIcon[3] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[3].transform.SetParent(stt.slotTransform[3].transform, false);
                stt.SustainmentTimeInformationIcon[3].transform.position = stt.slotTransform[3].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[4] == null)
            {
                stt.SustainmentTimeInformationIcon[4] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[4].transform.SetParent(stt.slotTransform[4].transform, false);
                stt.SustainmentTimeInformationIcon[4].transform.position = stt.slotTransform[4].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[5] == null)
            {
                stt.SustainmentTimeInformationIcon[5] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[5].transform.SetParent(stt.slotTransform[5].transform, false);
                stt.SustainmentTimeInformationIcon[5].transform.position = stt.slotTransform[5].transform.position;

                return;
            }
        }
    }

    public string CountModule(float haveCount)
    {
        if (haveCount > 1000000000000000000)
            return string.Format("{0:#.#}G", (float)haveCount / 1000000000000000000);
        if (haveCount > 1000000000000000)
            return string.Format("{0:#.#}P", (float)haveCount / 1000000000000000);
        if (haveCount > 1000000000000)
            return string.Format("{0:#.#}T", (float)haveCount / 1000000000000);
        if (haveCount > 1000000000)
            return string.Format("{0:#.#}B", (float)haveCount / 1000000000);
        else if (haveCount > 1000000)
            return string.Format("{0:#.#}M", (float)haveCount / 1000000);
        if (haveCount > 1000)
            return string.Format("{0:#.#}K", (float)haveCount / 1000);
        else
            return haveCount.ToString("N0");
    }
}
