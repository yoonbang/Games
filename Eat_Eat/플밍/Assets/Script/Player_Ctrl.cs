using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Idle, 
    vaulting_box_Jump, // 뜀틀 점프
    flying_stunt_Jump, // 공중곡예 점프
    high_bar_Jump,  // 철봉 점프
    Jump_Possible,
    flying_Possible,
    Death,
}
public class Player_Ctrl : MonoBehaviour {
    public PlayerState PS;
    public Rigidbody rigi;
    public float vaulting_box_Jump_Power = 700f;
    public float flying_stunt_Jump_Power = 800f;
    public float Touch_Power = 800f;


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
           }
           if(PS==PlayerState.flying_Possible && PS!=PlayerState.flying_stunt_Jump)
           {
              flying_stunt_Jump_Play();
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
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="vaulting_box")
        {
            PS = PlayerState.Idle;
            PS = PlayerState.Jump_Possible;
        }
        if(col.gameObject.tag=="Ground")
        {
            Application.LoadLevel("Stage1");  //죽었을 때 처음으로 돌아감
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
