using UnityEngine;
using System.Collections;

public class DishEffectDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.3f);
    }
}
