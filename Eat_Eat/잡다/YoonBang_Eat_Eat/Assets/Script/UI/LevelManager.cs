using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {
    public Player_Ctrl_PC player;
    public Text GoldText;
    public Text playerLevel;
    public Text playerDamage;
    public float LevelUpPoint = 0f;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        LevelUpPoint = (player.level * player.level)*30;
        GoldText.text = CountModule(LevelUpPoint);
        playerLevel.text ="Level " + player.level.ToString();
        playerDamage.text = CountModuleDamege(player.power);
    }
    public void LevelUp()
    {
            if (player.gold >= LevelUpPoint)
            {
                player.level += 1;
                player.gold -= LevelUpPoint;
                player.goldText.text = CountModule(player.gold);

                LevelUpPoint = (player.level * player.level) * 30;

                player.power = player.power + (player.power * 0.5f);

                GoldText.text = CountModule(LevelUpPoint);
                playerLevel.text = "Level " + player.level.ToString();
                playerDamage.text = CountModuleDamege(player.power);

        }
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
            return haveCount.ToString("N0");
    }

    public string CountModuleDamege(float haveCount)
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
