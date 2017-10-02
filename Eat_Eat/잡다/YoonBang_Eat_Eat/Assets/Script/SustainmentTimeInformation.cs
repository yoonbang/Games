using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SustainmentTimeInformation : MonoBehaviour {
    public float fDestroyTime = 10f;
    public float fTickTime;

    public GameObject SustainmentTimeObject;
    public Text second;

    public float sustainmentTime = 0f;//지속시간
                                      // Use this for initialization
    void Start () {
	
	}
    void Awake()
    {
        sustainmentTime = fDestroyTime;
    }
    // Update is called once per frame
    void Update()
    {
        sustainmentTime -= Time.deltaTime;
        second.text = sustainmentTime.ToString("00");
        if (sustainmentTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
