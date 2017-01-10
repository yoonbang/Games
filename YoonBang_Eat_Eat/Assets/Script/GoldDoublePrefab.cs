using UnityEngine;
using System.Collections;

public class GoldDoublePrefab : MonoBehaviour {
    public float fDestroyTime = 10f;
    public float fTickTime;
    Player_Ctrl_PC pc;
    // Use this for initialization
    void Start () {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Ctrl_PC>();
    }
	
	// Update is called once per frame
	void Update () {
        fTickTime += Time.deltaTime;

        if (fTickTime >= fDestroyTime)
        {
            GoldDouble();
        }
    }
    public void GoldDouble()
    {
        pc.goldGain = false;
        Destroy(this.gameObject);
    }
}
