using UnityEngine;
using System.Collections;

public class Seesaw_Ctrl : MonoBehaviour
{
    public float Speed = 0f;
    public int x, y;
	void OnCollisionEnter(Collision col)
    {
        GameObject player = null;
        player = GameObject.Find("Player");
        Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

        GameObject blockmanager = null;
        blockmanager = GameObject.Find("Block_Manager");
        Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

        if (col.gameObject.name== "BlackStone")
        {            
            PC.rigi.AddForce(new Vector3(x, y, 0)); // Player 멀리 날리기

            BMC.Block_Move_Speed = Speed; // 맵 이동
        }
    }
}
