using UnityEngine;
using System.Collections;

public class Block_Move_Ctrl : MonoBehaviour {
    public float Block_Move_Speed = 3f; // 블럭들이 움직일 스피드 
                                        // Use this for initialization
    public GameObject[] Block; // 만들블럭

    public GameObject Seesaw_Zone;
    public GameObject A_Zone;
    public GameObject B_Zone;
    public GameObject C_Zone;
    public GameObject D_Zone;
    public GameObject E_Zone;
    public GameObject F_Zone;
    public GameObject G_Zone;
    public GameObject H_Zone;
    public GameObject I_Zone;
    public GameObject J_Zone;
    public GameObject K_Zone;

    public GameObject Sky1, Sky2, Sky3;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        Seesaw_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        A_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        B_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        C_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        D_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        E_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        F_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        G_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        H_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        I_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        J_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        K_Zone.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);


        Sky1.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        Sky2.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);
        Sky3.transform.Translate(Vector3.left * Block_Move_Speed * Time.deltaTime);

    }

    void Make()
    {
    }
}
