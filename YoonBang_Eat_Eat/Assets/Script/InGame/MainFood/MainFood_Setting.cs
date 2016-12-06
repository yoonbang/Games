using UnityEngine;
using System.Collections;

public class MainFood_Setting : MonoBehaviour {
    public GameObject main_Food;
    public Transform food_Transform;

    MainFood_Collection mainFood_Collection;
    SmallStageMenu_Setting smallStageMenu_Setting;
    Player_Ctrl_PC player_Ctrl_PC;

    int foodChangeIndex = -1; //다음메뉴로 넘어가는 값
    int stageindex = 0; // 해당스테이지의 메뉴값(1~10스테이지의 메뉴 , 11~20스테이지의 메뉴)

    // Use this for initialization
    void Start () {
        mainFood_Collection = GameObject.FindGameObjectWithTag("MainFood_Collection").GetComponent<MainFood_Collection>();
        player_Ctrl_PC = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        //StartMainMenuSetting();
    }
	
	// Update is called once per frame
	void Update () {
        if(main_Food!=null)
        this.GetComponentInChildren<MainFood>().Timer_Play();
	}

    /*public void StartMainMenuSetting()
    {
        main_Food = Instantiate(mainFood_Collection.mainFood_Collection[0]) as GameObject;
        main_Food.transform.parent = food_Transform.transform;
        main_Food.transform.position = food_Transform.position;
    }*/
    
    public void Food_Change()
    {
        //Destroy(main_Food);
		if (smallStageMenu_Setting.smallStageFood != null) {
			Destroy (smallStageMenu_Setting.smallStageFood);
		}
        player_Ctrl_PC.mainStage = true;
        foodChangeIndex++;
        //StageManager stageManager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        //stageManager.mainStageCount = stageManager.mainStageCount + 1;
        main_Food = Instantiate(mainFood_Collection.mainFood_Collection[foodChangeIndex]) as GameObject;
        main_Food.transform.parent = food_Transform.transform;
        main_Food.transform.position = food_Transform.position;

        main_Food.GetComponentInChildren<MainFood>().Canvas_UI_Hp_Bar.fillAmount = main_Food.GetComponentInChildren<MainFood>().currentHp / main_Food.GetComponentInChildren<MainFood>().maxHP;
    }
}
