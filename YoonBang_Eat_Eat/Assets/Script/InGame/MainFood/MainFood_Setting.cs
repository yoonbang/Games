using UnityEngine;
using System.Collections;

public class MainFood_Setting : MonoBehaviour {
    public GameObject main_Food;
    public Transform food_Transform;

    MainFood_Collection mainFood_Collection;

    int foodChangeIndex = 0;

    // Use this for initialization
    void Start () {
        mainFood_Collection = GameObject.FindGameObjectWithTag("MainFood_Collection").GetComponent<MainFood_Collection>();
        StartMainMenuSetting();
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponentInChildren<MainFood>().Timer_Play();
	}

    public void StartMainMenuSetting()
    {
        main_Food = Instantiate(mainFood_Collection.mainFood_Collection[0]) as GameObject;
        main_Food.transform.parent = food_Transform.transform;
        main_Food.transform.position = food_Transform.position;
    }
    
    public void Food_Change()
    {
        Destroy(main_Food);
        foodChangeIndex++;
        StageManager stageManager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        stageManager.stageCount = stageManager.stageCount+1;
        main_Food = Instantiate(mainFood_Collection.mainFood_Collection[foodChangeIndex]) as GameObject;
        main_Food.transform.parent = food_Transform.transform;
        main_Food.transform.position = food_Transform.position;

        main_Food.GetComponentInChildren<MainFood>().Canvas_UI_Hp_Bar.fillAmount = main_Food.GetComponentInChildren<MainFood>().currentHp / main_Food.GetComponentInChildren<MainFood>().maxHP;
    }
}
