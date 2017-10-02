using UnityEngine;
using System.Collections;

public class GatherEffectDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.5f);
	}
}
