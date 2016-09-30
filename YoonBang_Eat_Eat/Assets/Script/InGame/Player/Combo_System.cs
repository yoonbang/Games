using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo_System : MonoBehaviour {
    public GameObject combo_Object;
    public Text combo_Text;
    public Transform combo_Position;

    Player_Ctrl_PC pc;
    
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        combo_Text.text = pc.combo_Count.ToString();
    }
    public void combo_Strike()
    {
        if (combo_Object == null)
        {
            combo_Object= Instantiate(Resources.Load("Combo_Text_Object")) as GameObject;
            combo_Text.text = pc.combo_Count.ToString();
            combo_Object.transform.parent = combo_Position.transform;
            combo_Object.transform.position = combo_Position.transform.position;
            Debug.Log(pc.combo_Count);
            
        }
        else if(combo_Object!=null)
        {
            Destroy(combo_Object);
            combo_Object = Instantiate(Resources.Load("Combo_Text_Object")) as GameObject;
            combo_Object.transform.parent = combo_Position.transform;
            combo_Object.transform.position = combo_Position.transform.position;
            combo_Text.text = pc.combo_Count.ToString();
            Debug.Log(pc.combo_Count);
        }
    }
}
