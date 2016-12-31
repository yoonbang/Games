using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DamageTextManager : MonoBehaviour {
    public GameObject damageText;
    public GameObject damageTextUI;
    public Transform damageTextTransform;
    public GameObject ciritical;
    public bool ciriticalMode = false;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DamageUI()
    {
        if (ciriticalMode == true)
        {
            ciriticalMode = false;
            damageText = Instantiate(ciritical, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;
            
        }
        else {
            damageText = Instantiate(damageTextUI, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;
        }
    }
}
