using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Skill1CoolTime : MonoBehaviour {
    public Image img;
    public UnityEngine.UI.Button btn;
    public float cooltime = 3.0f;
    public Text cooltimeText;
    float leftTime = 0f;
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
            cooltimeText.enabled = true;
            leftTime -= Time.deltaTime;
            cooltimeText.text = leftTime.ToString("0");
            if (leftTime < 0)
            {
                leftTime = 0;
                cooltimeText.enabled = false;
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
