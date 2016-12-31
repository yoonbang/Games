using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StageManager : MonoBehaviour {
    public int smallstageCount = 1;
    public int mainStageCount = 1;

    public float smallStageHp = 20.0f;
    public float mainStageHp = 30.0f;

    public GameObject mainStageSlot1,mainStageSlot2,mainStageSlot3 ;

    public SmallStageMenu_Setting smallStageMenu_Setting;
    public MainFood_Setting mainFood_Setting;

    public Text smallstageText;

    public Text mainStageText1, mainStageText2, mainStageText3;

    public Sprite[] mainStageImage = new Sprite[500];

    void Start()
    {
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();


        if (mainStageCount == 1)
        {
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount+1];
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount+1).ToString();
        }
        else
        {
            mainStageSlot1.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount-1];
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount + 1];
            mainStageText1.text = (mainStageCount - 1).ToString();
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
        smallstageText.text = smallstageCount.ToString() + " / 10";
    }

    public void mainStageChange()
    {
        if (mainStageCount == 1)
        {
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount + 1];
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
        else
        {
            mainStageSlot1.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount - 1];
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount + 1];
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

            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().Canvas_UI_Hp_Bar.fillAmount = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp / mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().maxHP;
            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().hp_Text.text = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp.ToString() + "HP";
            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().mainMenuName.text = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().Name_String;
        }
        else
        {
            mainStageHp = mainStageHp * 1.77f;

            
            mainFood_Setting.GetComponentInChildren<MainFood>().maxHP = mainStageHp;
            mainFood_Setting.GetComponentInChildren<MainFood>().currentHp = mainStageHp;

            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().Canvas_UI_Hp_Bar.fillAmount = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp / mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().maxHP;
            mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().hp_Text.text = mainFood_Setting.main_Food.GetComponentInChildren<MainFood>().currentHp.ToString() + "HP";
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
            smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().hp_Text.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp.ToString() + " HP";
            smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().smallMenuName.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().Name_String;
        }
        smallStageHp = smallStageHp * 1.62f;
        smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().maxHP = smallStageHp;
        smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().currentHp = smallStageHp;

        smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().Canvas_UI_Hp_Bar.fillAmount = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp / smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().maxHP;
        smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().hp_Text.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().currentHp.ToString() + "HP";
        smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().smallMenuName.text = smallStageMenu_Setting.smallStageFood.GetComponentInChildren<SmallStageMenu>().Name_String;
    }
}
