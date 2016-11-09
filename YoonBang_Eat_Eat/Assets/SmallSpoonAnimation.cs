using UnityEngine;
using System.Collections;

public class SmallSpoonAnimation : MonoBehaviour {

    // Use this for initialization
    public void SmallSpoonAttackAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("SmallSpoonAttack1");
    }
}
