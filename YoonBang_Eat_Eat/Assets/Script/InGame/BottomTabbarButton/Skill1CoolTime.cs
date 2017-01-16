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
    SustainmentTime stt;

    void Start () {
        if (img == null)
            img = gameObject.GetComponent<Image>();
        if (btn == null)
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        stt = GameObject.FindGameObjectWithTag("STI").GetComponent<SustainmentTime>();
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
            pc.superFiverMode = 50f;
            pc.ps = PlayerState.SuperFiverMode;
            pc.Super_Fiver_Mode();
            SustainmentTimeInformationIcon();
            if (btn)
                btn.enabled = false;
        }
    }
    public void SustainmentTimeInformationIcon()
    {
        for (int i = 0; i < stt.SustainmentTimeInformationIcon.Length; i++)
        {
            if (stt.SustainmentTimeInformationIcon[0] == null)
            {
                stt.SustainmentTimeInformationIcon[0] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[0].transform.SetParent(stt.slotTransform[0].transform, false);
                stt.SustainmentTimeInformationIcon[0].transform.position = stt.slotTransform[0].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[1] == null)
            {
                stt.SustainmentTimeInformationIcon[1] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[1].transform.SetParent(stt.slotTransform[1].transform, false);
                stt.SustainmentTimeInformationIcon[1].transform.position = stt.slotTransform[1].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[2] == null)
            {
                stt.SustainmentTimeInformationIcon[2] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[2].transform.SetParent(stt.slotTransform[2].transform, false);
                stt.SustainmentTimeInformationIcon[2].transform.position = stt.slotTransform[2].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[3] == null)
            {
                stt.SustainmentTimeInformationIcon[3] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[3].transform.SetParent(stt.slotTransform[3].transform, false);
                stt.SustainmentTimeInformationIcon[3].transform.position = stt.slotTransform[3].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[4] == null)
            {
                stt.SustainmentTimeInformationIcon[4] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[4].transform.SetParent(stt.slotTransform[4].transform, false);
                stt.SustainmentTimeInformationIcon[4].transform.position = stt.slotTransform[4].transform.position;

                return;
            }

            else if (stt.SustainmentTimeInformationIcon[5] == null)
            {
                stt.SustainmentTimeInformationIcon[5] = Instantiate(stt.skillBlessTime[1]) as GameObject;
                stt.SustainmentTimeInformationIcon[5].transform.SetParent(stt.slotTransform[5].transform, false);
                stt.SustainmentTimeInformationIcon[5].transform.position = stt.slotTransform[5].transform.position;

                return;
            }
        }
    }
}
