using UnityEngine;
using System.Collections;

public class Small_Food_Shoot : MonoBehaviour {
    public float destoryDelay=1.5f;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, destoryDelay);
	}
	
}
