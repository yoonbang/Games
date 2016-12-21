using UnityEngine;
using System.Collections;

public class GreenDishGather : MonoBehaviour {
    public GameObject[] greenDishGather = new GameObject[30];
    public Transform[] greenDishTransfrom = new Transform[30];

    public Player_Ctrl_PC player;
    public SmallStageMenu_Setting smallStageMenu_Setting;
    public MainFood_Setting mainFood_Setting;

    public GameObject effect;
    public Transform effectTransform;

    public int index = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
    }
    public void greenDishGatherPlus()
    {
        if (index < 30)
        {
            greenDishGather[index] = Instantiate(Resources.Load("Green_Gather"), Vector3.zero, Quaternion.identity) as GameObject;
            greenDishGather[index].transform.SetParent(greenDishTransfrom[index].transform, false);
            greenDishGather[index].transform.position = greenDishTransfrom[index].transform.position;

            index++;
        }
        else
        {
            for (int i = 0; i < greenDishGather.Length; i++)
            {
                Destroy(greenDishGather[i]);
            }
                if (player.mainStage == false)
                {
                    smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage((player.power)*3);
                }
                else
                {
                    mainFood_Setting.GetComponentInChildren<MainFood>().Damage((player.power) * 3);
                }
            index = 0;
            GameObject Effect = Instantiate(effect, Vector3.zero, Quaternion.identity) as GameObject;
            Effect.transform.SetParent(effectTransform.transform, false);
            Effect.transform.position = effectTransform.transform.position;
        }
    }
}
