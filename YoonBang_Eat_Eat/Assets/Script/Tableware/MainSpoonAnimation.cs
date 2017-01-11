using UnityEngine;
using System.Collections;

public class MainSpoonAnimation : MonoBehaviour {
    Player_Ctrl_PC player;
    MainFood_Setting mainFood_Setting;
    SmallStageMenu_Setting smallStageMenu_Setting;
    DamageTextManager damegeTextManager;

    public int startRandom, LastRandom;

    public float AttackRate = 1.5f; //총알 지연 시간 설정
    public float nextAttack = 0.0f; //다음 총알 발사시간 
    public int criticalInt = 10;
    public float power = 1f;

    public int level;
    public AudioClip mainSpoonSound;
    // Use this for initialization
    void Start () {
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        damegeTextManager= GameObject.FindGameObjectWithTag("DamageText").GetComponent<DamageTextManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + AttackRate;
            MainSpoonAnimationStart();
            AttackMenu();
        }
    }
    public void AttackMenu()
    {
        if (player.mainStage == false)
        {
            if (Random.Range(1, 101) <= criticalInt)
            {
                damegeTextManager.ciriticalMode = true;
                smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().TheDishesDamege(power * 2);
                damegeTextManager.TheDishesDamage(power * 2);
            }
            else
            {
                smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().TheDishesDamege(power);
                damegeTextManager.TheDishesDamage(power);
            }
            GetComponent<AudioSource>().clip = mainSpoonSound;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            if (Random.Range(1, 101) <= criticalInt)
            {
                damegeTextManager.ciriticalMode = true;
                mainFood_Setting.GetComponentInChildren<MainFood>().TheDishesDamege(power * 2);
            }
            else
            {
                mainFood_Setting.GetComponentInChildren<MainFood>().TheDishesDamege(power);
            }
            GetComponent<AudioSource>().clip = mainSpoonSound;
            GetComponent<AudioSource>().Play();
        }
    }

    public void MainSpoonAnimationStart()
    {
        startRandom = Random.Range(0, 1);
        {
            this.gameObject.GetComponent<Animator>().Rebind();
            this.gameObject.GetComponent<Animator>().Play("Spoon_Attack1");
        }
    }
}
