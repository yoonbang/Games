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

    public GameObject smallDishesDamageTextUI;
    public GameObject smallDishesCriticalTextUI;

    public Text smallDishesDamageText;
    public Text smallDishesCriticalText;

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
            TheDieshesCriticalText.text = CountModule(Damage);
            damageText = Instantiate(TheDishesciritical, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;

        }
        else {
            TheDisheDamegeText.text = CountModule(Damage);
            damageText = Instantiate(TheDishesdamageTextUI, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;
        }
    }
    public void SmallDishesDamage(float Damage)
    {
        if (ciriticalMode == true)
        {
            ciriticalMode = false;
            smallDishesCriticalText.text = CountModule(Damage);
            damageText = Instantiate(smallDishesCriticalTextUI, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;

        }
        else {
            smallDishesDamageText.text = CountModule(Damage);
            damageText = Instantiate(smallDishesDamageTextUI, Vector3.zero, Quaternion.identity) as GameObject;
            damageText.transform.SetParent(damageTextTransform.transform, false);
            damageText.transform.position = damageTextTransform.transform.position;
        }
    }

    public string CountModule(float haveCount)
    {
        if (haveCount > 1000000000000000000)
            return string.Format("{0:#.#}G", (float)haveCount / 1000000000000000000);
        if (haveCount > 1000000000000000)
            return string.Format("{0:#.#}P", (float)haveCount / 1000000000000000);
        if (haveCount > 1000000000000)
            return string.Format("{0:#.#}T", (float)haveCount / 1000000000000);
        if (haveCount > 1000000000)
            return string.Format("{0:#.#}B", (float)haveCount / 1000000000);
        else if (haveCount > 1000000)
            return string.Format("{0:#.#}M", (float)haveCount / 1000000);
        if (haveCount > 1000)
            return string.Format("{0:#.#}K", (float)haveCount / 1000);
        else
            return haveCount.ToString("N1");
    }
}
