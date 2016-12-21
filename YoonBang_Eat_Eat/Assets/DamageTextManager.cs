using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DamageTextManager : MonoBehaviour {
    public GameObject damageText;
    public GameObject damageTextUI;
    public Transform damageTextTransform;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DamageUI()
    {
        damageText = Instantiate(damageTextUI, Vector3.zero, Quaternion.identity) as GameObject;
        damageText.transform.SetParent(damageTextTransform.transform, false);
        damageText.transform.position = damageTextTransform.transform.position;
    }
}
