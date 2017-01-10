using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DamageTextManager : MonoBehaviour {
    public GameObject damageText;
    public GameObject damageTextUI;
    public Transform damageTextTransform;
    public GameObject ciritical;
    public GameObject TheDishesciritical;
    public GameObject TheDishesdamageTextUI;

    public Text TheDisheDamegeText;
    public Text TheDieshesCriticalText;
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
    public void TheDishesDamage(float Damage)
    {
        if (ciriticalMode == true)
        {
            ciriticalMode = false;
            TheDieshesCriticalText.text = Damage.ToString("N1");
            damageText = Instantiate(TheDishesciritical, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;

        }
        else {
            TheDisheDamegeText.text = Damage.ToString("N1");
            damageText = Instantiate(TheDishesdamageTextUI, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;
        }
    }
}
