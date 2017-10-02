using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//FSMPlayer 는 FSMBase 로 부터 상속받는다. (FSMPlayer 는 FSMBase 의 코드 내용을 담는다 라고 생각하면 된다.)
public class FSMPlayer_Mobile : FSMBase
{
    //캐릭터 파라메타
    public int currentHP = 100;
    public int maxHP = 100;
    public int exp = 0;
    public int level = 1;
    public int gold = 0;
    public float attack = 50.0f;  // 공격력
    public float attackRange = 1.5f; // 공격범위
    public float moveSpeed = 3.0f;
    public float turnSpeed = 360.0f;

    public Transform movePoint;
    public Transform attackPoint;

    FSMEnemy fsmEnemy;

    //클릭한 대상의 레이어 정보 (layerMask 는 비트연산으로 대상을 체크한다. 그래서 int 타입이다)
    int layerMask;

    public string enemyLayer = "Enemy";

    public int attackpoint = 0;

    //public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;

    protected override void Awake()
    {
        base.Awake();

        movePoint = GameObject.FindGameObjectWithTag("MovePoint").transform;
        movePoint.gameObject.SetActive(false);

        layerMask = LayerMask.GetMask(enemyLayer);
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f, layerMask))
                {
                    int layer = hit.transform.gameObject.layer;

                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began && layer == LayerMask.NameToLayer(enemyLayer))
                    {
                        attackpoint++;
                        fsmEnemy = hit.collider.transform.GetComponent<FSMEnemy>();
                        Vector3 dest = hit.point;
                        movePoint.transform.position = dest;
                        movePoint.gameObject.SetActive(true);
                        Debug.Log("Click");

                        if (attackpoint % 2 == 1)
                        {
                            SetState(CharacterState.Attack1);
                        }
                        else if (attackpoint % 2 == 0)
                        {
                            SetState(CharacterState.Attack2);
                        }
                    }

                }
            }
        }
    }
    protected override IEnumerator Idle()
    {
        attackpoint = 0;
        do
        {
            yield return null;

        } while (!isNewState);
    }

    protected virtual IEnumerator Attack1()
    {
        // Debug.Log("click");
        OnAttack();
        anim.Play("Attack1");

        do
        {
            yield return null;

            //MoveUtil.cs 의 MoveFrame 을 호출하고 목표지점에 도착했는지 체크한다.
            if (MoveUtil.MoveFrame(characterController, movePoint, moveSpeed, turnSpeed) == 0) //if 문 전체추가
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1.0f > 0.9f &&
                    anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
                {
                    SetState(CharacterState.Idle);
                    break;
                }
            }

        } while (!isNewState);
    }

    protected virtual IEnumerator Attack2()
    {
        OnAttack();
        anim.Play("Attack2");

        do
        {
            yield return null;
            if (MoveUtil.MoveFrame(characterController, movePoint, moveSpeed, turnSpeed) == 0) //if 문 전체추가
            {
                movePoint.gameObject.SetActive(false);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1.0f > 0.9f &&
                   anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
                {
                    SetState(CharacterState.Idle);
                    break;
                }
            }

        } while (!isNewState);
    }

    public void OnAttack()
    {
        fsmEnemy.ProcessDamage();
    }
}


