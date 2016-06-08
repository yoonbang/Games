using UnityEngine;
using System.Collections;


public enum CannonState
{
    Idle,
    Cannon_Bomb // 대포발사
}
public class Cannon_Ctrl : MonoBehaviour {
    public CannonState CS;

    public float fDestroyTime = 0f; // 딜레이시간
    public float Speed = 0f;
    public int x, y;

    public AudioClip Cannon_Sound;

    public TextMesh Cannon_text;

    public float CurrentCannon = 0f;
    public float MaxCannon = 30f;

    public UISprite Cannon_Gauge;
    void Start()
    {
        CS = CannonState.Idle;
    }

    void Update()
    {
        Cannon_text.text = (Mathf.Ceil(fDestroyTime)).ToString();

        if (CS == CannonState.Cannon_Bomb)
        {
            GameObject player = null;
            player = GameObject.Find("Player");
            Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

            GameObject blockmanager = null;
            blockmanager = GameObject.Find("Block_Manager");
            Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

            BMC.Block_Move_Speed = 0f;

            fDestroyTime -= Time.deltaTime;
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                CurrentCannon += 1.0f;
                Cannon_Gauge.fillAmount = CurrentCannon / MaxCannon;
            }

            if (fDestroyTime <= 0 && CurrentCannon >= MaxCannon)
            {
                GetComponent<AudioSource>().clip = Cannon_Sound;
                GetComponent<AudioSource>().Play();

                PC.rigi.AddForce(new Vector3(x, y, 0)); // Player 멀리 날리기

                BMC.Block_Move_Speed = Speed; // 맵 이동

                CS = CannonState.Idle;    
            }
            if(fDestroyTime <= 0 && CurrentCannon <= MaxCannon)
            {
                Application.LoadLevel("Stage1");
            }
        }    
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            CS = CannonState.Cannon_Bomb;
        }
    }
}


