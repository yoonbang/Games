using UnityEngine;
using System.Collections;

public class SmallStageMenu_Setting : MonoBehaviour {

    public GameObject smallStageFood;
    public Transform food_Transform;
    public int randomFood=0;
    SmallStageMenu_Collection smallStageMenu_Collection;
    MainFood_Setting mainFood_Setting;
    StageManager stageManager;
    public int foodChangeIndex = 0;
    public int stageindex = 0; // 해당스테이지의 메뉴값(1~10스테이지의 메뉴 , 11~20스테이지의 메뉴)
    public int changePlayerStateMenu=9;
    // Use this for initialization
    void Start()
    {
        smallStageMenu_Collection = GameObject.FindGameObjectWithTag("SmallStageMenu_Collection").GetComponent<SmallStageMenu_Collection>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        stageManager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        StartSmallStageMenuSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if(smallStageFood!=null)
        this.GetComponentInChildren<SmallStageMenu>().Timer_Play();
    }

    public void StartSmallStageMenuSetting()
    {
        if (stageindex == 0)
        {
            randomFood = Random.Range(0, 9);
            smallStageFood = Instantiate(smallStageMenu_Collection.smallStageFood_Collection[randomFood]) as GameObject;
            smallStageFood.transform.parent = food_Transform.transform;
            smallStageFood.transform.position = food_Transform.position;
        }
        if (stageindex != 0)
        {
            randomFood = Random.Range(stageindex*10, (stageindex * 10)+9);
            smallStageFood = Instantiate(smallStageMenu_Collection.smallStageFood_Collection[randomFood]) as GameObject;
            smallStageFood.transform.parent = food_Transform.transform;
            smallStageFood.transform.position = food_Transform.position;
        }
    }

    public void Food_Change()
    {
        if (foodChangeIndex > changePlayerStateMenu) {
			Destroy (smallStageFood);
			foodChangeIndex = 0;
			stageindex++;
            stageManager.smallstageCount = 1;
            stageManager.smallstageText.gameObject.SetActive(false);
            stageManager.smallStageChange();
            mainFood_Setting.Food_Change ();
		} else {
			Destroy (smallStageFood);
            
			if (stageindex == 0) {
				randomFood = Random.Range (0, 9);
			}
			if (stageindex != 0) {
				randomFood = Random.Range (stageindex * 10, (stageindex * 10) + 9);
			}
		
            smallStageFood = Instantiate (smallStageMenu_Collection.smallStageFood_Collection [randomFood]) as GameObject;
			smallStageFood.transform.parent = food_Transform.transform;
			smallStageFood.transform.position = food_Transform.position;

			smallStageFood.GetComponentInChildren<SmallStageMenu> ().Canvas_UI_Hp_Bar.fillAmount = smallStageFood.GetComponentInChildren<SmallStageMenu> ().currentHp / smallStageFood.GetComponentInChildren<SmallStageMenu> ().maxHP;
		}
    }
}
