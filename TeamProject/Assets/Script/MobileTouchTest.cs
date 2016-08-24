using UnityEngine;
using System.Collections;

public class MobileTouchTest : MonoBehaviour {
    //int count;
    // Use this for initialization
    GameObject test1;
    void Start() {

    }

    void Update()
    {
        int count = Input.touchCount;
        if (count == 0) return; //할 일이 없다.

        for (int i = 0; i<count; i++){
            Touch touch = Input.GetTouch(i);
            Debug.Log("id:" + touch.fingerId + ",phase:" + touch.phase);
        }
        GameObject fx = Instantiate(test1) as GameObject;
    }
}
