using UnityEngine;
using System.Collections;

public class DishesEffectDestory : MonoBehaviour {
    public float count=0f;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, count);
    }
	

}
