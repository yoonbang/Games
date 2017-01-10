using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Skill5_Button : MonoBehaviour {
    public Image img;
    public Button btn;
    public float cooltime = 3.0f;
    public Text minuteText;
    float leftTime = 0f;
    int minute = 0;
    float second = 0f;

    public GameObject TheDishesPrefab;

    MainSpoonAnimation mainSpoon;
    MainChopsticAnimation mainChopstic;
    MainKnifeAnimation mainKnife;
    MainForksAnimation mainForks;

    public float mainSpoonDamage;
    public float mainChopsticDamege;
    public float mainKnifeDamege;
    public float mainForksDamege;
    // Use this for initialization
    void Start () {
        if (img == null)
            img = gameObject.GetComponent<Image>();
        if (btn == null)
            btn = gameObject.GetComponent<Button>();

        mainSpoon=GameObject.FindGameObjectWithTag("MainSpoon").GetComponent<MainSpoonAnimation>();
        mainChopstic = GameObject.FindGameObjectWithTag("MainChopstic").GetComponent<MainChopsticAnimation>();
        mainKnife = GameObject.FindGameObjectWithTag("MainKnife").GetComponent<MainKnifeAnimation>();
        mainForks = GameObject.FindGameObjectWithTag("MainForks").GetComponent<MainForksAnimation>();
    }
	
	// Update is called once per frame
	void Update () {
        CoolTime();
    }
    public bool CheckCooltime()
    {
        if (leftTime > 0)
            return false;
        else
            return true;
    }
    public void CoolTime()
    {
        btn.enabled = true;
        if (leftTime > 0)
        {
            if (leftTime >= 59)
            {
                minute = (int)(leftTime / 60);
                second = (int)(leftTime - (minute * 60));
            }
            else if (leftTime <= 59)
            {
                minute = 0;
                second = leftTime;
            }

            minuteText.enabled = true;
            leftTime -= Time.deltaTime;

            minuteText.text = minute.ToString("00") + " : " + second.ToString("00");

            if (leftTime < 0)
            {
                leftTime = 0;
                minuteText.enabled = false;
                if (btn)
                {
                    btn.enabled = true;
                }
            }
            float ratio = 1.0f - (leftTime / cooltime);
            if (img)
                img.fillAmount = ratio;
        }
    }

    public void OnMouseUpAsButton()
    {
        if (leftTime == 0 && btn.enabled == true)
        {
            leftTime = cooltime;
            mainSpoonDamage = mainSpoon.power;
            mainChopsticDamege = mainChopstic.power;
            mainKnifeDamege = mainKnife.power;
            mainForksDamege = mainForks.power;

            mainSpoon.power = mainSpoon.power * 2;
            mainChopstic.power = mainChopstic.power * 2;
            mainKnife.power = mainKnife.power * 2;
            mainForks.power = mainForks.power * 2;

            GameObject TheDishes = Instantiate(TheDishesPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            if (btn)
            {
                btn.enabled = false;

            }
        }
    }

}
