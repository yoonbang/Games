using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StageManager : MonoBehaviour {
    public int smallstageCount = 1;
    public int mainStageCount = 1;

    int randomStage;
    int randomMax;

    public float smallStageHp = 20.0f;
    public float mainStageHp = 30.0f;

    public GameObject mainStageSlot1,mainStageSlot2,mainStageSlot3 ;

    public SmallStageMenu_Setting smallStageMenu_Setting;
    public MainFood_Setting mainFood_Setting;

    public Text smallstageText;

    public Text mainStageText1, mainStageText2, mainStageText3;

    public Sprite[] mainStageImage = new Sprite[500];
    public Sprite NoImage;

    public Image bonusTimerBar;

    public float currentBonusTime=0f;
    public float maxBonusTime = 5f;

    void Start()
    {
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        randomMax = mainStageImage.Length;

        if (mainStageCount == 1)
        {
            randomStage = Random.Range(1, randomMax);
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            randomStage = Random.Range(1, randomMax);
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount+1).ToString();
        }
        else
        {
            randomStage = Random.Range(1, randomMax);
            mainStageSlot1.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            randomStage = Random.Range(1, randomMax);
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            randomStage = Random.Range(1, randomMax);
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            mainStageText1.text = (mainStageCount - 1).ToString();
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
        smallstageText.text = smallstageCount.ToString() + " / 10";
    }

    public void mainStageChange()
    {
        /*if (mainStageCount == 1)
        {
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount + 1];
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }*/
        if (mainStageCount == 1)
        {
            randomStage = Random.Range(1, randomMax);
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            randomStage = Random.Range(1, randomMax);
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
        else
        {
            randomStage = Random.Range(1, randomMax);
            mainStageSlot1.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            randomStage = Random.Range(1, randomMax);
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            randomStage = Random.Range(1, randomMax);
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[randomStage];
            mainStageText1.text = (mainStageCount - 1).ToString();
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
    }
    public void smallStageChange()
    {
        smallstageText.text = smallstageCount.ToString() + " / 10";
    }

    public void MainStageSetting()
    {
        if (mainStageCount == 1)
        {
            mainFood_Setting.GetComponentInChildren<MainFood>().maxHP = mainStageHp;
            mainFood_Setting.GetComponentInChildren<MainFood>().currentHp = mainStageHp;

            mainFood_Setting.GetComponentInChildren<MainFood>().maxTimer = 30.0f + currentBonusTime;
            mainFood_Setting.GetComponentInChildren<MainFood>().currentTimer = mainFood_Setting.GetComponentInChildren<MainFood>().maxTimer;
            currentBonusTime = 0f;

            bonusTimerBar.fillAmount = currentBonusTime / maxBonusTime;

            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().Canvas_UI_Hp_Bar.fillAmount = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp / mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().maxHP;
            //mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().hp_Text.text = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp.ToString("N1") + "HP";
            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().hp_Text.text = CountModule(mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp) + " HP";
            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().mainMenuName.text = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().Name_String;
        }
        else
        {
            mainStageHp = mainStageHp * 1.77f;

            
            mainFood_Setting.GetComponentInChildren<MainFood>().maxHP = mainStageHp;
            mainFood_Setting.GetComponentInChildren<MainFood>().currentHp = mainStageHp;

            mainFood_Setting.GetComponentInChildren<MainFood>().maxTimer = 30.0f + currentBonusTime;
            mainFood_Setting.GetComponentInChildren<MainFood>().currentTimer = mainFood_Setting.GetComponentInChildren<MainFood>().maxTimer;
            currentBonusTime = 0f;

            bonusTimerBar.fillAmount = currentBonusTime / maxBonusTime;

            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().Canvas_UI_Hp_Bar.fillAmount = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp / mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().maxHP;
            //mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().hp_Text.text = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp.ToString("N1") + "HP";
            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().hp_Text.text = CountModule(mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp) + " HP";
            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().mainMenuName.text = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().Name_String;

        }
    }

    public void SmallStageSetting()
    {
        if (mainStageCount == 1)
        {
            smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().maxHP = smallStageHp;
            smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().currentHp = smallStageHp;

            smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().Canvas_UI_Hp_Bar.fillAmount = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp / smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().maxHP;
            //smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().hp_Text.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp.ToString("N1") + " HP";
            smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().hp_Text.text = CountModule(smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp) + " HP";
            smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().smallMenuName.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().Name_String;
        }
        smallStageHp = smallStageHp * 1.62f;
        smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().maxHP = smallStageHp;
        smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().currentHp = smallStageHp;

        smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().Canvas_UI_Hp_Bar.fillAmount = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp / smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().maxHP;
        //smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().hp_Text.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp.ToString("N1") + "HP";
        smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().hp_Text.text = CountModule(smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp) + " HP"; 
        smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().smallMenuName.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().Name_String;
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
            return haveCount.ToString();
    }
}
