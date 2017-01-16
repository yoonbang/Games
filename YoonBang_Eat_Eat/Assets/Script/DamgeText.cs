using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DamgeText : MonoBehaviour {

    public int animationNumber = 0;
    public Player_Ctrl_PC player;

    SmallStageMenu_Setting smallStageMenu_Setting;
    MainFood_Setting mainFood_Setting;

    public Text text;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();

        if (player.mainStage == false)
        {
            text.text = CountModule(smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().damage);
        }
        else
        {
            text.text = CountModule(mainFood_Setting.GetComponentInChildren<MainFood>().damage);
        }

        animationNumber = Random.Range(1, 3);
        if (animationNumber == 1)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack1");
        }
        if (animationNumber == 2)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack2");
        }

        Destroy(this.gameObject, 0.7f);
    }

    public string CountModule(float haveCount)
    {
        if (haveCount > 1000000000000000000)
            return string.Format("{0:#.#}G", (float)haveCount / 1000000000000000000);
        if (haveCount > 1000000000000000)
            return string.Format("{0:#.#}P", (float)haveCount / 1000000000000000);
        if (haveCount > 1000000000000)
            return string.Format("{0:#.#}T", (float)haveCount / 1000000000000);
        if (haveCount > 1000000000)
            return string.Format("{0:#.#}B", (float)haveCount / 1000000000);
        else if (haveCount > 1000000)
            return string.Format("{0:#.#}M", (float)haveCount / 1000000);
        if (haveCount > 1000)
            return string.Format("{0:#.#}K", (float)haveCount / 1000);
        else
            return haveCount.ToString("N1");
    }
}
