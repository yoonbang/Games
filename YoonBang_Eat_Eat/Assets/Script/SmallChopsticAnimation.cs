using UnityEngine;
using System.Collections;

public class SmallChopsticAnimation : MonoBehaviour {
    Player_Ctrl_PC player;
    MainFood_Setting mainFood_Setting;
    SmallStageMenu_Setting smallStageMenu_Setting;
    DamageTextManager damegeTextManager;

    public int criticalInt = 10;
    public int level;
    //public AudioClip mainSpoonSound;
    public float smallPower = 0f;
    public float smallPersent = 0.2f;

    void Start()
    {
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        damegeTextManager = GameObject.FindGameObjectWithTag("DamageText").GetComponent<DamageTextManager>();
    }
    public void AttackMenu()
    {
        if (player.mainStage == false)
        {
            if (Random.Range(1, 101) <= criticalInt)
            {
                damegeTextManager.ciriticalMode = true;
                smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().SmallDishesDamege((player.power * smallPersent) * 2);
                damegeTextManager.SmallDishesDamage((player.power * smallPersent) * 2);

            }
            else
            {
                smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().SmallDishesDamege(player.power * smallPersent);
                damegeTextManager.SmallDishesDamage(player.power * smallPersent);

            }
            //GetComponent<AudioSource>().clip = mainSpoonSound;
            //GetComponent<AudioSource>().Play();
        }
        else
        {
            if (Random.Range(1, 101) <= criticalInt)
            {
                damegeTextManager.ciriticalMode = true;
                mainFood_Setting.GetComponentInChildren<MainFood>().TheDishesDamege((player.power * smallPersent) * 2);
                damegeTextManager.SmallDishesDamage((player.power * smallPersent) * 2);

            }
            else
            {
                mainFood_Setting.GetComponentInChildren<MainFood>().TheDishesDamege(player.power * smallPersent);
                damegeTextManager.SmallDishesDamage(player.power * smallPersent);

            }
            //GetComponent<AudioSource>().clip = mainSpoonSound;
            //GetComponent<AudioSource>().Play();
        }
    }
    public void SmallChopsticAttackAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Attack");
    }
}
