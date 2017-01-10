using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainFood : MonoBehaviour {
    Player_Ctrl_PC player;
    MainFood_Setting mainFood_Setting;
    SmallStageMenu_Setting smallStageMenu_Setting;
    StageManager stageManager;
    DamageTextManager damageText;

    public Image hp_Bar;
    public Image Canvas_UI_Hp_Bar;
    public Image Canvas_UI_Timer_Bar;
    public Text timeText;

    public Text mainMenuName;
    public Text hp_Text;

    public string Name_String;

    public float maxHP = 100.0f;
    public float currentHp = 100.0f;
    public float currentTimer=15.0f;
    public float maxTimer = 15.0f;
    public float damage = 0.0f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        stageManager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        damageText = GameObject.FindGameObjectWithTag("DamageText").GetComponent<DamageTextManager>();

        maxHP = stageManager.mainStageHp;
        currentHp = stageManager.mainStageHp;
    }
	
	// Update is called once per frame
	void Update () {
        //Timer_Play();
    }

    public void Damage(float power)
    {
        damage = power;
        currentHp -= damage;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        hp_Text.text = currentHp.ToString("N1") + " HP";
        damageText.DamageUI();

        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Damage");

        if (currentHp<=0)
        {
            stageManager.mainStageCount++;
            stageManager.mainStageChange();

            for (int i = 0; i < 20; i++)
            {

                int randomGold = Random.Range(stageManager.mainStageCount, (stageManager.mainStageCount + stageManager.mainStageCount) + 1);
                player.gold = player.gold + (randomGold * 2);
                player.goldText.text = player.gold.ToString();
            }

            stageManager.smallstageText.gameObject.SetActive(true);
            Destroy(mainFood_Setting.main_Food);
            player.mainStage = false;
            smallStageMenu_Setting.Food_Change();
            stageManager.SmallStageSetting();
        }
    }

    public void TheDishesDamege(float power)
    {
        damage = power;
        currentHp -= damage;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        hp_Text.text = currentHp.ToString("N1") + " HP";


        if (currentHp <= 0)
        {
            stageManager.mainStageCount++;
            stageManager.mainStageChange();

            for (int i = 0; i < 20; i++)
            {

                int randomGold = Random.Range(stageManager.mainStageCount, (stageManager.mainStageCount + stageManager.mainStageCount) + 1);
                player.gold = player.gold + (randomGold * 2);
                player.goldText.text = player.gold.ToString();
            }

            stageManager.smallstageText.gameObject.SetActive(true);
            Destroy(mainFood_Setting.main_Food);
            player.mainStage = false;
            smallStageMenu_Setting.Food_Change();
            stageManager.SmallStageSetting();
        }
    }

    public void Heal()
    {
        currentHp += (player.power * 2);
        if (currentHp > maxHP) {
			currentHp = maxHP;
		}
               
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        hp_Text.text = currentHp.ToString("N1") + " HP";
    }

    public void Timer_Play()
    {
        if(currentTimer>0)
        {
            currentTimer -= Time.deltaTime;
            timeText.text = currentTimer.ToString("N1");

            Canvas_UI_Timer_Bar.fillAmount = currentTimer / maxTimer;
        }
    }
}
