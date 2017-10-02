using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SmallStageMenu : MonoBehaviour
{
    Player_Ctrl_PC player;
    SmallStageMenu_Setting smallStageMenu_Setting;
    Skill2_Button skill2;
    StageManager stageManager;
    DamageTextManager damageText;

    StageManager stage;
    public Image hp_Bar;
    public Image Canvas_UI_Hp_Bar;
    public Image Canvas_UI_Timer_Bar;
    public Text timeText;
    public Text smallMenuName;
    public Text hp_Text;

    public string Name_String;

    public float maxHP = 100.0f;
    public float currentHp = 100.0f;
    public float currentTimer = 15.0f;
    public float maxTimer = 15.0f;
    public float damage = 0.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        skill2 = GameObject.FindGameObjectWithTag("Skill2").GetComponent<Skill2_Button>();
        stageManager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        damageText = GameObject.FindGameObjectWithTag("DamageText").GetComponent<DamageTextManager>();
        


        maxHP = stageManager.smallStageHp;
        currentHp = stageManager.smallStageHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            currentHp = 0;
            hp_Text.text = currentHp.ToString() + " HP";
            stageManager.smallstageCount = stageManager.smallstageCount + 1;
            stageManager.smallStageChange();
            for (int i = 0; i < 10; i++)
            {

                int randomGold = Random.Range(stageManager.mainStageCount, (stageManager.mainStageCount + stageManager.mainStageCount) + 1);
                player.gold = player.gold + (randomGold * 2);
                player.goldText.text = CountModuleGold(player.gold);
            }

            if (stageManager.currentBonusTime < stageManager.maxBonusTime)
            {
                stageManager.currentBonusTime += 0.5f;
                stageManager.bonusTimerBar.fillAmount = stageManager.currentBonusTime / stageManager.maxBonusTime;
            }

            smallStageMenu_Setting.foodChangeIndex++;
            smallStageMenu_Setting.Food_Change();

        }
    }

    public void Damage(float power)
    {
        damage = power;
        currentHp -= damage;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        //hp_Text.text = currentHp.ToString("N1") +" HP";
        hp_Text.text = CountModule(currentHp) + " HP";
        damageText.DamageUI();

        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Damage");
        /*if (currentHp <= 0)
        {

            stageManager.smallstageCount = stageManager.smallstageCount + 1;
            stageManager.smallStageChange();
            for (int i = 0; i < 10; i++) {

                int randomGold = Random.Range(stageManager.mainStageCount, (stageManager.mainStageCount + stageManager.mainStageCount) + 1);
                player.gold = player.gold + (randomGold * 2);
                player.goldText.text = player.gold.ToString();
            }

            if (stageManager.currentBonusTime<= stageManager.maxBonusTime)
            {
                stageManager.currentBonusTime += 0.5f;
                stageManager.bonusTimerBar.fillAmount = stageManager.currentBonusTime/ stageManager.maxBonusTime;
            }
 
            smallStageMenu_Setting.foodChangeIndex++;
            smallStageMenu_Setting.Food_Change();

        }*/
    }
    public void TheDishesDamege(float power)
    {
        damage = power;
        currentHp -= damage;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        //hp_Text.text = currentHp.ToString("N1") + " HP";
        hp_Text.text = CountModule(currentHp) + " HP";
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Damage");

        /*if (currentHp <= 0)
        {

            stageManager.smallstageCount = stageManager.smallstageCount + 1;
            stageManager.smallStageChange();
            for (int i = 0; i < 10; i++)
            {

                int randomGold = Random.Range(stageManager.mainStageCount, (stageManager.mainStageCount + stageManager.mainStageCount) + 1);
                player.gold = player.gold + (randomGold * 2);
                player.goldText.text = player.gold.ToString();
            }

            smallStageMenu_Setting.foodChangeIndex++;
            smallStageMenu_Setting.Food_Change();

        }*/
    }
    
    public void SmallDishesDamege(float power)
    {
        damage = power;
        currentHp -= damage;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        //hp_Text.text = currentHp.ToString("N1") + " HP";
        hp_Text.text = CountModule(currentHp) + " HP";

        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Damage");

        /*if (currentHp <= 0)
        {

            stageManager.smallstageCount = stageManager.smallstageCount + 1;
            stageManager.smallStageChange();
            for (int i = 0; i < 10; i++)
            {

                int randomGold = Random.Range(stageManager.mainStageCount, (stageManager.mainStageCount + stageManager.mainStageCount) + 1);
                player.gold = player.gold + (randomGold * 2);
                player.goldText.text = player.gold.ToString();
            }

            smallStageMenu_Setting.foodChangeIndex++;
            smallStageMenu_Setting.Food_Change();

        }*/

    }


    public void Skill2Damage()
    {
        currentHp -= skill2.power;
        hp_Bar.fillAmount = currentHp / maxHP;
        Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
        //hp_Text.text = currentHp.ToString("N1") + " HP";
        hp_Text.text = CountModule(currentHp) + " HP";

        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Damage");

        /*if (currentHp <= 0)
        {
            stageManager.smallstageCount = stageManager.smallstageCount + 1;
            stageManager.smallStageChange();
            smallStageMenu_Setting.foodChangeIndex++;
            smallStageMenu_Setting.Food_Change();
        }*/
    }

    public void Heal()
    {
		currentHp += (player.power * 2);
		if (currentHp >= maxHP) {
			currentHp = maxHP;
		}
			hp_Bar.fillAmount = currentHp / maxHP;
			Canvas_UI_Hp_Bar.fillAmount = currentHp / maxHP;
            //hp_Text.text = currentHp.ToString("N1") +" HP";
            hp_Text.text = CountModule(currentHp) + " HP";

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
            return haveCount.ToString("N1");
    }
    public string CountModuleGold(float haveCount)
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
