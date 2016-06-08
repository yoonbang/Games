using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PlayerState
{
    Idle, 
    vaulting_box_Jump, // 뜀틀 점프
    flying_stunt_Jump, // 공중곡예 점프
    high_bar_Jump,  // 철봉 점프
    Jump_Possible,
    flying_Possible,
    Bonus_Time,
    Death,
}

public class Player_Ctrl : MonoBehaviour {
    public PlayerState PS;
    public Rigidbody rigi;
    public float vaulting_box_Jump_Power = 700f;
    public float flying_stunt_Jump_Power = 800f;
    public float Touch_Power = 800f;

    public float CurrentBonus=0f;
    public float MaxBonus = 50f;

    public Image bonusUI;

    public AudioClip vaulting_box_Sound, flying_stunt_Sound;

    public float runX,runY,runZ,BlockSpeed,BonusTime_CurrentBonus,BonusTime_MaxBonus; // 보너스 모드 발동시 기존값 저장 변수

    public GameObject BonusGround;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
           if(PS==PlayerState.Jump_Possible && PS!= PlayerState.vaulting_box_Jump)
           {
              vaulting_box_Jump_Play();
              CurrentBonus += 1.0f;
              bonusUI.fillAmount = CurrentBonus / MaxBonus;

              GetComponent<AudioSource>().clip = vaulting_box_Sound;
              GetComponent<AudioSource>().Play();
            }
           if(PS==PlayerState.flying_Possible && PS!=PlayerState.flying_stunt_Jump)
           {
              flying_stunt_Jump_Play();
              CurrentBonus += 1.0f;
              bonusUI.fillAmount = CurrentBonus / MaxBonus;

              GetComponent<AudioSource>().clip = flying_stunt_Sound;
              GetComponent<AudioSource>().Play();
            }
        }
        if (CurrentBonus >= MaxBonus) // 보너스 타임 불러오기
        {
            BonusTime();
            bonusUI.fillAmount = CurrentBonus / MaxBonus;
        }

        if (PS == PlayerState.Bonus_Time)
        {
            CurrentBonus -= Time.deltaTime;
            bonusUI.fillAmount = CurrentBonus / MaxBonus;
            if (CurrentBonus <= 0)
            {
                CurrentBonus = 0f;
                PS = PlayerState.Idle;
                BonusTimeFinish();
            }
        }

    }

    public void vaulting_box_Jump_Play() // 뜀틀점프 함수
    {
        PS = PlayerState.vaulting_box_Jump;
        rigi.AddForce(new Vector3(0, vaulting_box_Jump_Power, 0));
    }
    public void flying_stunt_Jump_Play()


    {
        PS = PlayerState.flying_stunt_Jump;
        rigi.AddForce(new Vector3(0, flying_stunt_Jump_Power, 0));
    }
    public void BonusTime() // 보너스타임 시작
    {
        GameObject blockmanager = null;
        blockmanager = GameObject.Find("Block_Manager");
        Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

        runX = transform.position.x-5.0f;
        runY = transform.position.y+3.0f;
        runZ = transform.position.z;

        BlockSpeed = BMC.Block_Move_Speed;
        BMC.Block_Move_Speed = 0f;
        
        Vector3 BonusPoint = new Vector3();
        BonusPoint.x = -15f;
        BonusPoint.y = -80.3f;
        BonusPoint.z = 10f;

        transform.position = BonusPoint;

        BonusTime_MaxBonus = MaxBonus;

        MaxBonus = 10f;
        CurrentBonus = 10f;

        PS = PlayerState.Bonus_Time;

        BonusGround.SetActive(true);
    }

    public void BonusTimeFinish() //보너스타임 종료
    {
        GameObject blockmanager = null;
        blockmanager = GameObject.Find("Block_Manager");
        Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

        Vector3 IdlePoint = new Vector3();
        IdlePoint.x = runX;
        IdlePoint.y = runY;
        IdlePoint.z = runZ;

        CurrentBonus = 0f;
        MaxBonus = BonusTime_MaxBonus;

        transform.position = IdlePoint;

        BMC.Block_Move_Speed = BlockSpeed;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "vaulting_box")
        {
            PS = PlayerState.Idle;
            PS = PlayerState.Jump_Possible;
        }
        if (col.gameObject.tag == "Ground")
        {
            Application.LoadLevel("Stage1");  //죽었을 때 처음으로 돌아감
        }
        if (col.gameObject.tag == "high_bar")
        {
            PS = PlayerState.Idle;
            PS = PlayerState.high_bar_Jump;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "flying_stunt")
        {
            PS = PlayerState.Idle;
            PS = PlayerState.flying_Possible;
        }
    }
}
