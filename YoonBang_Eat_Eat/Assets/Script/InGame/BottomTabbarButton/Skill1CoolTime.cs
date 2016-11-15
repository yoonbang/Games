using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Skill1CoolTime : MonoBehaviour {
    public Image img;
    public UnityEngine.UI.Button btn;
    public float cooltime = 3.0f;
    public Text minuteText;
    float leftTime = 0f;
	int minute=0;
	float second=0f;

    // Use this for initialization
    public Player_Ctrl_PC pc;
    void Start () {
        if (img == null)
            img = gameObject.GetComponent<Image>();
        if (btn == null)
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
    }

    // Update is called once per frame
    public void Update () {
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
			if (leftTime >= 60f) {
				minute=(int)(leftTime/60f);
				second = (int)(leftTime - (minute * 60));
			}  else {
				minute = 0;
				second = leftTime;
			}

            minuteText.enabled = true;
            leftTime -= Time.deltaTime;

			minuteText.text = minute.ToString("00")+" : " +second.ToString ("00");

            if (leftTime < 0)
            {
                leftTime = 0;
                minuteText.enabled = false;
                if(btn)
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
        if(leftTime==0 && btn.enabled == true)
        {
            leftTime = cooltime;
            pc.superComboMode_Count = 21f;
            pc.ps = PlayerState.Combo;
            pc.Combo_Mode();

            if (btn)
                btn.enabled = false;
        }
    }
}
