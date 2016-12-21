using UnityEngine;
using System.Collections;

public class BlueDishGather : MonoBehaviour {
    public GameObject[] blueDishGather = new GameObject[30];
    public Transform[] blueDishTransfrom = new Transform[30];

    public int index=0;

    public Player_Ctrl_PC player;
    public SmallStageMenu_Setting smallStageMenu_Setting;
    public MainFood_Setting mainFood_Setting;

    public GameObject effect;
    public Transform effectTransform;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        smallStageMenu_Setting = GameObject.FindGameObjectWithTag("SmallStageMenu_Setting").GetComponent<SmallStageMenu_Setting>();
        mainFood_Setting = GameObject.FindGameObjectWithTag("MainFood_Setting").GetComponent<MainFood_Setting>();
    }

    public void blueDishGatherPlus()
    {
        if (index < 30)
        {
            blueDishGather[index] = Instantiate(Resources.Load("Blue_Gather"), Vector3.zero, Quaternion.identity) as GameObject;
            blueDishGather[index].transform.SetParent(blueDishTransfrom[index].transform,false);
            blueDishGather[index].transform.position= blueDishTransfrom[index].transform.position;

            index++;
        }

        else
        {
            for (int i = 0; i < blueDishGather.Length; i++)
            {
                Destroy(blueDishGather[i]);
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
