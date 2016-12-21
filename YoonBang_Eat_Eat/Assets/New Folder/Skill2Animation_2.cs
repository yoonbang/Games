using UnityEngine;
using System.Collections;

public class Skill2Animation_2 : MonoBehaviour {
	SmallStageMenu_Setting smallStageMenu_Setting;
	MainFood_Setting mainFood_Setting;
    Player_Ctrl_PC player;

	public float delayTime=0f;
	public float fDelayTime=3.0f;

	void Start()
	{
		smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
		mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();

    }

    public void Skill2Animation2()
	{
		if (mainFood_Setting.main_Food == null)
		{
			smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage((player.power) * 50);
			this.gameObject.GetComponent<Animator> ().Rebind ();
			this.gameObject.SetActive (false);
		}
		else
		{
			mainFood_Setting.GetComponentInChildren<MainFood>().Damage((player.power)*50);
			this.gameObject.GetComponent<Animator> ().Rebind ();
			this.gameObject.SetActive (false);
		}
	}

}
