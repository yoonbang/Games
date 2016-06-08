using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum HighbarState
{
    Idle,
    Highbar_Jump, // 철봉점프
}

public class highbar_Ctrl : MonoBehaviour {

    public TextMesh highbar_text;

    public float fDestroyTime = 0f; // 딜레이시간
    public float Speed = 0f;
    public float highbar_Jump_Power = 700f;

    public HighbarState HS;

    public AudioClip HighBar_Sound;
    // Use this for initialization
    void Start () {
        HS = HighbarState.Idle;
	}
	
	// Update is called once per frame
	void Update () {

        highbar_text.text = (Mathf.Ceil(fDestroyTime)).ToString();

        if (HS == HighbarState.Highbar_Jump)
        {
            GameObject player = null;
            player = GameObject.Find("Player");
            Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

            GameObject blockmanager = null;
            blockmanager = GameObject.Find("Block_Manager");
            Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

            BMC.Block_Move_Speed = 0f;

            fDestroyTime -=2f*Time.deltaTime;

            

            if (fDestroyTime <= 0 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                GetComponent<AudioSource>().clip = HighBar_Sound;
                GetComponent<AudioSource>().Play();

                PC.rigi.AddForce(new Vector3(0, highbar_Jump_Power, 0)); // Player 멀리 날리기

                BMC.Block_Move_Speed = Speed; // 맵 이동

                PC.CurrentBonus += 1.0f;
                PC.bonusUI.fillAmount = PC.CurrentBonus / PC.MaxBonus;

                HS = HighbarState.Idle;
            }

            if(fDestroyTime <= -1.0f)
            {
                Application.LoadLevel("Stage1");
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            HS = HighbarState.Highbar_Jump;
        }
    }
}
