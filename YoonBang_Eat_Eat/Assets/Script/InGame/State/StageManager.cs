using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StageManager : MonoBehaviour {
    public int smallstageCount = 1;
    public int mainStageCount = 1;

    public GameObject mainStageSlot1,mainStageSlot2,mainStageSlot3 ;
    

    public Text smallstageText;

    public Text mainStageText1, mainStageText2, mainStageText3;

    public Sprite[] mainStageImage = new Sprite[500];

    void Start()
    {
        if (mainStageCount == 1)
        {
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount+1];
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount+1).ToString();
        }
        else
        {
            mainStageSlot1.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount-1];
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount + 1];
            mainStageText1.text = (mainStageCount - 1).ToString();
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
        smallstageText.text = smallstageCount.ToString() + " / 10";
    }

    public void mainStageChange()
    {
        if (mainStageCount == 1)
        {
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount + 1];
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
        else
        {
            mainStageSlot1.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount - 1];
            mainStageSlot2.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount];
            mainStageSlot3.gameObject.GetComponent<Image>().sprite = mainStageImage[mainStageCount + 1];
            mainStageText1.text = (mainStageCount - 1).ToString();
            mainStageText2.text = mainStageCount.ToString();
            mainStageText3.text = (mainStageCount + 1).ToString();
        }
    }
    public void smallStageChange()
    {
        smallstageText.text = smallstageCount.ToString() + " / 10";
    }

}
