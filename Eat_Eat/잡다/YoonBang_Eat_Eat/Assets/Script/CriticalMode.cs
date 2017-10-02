using UnityEngine;
using System.Collections;

public class CriticalMode : MonoBehaviour {
    public float fDestroyTime = 10f;
    public float fTickTime;
    Player_Ctrl_PC pc;
    Skill3Button skill3;

    // Use this for initialization
    void Start () {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        skill3 = GameObject.FindGameObjectWithTag("Skill3").GetComponent<Skill3Button>();
    }

    // Update is called once per frame
    void Update()
    {
        fTickTime += Time.deltaTime;

        if (fTickTime >= fDestroyTime)
        {
            Critical();
        }
    }
    public void Critical()
    {
        pc.criticalInt = skill3.criticalInt;
        Destroy(this.gameObject);
    }
}
