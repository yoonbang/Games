using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Idle,
    Run,
    Jump,
    touch,
    D_Jump,
    Death,
    Jump_Possible,
    Touch_Possible
}
public class Player_Ctrl : MonoBehaviour {
    public PlayerState PS;
    public Rigidbody rigi;
    public float Jump_Power = 800f;
    public float Touch_Power = 800f;
    public Quaternion Art = Quaternion.identity;
    public float rotateSpeed = 1f;

    public float artturntime = 2.0f;
    public float jumparttime = 3.0f;

    public Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {

        if (PS == PlayerState.Idle)
        {

        }

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (PS == PlayerState.Jump_Possible)
            {
                Jump();
                ArtTurn();


                PS = PlayerState.Idle;
            }
            else if (PS == PlayerState.Touch_Possible)
            {
                touch();
                ArtJump();

                PS = PlayerState.Idle;
            }

        }
    }  
    
    
    
    public void Jump()
    {
        PS = PlayerState.Jump;
        rigi.AddForce(new Vector3(0, Jump_Power, 0));
    }

    public void touch()
    {
        PS = PlayerState.touch;
        rigi.AddForce(new Vector3(0, Touch_Power, 0));
      
    }
   
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="jump" && PS!=PlayerState.Jump_Possible)
        {
            PS = PlayerState.Jump_Possible;
        }
    }
    void CoinGet()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Coin")
        {
            Destroy(other.gameObject);
            CoinGet();
        }
        if(other.gameObject.tag=="Touch")
        {
            PS = PlayerState.Touch_Possible;
        }
    }

    public void ArtTurn()
    {
        anim.SetTrigger("Turn90");
    }

    public void ArtJump()
    {
        anim.SetTrigger("Turn");
    }

}
