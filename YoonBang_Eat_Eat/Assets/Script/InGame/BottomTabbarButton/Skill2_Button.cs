using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill2_Button : MonoBehaviour {

	public Image img;
	public UnityEngine.UI.Button btn;
	public float cooltime = 3.0f;
	public Text minuteText;
	float leftTime = 0f;
	int minute=0;
	int secondBox;
	int second=0;
    public float power=0f;
    SmallStageMenu_Setting smallStageMenu_Setting;
    MainFood_Setting mainFood_Setting;

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
			if (leftTime >= 60) {
                minute = (int)(leftTime / 60);
                second = (int)(leftTime - (minute*60));
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
            smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Skill2Damage();
            Debug.Log("허잇차");
	
		}
	}
}
