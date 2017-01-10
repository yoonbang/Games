using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill6_Button : MonoBehaviour {
    public Image img;
    public Button btn;
    public float cooltime = 3.0f;
    public Text minuteText;
    float leftTime = 0f;
    int minute = 0;
    float second = 0f;
    // Use this for initialization
    public Player_Ctrl_PC pc;
    public float playerDamege = 0f;

    public GameObject DamageDouble_Effect;
    public Transform DamageDouble_Effect_Transfrom;
    // Use this for initialization
    void Start () {
        if (img == null)
            img = gameObject.GetComponent<Image>();
        if (btn == null)
            btn = gameObject.GetComponent<Button>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
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
            playerDamege = pc.power;
            pc.power = pc.power*2;

            GameObject DamageDoubleEffect = Instantiate(DamageDouble_Effect, Vector3.zero, Quaternion.identity) as GameObject;
            DamageDoubleEffect.transform.SetParent(DamageDouble_Effect_Transfrom.transform, false);
            DamageDoubleEffect.transform.position = DamageDouble_Effect_Transfrom.transform.position;


            if (btn)
            {
                btn.enabled = false;
            }
        }
    }

}
