using UnityEngine;
using System.Collections;

public enum CannonState
{
    Idle,
    playcanon,
}
public class Cannon_Ctrl : MonoBehaviour {
    public int x, y;

    public float fDelayTime = 2f;
    float fTickTime;

    public CannonState CS;

    void Start()
    {
        CS = CannonState.Idle;
    }
    void Update()
    {
        if(CS==CannonState.playcanon)
        {
            fTickTime += Time.deltaTime;

            if (fTickTime >= fDelayTime)
            {
                GameObject player = null;
                player = GameObject.Find("Player");
                Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

                GameObject blockmanager = null;
                blockmanager = GameObject.Find("Block_Manager");
                Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

                PC.rigi.AddForce(new Vector3(x, y, 0)); // Player 멀리 날리기
                BMC.Block_Move_Speed = 13.0f;

                CS = CannonState.Idle;
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        GameObject blockmanager = null;
        blockmanager = GameObject.Find("Block_Manager");
        Block_Move_Ctrl BMC = blockmanager.GetComponent<Block_Move_Ctrl>(); //Block_Move_Ctrl 불러오기

        GameObject player = null;
        player = GameObject.Find("Player");
        Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

        if (col.gameObject.name == "Player")
        {
            BMC.Block_Move_Speed = 0f;

            CS = CannonState.playcanon;
        }
    }
 
}
