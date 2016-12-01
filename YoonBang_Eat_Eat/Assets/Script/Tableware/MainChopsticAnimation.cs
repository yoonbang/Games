using UnityEngine;
using System.Collections;

public class MainChopsticAnimation : MonoBehaviour {
    public int startRandom, LastRandom;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MainSpoonAnimationStart()
    {
        startRandom = Random.Range(0, 1);
        {
            this.gameObject.GetComponent<Animator>().Rebind();
            this.gameObject.GetComponent<Animator>().Play("Attack");
        }
    }
}
