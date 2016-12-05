using UnityEngine;
using System.Collections;

public class BlueDishGather : MonoBehaviour {
    public GameObject[] blueDishGather = new GameObject[30];
    public Transform[] blueDishTransfrom = new Transform[30];
    public int index=0;

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
            index = 0;


        }
    }
}
