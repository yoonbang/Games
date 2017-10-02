using UnityEngine;
using System.Collections;


//FSMBase 를 상속받는다.
public class FSMEnemy : FSMBase
{
    //몬스터 파라메타
    public float walkSpeed = 1.5f;
    public float runSpeed = 3.0f;

    public float turnSpeed = 360.0f;
    public int currentHP = 100;
    public int maxHP = 100;
    public int level = 1;
    public float attack = 10.0f;
    public float attackRange = 1.5f;
    public float restTime = 1.5f;  // 순찰 주기

    public float FindRange = 50f; //순찰 동선 변수

    Transform player;
    FSMPlayer_Mobile fsmPlayer;
    
    public Transform finish,hit_position;
    public GameObject hp_Bar;
    public GameObject hit_Effect;

    protected override void Awake()
    {
        //FSMBase 의 Awake() 를 호출한다. (캐릭터컨트롤러와 Animator)
        base.Awake();
        finish = GameObject.FindGameObjectWithTag("Finish").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fsmPlayer = player.GetComponent<FSMPlayer_Mobile>();

    }


protected override void OnEnable()
    {

        //wayPoints 배열에 waypoint 들의 위치값을 담는다.
        base.OnEnable();
    }



    protected override IEnumerator Idle()
    {
        do
        {
            yield return null;


            //순찰 쿨타임 완료를 체크한다.
            if (Vector3.Distance(finish.position, transform.position) >= FindRange)
            {

                SetState(CharacterState.Run);
                break;
            }
        } while (!isNewState);
    }

    protected virtual IEnumerator Run()
    {

        //랜덤으로 wayPoint 중 1개의 좌표를 target 좌표에 담는다.
        do
        {

            yield return null;


            if (MoveUtil.MoveFrame(characterController, finish, walkSpeed, turnSpeed) == 0)
            {
                //목표지점에 도착하면 Idle 상태로 바꾼다.
                SetState(CharacterState.Idle);
                break;
            }
        } while (!isNewState);
    }

    protected virtual IEnumerator Attack()
    {
        do
        {
            yield return null;


        } while (!isNewState);
    }

    protected virtual IEnumerator AttackRun()
    {
        do
        {
            yield return null;


        } while (!isNewState);
    }

    protected virtual IEnumerator Dead()
    {
        do
        {
            yield return null;
            Destroy(this.gameObject);

        } while (!isNewState);
    }

    public void ProcessDamage()
    {
        currentHP -= (int)fsmPlayer.attack;
        decreasehealth();
        if (currentHP <= 0)
        {
            SetState(CharacterState.Dead);
            currentHP = 0;
            return;
        }
    }

    void decreasehealth()
    {
        float calc_Health = (float)currentHP/(float)maxHP;
        SetHealthBar(calc_Health);
    }

    public void SetHealthBar(float myHealth)
    {
        //GameObject FX = Instantiate(hit_Effect, hit_position.position, Quaternion.LookRotation(hit_position.forward)) as GameObject;
        hp_Bar.transform.localScale = new Vector3(myHealth, hp_Bar.transform.localScale.y, hp_Bar.transform.localScale.z);
    }

}