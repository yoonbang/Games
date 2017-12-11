using UnityEngine;
using System.Collections;

public class YellowDishGather : MonoBehaviour {
    public GameObject[] yellowDishGather = new GameObject[30];
    public Transform[] yellowDishTransfrom = new Transform[30];

    public Player_Ctrl_PC player;
    public SmallStageMenu_Setting smallStageMenu_Setting;
    public MainFood_Setting mainFood_Setting;

    public int index = 0;

    public GameObject effect;
    public Transform effectTransform;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
    }

    public void yellowDishGatherPlus()
    {
        if (index < 30)
        {
            yellowDishGather[index] = Instantiate(Resources.Load("Yellow_Gather"), Vector3.zero, Quaternion.identity) as GameObject;
            yellowDishGather[index].transform.SetParent(yellowDishTransfrom[index].transform, false);
            yellowDishGather[index].transform.position = yellowDishTransfrom[index].transform.position;

            index++;
        }

        else
        {
            for (int i = 0; i < yellowDishGather.Length; i++)
            {
                Destroy(yellowDishGather[i]);
            }
            if (player.mainStage == false)
            {
                smallStageMenu_Setting.GetComponentInChildren<SmallStageMenu>().Damage((player.power) * 3);
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
