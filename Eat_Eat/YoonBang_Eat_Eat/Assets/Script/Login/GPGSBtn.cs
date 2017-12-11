using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GPGSBtn : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GPGSMng.GetInstance.InitializeGPGS();      
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ClickEvent()
    {
        if (GPGSMng.GetInstance.bLogin == false)
        {
            Debug.Log("Login");
        }
        else
        {
            Debug.Log("LogOut");
        }
    }
}
