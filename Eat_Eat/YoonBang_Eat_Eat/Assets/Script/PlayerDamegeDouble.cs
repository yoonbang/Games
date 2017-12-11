using UnityEngine;
using System.Collections;

public class PlayerDamegeDouble : MonoBehaviour {
    public float fDestroyTime = 10f;
    public float fTickTime;
    Player_Ctrl_PC pc;
    Skill6_Button skill6;
    // Use this for initialization
    void Start () {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        skill6 = GameObject.Find("Skill6_Button").GetComponent<Skill6_Button>();
    }
	
	// Update is called once per frame
	void Update () {
        fTickTime += Time.deltaTime;

        if (fTickTime >= fDestroyTime)
        {
            DamegeDoubleFinish();
        }
    }

    public void DamegeDoubleFinish()
    {
        pc.power = skill6.playerDamege;
        Destroy(this.gameObject);
    }
}
