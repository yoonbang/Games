using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {
    public Player_Ctrl_PC player;
    public Text GoldText;
    public Text playerLevel;
    public int LevelUpPoint = 0;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        LevelUpPoint = (player.level * player.level)*50;
        GoldText.text = LevelUpPoint.ToString();
        playerLevel.text ="Level " + player.level.ToString();
    }
    public void LevelUp()
    {
            if (player.gold >= LevelUpPoint)
            {
                player.level += 1;
                player.gold -= LevelUpPoint;
                player.goldText.text = player.gold.ToString();

                LevelUpPoint = (player.level * player.level) * 50;

                player.power = player.power + (player.power * 0.5f);

                GoldText.text = LevelUpPoint.ToString();
                playerLevel.text = "Level " + player.level.ToString();

            }
    }
}
