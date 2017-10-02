using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float cur_Health;
    public float max_Health;
    public GameObject healthBar;
    FSMEnemy fsmEnemy;
	// Use this for initialization
	void Start () {
        fsmEnemy = this.GetComponent<FSMEnemy>();
        max_Health = fsmEnemy.maxHP;
        cur_Health = fsmEnemy.currentHP;

        InvokeRepeating("decreasehealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void decreasehealth()
    {
        float calc_Health = cur_Health / max_Health;
        SetHealthBar(calc_Health);
    }

    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
