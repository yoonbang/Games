using UnityEngine;
using System.Collections;

public class TheDishesDamegeDouble : MonoBehaviour {
    public float fDestroyTime = 10f;
    public float fTickTime;

    MainSpoonAnimation mainSpoon;
    MainChopsticAnimation mainChopstic;
    MainKnifeAnimation mainKnife;
    MainForksAnimation mainForks;
    Skill5_Button skill5;
    // Use this for initialization
    void Start () {
        mainSpoon = GameObject.FindGameObjectWithTag("MainSpoon").GetComponent<MainSpoonAnimation>();
        mainChopstic = GameObject.FindGameObjectWithTag("MainChopstic").GetComponent<MainChopsticAnimation>();
        mainKnife = GameObject.FindGameObjectWithTag("MainKnife").GetComponent<MainKnifeAnimation>();
        mainForks = GameObject.FindGameObjectWithTag("MainForks").GetComponent<MainForksAnimation>();
        skill5 = GameObject.Find("Skill5_Button").GetComponent<Skill5_Button>();
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
        mainSpoon.power = skill5.mainSpoonDamage;
        mainChopstic.power = skill5.mainChopsticDamege;
        mainKnife.power = skill5.mainKnifeDamege;
        mainForks.power = skill5.mainForksDamege;

        Destroy(this.gameObject);
    }
}
