using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainSpoonLevelManager : MonoBehaviour {
    MainSpoonAnimation mainSpoonAnimation;
    Player_Ctrl_PC player;
    public Text GoldText;
    public Text mainSpoonLevel;
    public Text mainSpoonDamage;
    public int LevelUpPoint = 0;

    // Use this for initialization
    void Start () {
        mainSpoonAnimation = GameObject.FindGameObjectWithTag("MainSpoon").GetComponent<MainSpoonAnimation>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();

        LevelUpPoint = (mainSpoonAnimation.level * mainSpoonAnimation.level) * 30;
        GoldText.text = LevelUpPoint.ToString();
        mainSpoonLevel.text = "Level " + mainSpoonAnimation.level.ToString();
        mainSpoonDamage.text = mainSpoonAnimation.power.ToString("N1");

    }
    // Update is called once per frame
    public void LevelUp()
    {
        if (player.gold >= LevelUpPoint)
        {
            mainSpoonAnimation.level += 1;
            player.gold -= LevelUpPoint;
            player.goldText.text = player.gold.ToString();

            LevelUpPoint = (mainSpoonAnimation.level * mainSpoonAnimation.level) * 30;

            mainSpoonAnimation.power = mainSpoonAnimation.power + (mainSpoonAnimation.power * 0.5f);

            GoldText.text = LevelUpPoint.ToString();
            mainSpoonLevel.text = "Level " + mainSpoonAnimation.level.ToString();
            mainSpoonDamage.text = mainSpoonAnimation.power.ToString("N1");

        }
    }
}
