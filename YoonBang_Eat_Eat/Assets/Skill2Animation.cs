using UnityEngine;
using System.Collections;

public class Skill2Animation : MonoBehaviour {
	public float delayTime=0f;
	public float fDelayTime=3.0f;
	public GameObject skill2_2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		delayTime += Time.deltaTime;

		if (delayTime >= fDelayTime) {
			Skill2Aniamtion ();
			this.gameObject.SetActive (false);
			delayTime = 0f;
		}
	}
	public void Skill2Aniamtion()
	{
		this.gameObject.GetComponent<Animator> ().Rebind ();
	}
	public void Skill2_2Effect()
	{
		skill2_2.SetActive (true);
	}
}
