using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SmallStageMenu : MonoBehaviour
{
    Player_Ctrl_PC player;
    SmallStageMenu_Setting smallStageMenu_Setting;
    Skill2_Button skill2;
    StageManager stageManager;
    public Image hp_Bar;
    public Image Canvas_UI_Hp_Bar;
    public Image Canvas_UI_Timer_Bar;
    public Text timeText;

    public float maxHP = 100.0f;
    public float currentHp = 100.0f;
    public float currentTimer = 15.0f;
    public float maxTimer = 15.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        skill2 = GameObject.FindGameObjectWithTag("Skill2").GetComponent<Skill2_Button>();
        stageManager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer_Play();
    }

    public void Damage()
    {
        currentHp -= player.power;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        if (currentHp <= 0)
        {
            stageManager.smallstageCount = stageManager.smallstageCount + 1;
            stageManager.smallStageChange();
            smallStageMenu_Setting.foodChangeIndex++;
            smallStageMenu_Setting.Food_Change();
        }
    }

    public void Skill2Damage()
    {
        currentHp -= skill2.power;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        if (currentHp <= 0)
        {
            stageManager.smallstageCount = stageManager.smallstageCount + 1;
            stageManager.smallStageChange();
            smallStageMenu_Setting.foodChangeIndex++;
            smallStageMenu_Setting.Food_Change();
        }
    }

    public void Heal()
    {
		currentHp += (player.power * 2);
		if (currentHp >= maxHP) {
			currentHp = maxHP;
		}
			hp_Bar.fillAmount = currentHp / maxHP;
			Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
		
    }
    public void Timer_Play()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            timeText.text = currentTimer.ToString("N1");

            Canvas_UI_Timer_Bar.fillAmount = currentTimer / maxTimer;
        }
    }
}
