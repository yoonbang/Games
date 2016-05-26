
using UnityEngine;
using System.Collections;

public class SisoPlay : MonoBehaviour {
    public Animator anim1;
    void Start()
    {
        anim1 = GetComponent<Animator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject player1 = null;
        player1 = GameObject.Find("Player");
        Player_Ctrl PC = player1.GetComponent<Player_Ctrl>();

        GameObject blockmanager = null;
        blockmanager = GameObject.Find("Block_Manager");
        Block_Loop BL = blockmanager.GetComponent<Block_Loop>();

        if (collision.gameObject.name == "Block")
        {
            PC.rigi.AddForce(new Vector3(60, 800, 0));

            BL.Speed = 10f;

            anim1.SetTrigger("SisoAim");
        }
    }
}
