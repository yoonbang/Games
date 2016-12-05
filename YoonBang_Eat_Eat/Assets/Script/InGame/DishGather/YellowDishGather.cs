using UnityEngine;
using System.Collections;

public class YellowDishGather : MonoBehaviour {
    public GameObject[] yellowDishGather = new GameObject[30];
    public Transform[] yellowDishTransfrom = new Transform[30];

    public int index = 0;

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
            index = 0;
        }
    }
}
