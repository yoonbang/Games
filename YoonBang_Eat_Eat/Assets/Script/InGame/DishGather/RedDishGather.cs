using UnityEngine;
using System.Collections;

public class RedDishGather : MonoBehaviour {
    public GameObject[] redDishGather = new GameObject[30];
    public Transform[] redDishTransfrom = new Transform[30];
    public int index = 0;

    public void redDishGatherPlus()
    {
        if (index < 30)
        {
            redDishGather[index] = Instantiate(Resources.Load("Red_Gather"), Vector3.zero, Quaternion.identity) as GameObject;
            redDishGather[index].transform.SetParent(redDishTransfrom[index].transform, false);
            redDishGather[index].transform.position = redDishTransfrom[index].transform.position;

            index++;
        }
        else
        {
            for(int i = 0; i<redDishGather.Length;i++)
            {
                Destroy(redDishGather[i]);
            }
            index = 0;
        }
    }
}
