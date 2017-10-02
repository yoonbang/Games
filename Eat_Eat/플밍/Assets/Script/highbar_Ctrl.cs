using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum HighbarState
{
    Idle,
    playhighbar,
}
public class highbar_Ctrl : MonoBehaviour {
    public int x, y;

    public float fTickTime=3.0f;

    public HighbarState HS;
    public GameObject textbox; 
    public TextMesh SecondText;
   

    void Start () {
        HS = HighbarState.Idle;
    }
	
	// Update is called once per frame
	void Update () {
        if (HS == HighbarState.playhighbar)
        {
            textbox.SetActive(true);
           
            SecondText.text = (Mathf.Ceil(fTickTime)).ToString();

            GameObject player = null;
            player = GameObject.Find("Player");
            Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

            GameObject blockmanager = null;
            blockmanager = GameObject.Find("Block_Manager");
            Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

            
            fTickTime -= Time.deltaTime;

            if (fTickTime <= 0 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                PC.rigi.AddForce(new Vector3(0, PC.vaulting_box_Jump_Power, 0)); // Player 멀리 날리기
                BMC.Block_Move_Speed = 13.0f;

                textbox.SetActive(false);
                HS = HighbarState.Idle; // Idle 상태로 변환하여 if을 나간다
            }
            else if (fTickTime <= -1.0f)
            {
                Application.LoadLevel("Stage1");
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject blockmanager = null;
        blockmanager = GameObject.Find("Block_Manager");
        Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

        GameObject player = null;
        player = GameObject.Find("Player");
        Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

        if (col.gameObject.name == "Player")
        {
            BMC.Block_Move_Speed = 0f;

            HS = HighbarState.playhighbar;
        }
    }
}








/* 올림, 반올림, 버림 공부
    double doubleValue = 12.34d;
    Math.Ceiling(doubleValue);// 올림
    Math.Round(doubleValue); // 반올림
    Math.Truncate(doubleValue);// 버림
*/
