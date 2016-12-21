using UnityEngine;
using System.Collections;

public class SmallKnifeAnimation : MonoBehaviour {
    public void SmallKnifeAttackAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Attack");
    }
}
