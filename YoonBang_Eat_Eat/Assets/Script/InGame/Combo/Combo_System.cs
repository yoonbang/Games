using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum Combo_State
{
    Idle,
    Eat,
    SuperMode,

}
public class Combo_System : MonoBehaviour {
    public GameObject combo_Object;
    public Text combo_Text;
    public Transform combo_Position;
    public Transform combo_Gaze_Position;
    public Transform Fiver_Position;
    public Image combo_Gaze;
    public GameObject combo_Gaze_Object;
    public GameObject fiver_Map;
    public Player_Ctrl_PC pc;
    public Combo_State cs;


    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
        combo_Text.text = pc.combo_Count.ToString()+" Combo";
        combo_Gaze.fillAmount = pc.superComboMode_Count / pc.maxCombo;
    }
    void Update()
    {
        if (combo_Object == null)
        {
            if (combo_Gaze_Object == null)
            {

            }
            else if(combo_Gaze_Object!=null)
            {
                Destroy(combo_Gaze_Object);
            }
        }
        if(cs== Combo_State.SuperMode)
        {
            pc.superComboMode_Count -= Time.deltaTime * 3;
            fiver_Map.SetActive(true);
            Super_Combo_Play();
        }

    }
    public void combo_Strike()
    {
        if (cs != Combo_State.SuperMode)
        {
            if (combo_Object == null)
            {
                combo_Text.text = pc.combo_Count.ToString() + " Combo";
                combo_Object = Instantiate(Resources.Load("Combo_Text_Object"), Vector3.zero, Quaternion.identity) as GameObject;
                combo_Object.transform.SetParent(combo_Position.transform,false);
                combo_Object.transform.position = combo_Position.transform.position;
                
                combo_Gaze_Object = Instantiate(Resources.Load("ComboGaze"), Vector3.zero, Quaternion.identity) as GameObject;
                combo_Gaze_Object.transform.SetParent(combo_Gaze_Position.transform,false);
                combo_Gaze_Object.transform.position = combo_Gaze_Position.transform.position;
                combo_Object.SetActive(true);
                combo_Gaze.fillAmount = pc.superComboMode_Count / pc.maxCombo;


                cs = Combo_State.Eat;
            }

            if (combo_Object != null)
            {
                Destroy(combo_Object);
                Destroy(combo_Gaze_Object);

                combo_Text.text = pc.combo_Count.ToString() + " Combo";
                combo_Object = Instantiate(Resources.Load("Combo_Text_Object"), Vector3.zero, Quaternion.identity) as GameObject;
                combo_Object.transform.SetParent(combo_Position.transform,false);
                combo_Object.transform.position = combo_Position.transform.position;
                

                combo_Gaze.fillAmount = pc.superComboMode_Count / pc.maxCombo;
                combo_Gaze_Object = Instantiate(Resources.Load("ComboGaze"), Vector3.zero, Quaternion.identity) as GameObject;
                combo_Gaze_Object.transform.SetParent(combo_Gaze_Position.transform,false);
                combo_Gaze_Object.transform.position = combo_Gaze_Position.transform.position;

                cs = Combo_State.Eat;

            }
        }
    }

    public void Combo_Mode()
    {
        Destroy(combo_Object);
        Destroy(combo_Gaze_Object);

        combo_Gaze.fillAmount = pc.superComboMode_Count / pc.maxCombo;

        combo_Object = Instantiate(Resources.Load("SuperCombo_Text_Object"), Vector3.zero, Quaternion.identity) as GameObject;
        combo_Object.transform.SetParent(Fiver_Position.transform,false);
        combo_Object.transform.position = Fiver_Position.transform.position;

        combo_Gaze_Object = Instantiate(Resources.Load("ComboGaze"), Vector3.zero, Quaternion.identity) as GameObject;
        combo_Gaze_Object.transform.SetParent(combo_Gaze_Position.transform,false);
        combo_Gaze_Object.transform.position = combo_Gaze_Position.transform.position;

        cs = Combo_State.SuperMode;
    }

    public void Super_Combo_Play()
    {
        combo_Gaze.fillAmount = pc.superComboMode_Count / pc.maxCombo;
        combo_Gaze_Position.FindChild("ComboGaze(Clone)").FindChild("Gaze").GetComponent<Image>().fillAmount = pc.superComboMode_Count / pc.maxCombo;
        
        if (pc.superComboMode_Count<=0)
        {
            Destroy(combo_Object);
            Destroy(combo_Gaze_Object);
            pc.superComboMode_Count = 0f;
            fiver_Map.SetActive(false);
            combo_Text.text = pc.combo_Count.ToString()+" Combo";
            cs = Combo_State.Idle;
            pc.ps = PlayerState.Idle;
        }
    }
}
