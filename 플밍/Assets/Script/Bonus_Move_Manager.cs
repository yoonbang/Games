using UnityEngine;
using System.Collections;

public class Bonus_Move_Manager : MonoBehaviour {

    public GameObject Bonus_Manager,BackGroundMap;

    // Update is called once per frame
    void Update () {
        Move();
    }

    public void Move()
    {
        GameObject player = null;
        player = GameObject.Find("Player");
        Player_Ctrl PC = player.GetComponent<Player_Ctrl>(); // Player_Ctrl 불러오기

        BackGroundMap.transform.Translate(Vector3.left * PC.BlockSpeed * Time.deltaTime);

        if(PC.CurrentBonus<=0)
        {
            Vector3 BonusPoint = new Vector3();
            BonusPoint.x = 56.3f;
            BonusPoint.y = -83.4f;
            BonusPoint.z = 10f;

            BackGroundMap.transform.position = BonusPoint;
            PC.BlockSpeed = 0f;

            Bonus_Manager.SetActive(false);
        }
    }
}
