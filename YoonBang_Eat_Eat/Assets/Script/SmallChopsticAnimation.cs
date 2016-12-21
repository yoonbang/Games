using UnityEngine;
using System.Collections;

public class SmallChopsticAnimation : MonoBehaviour {
    public void SmallChopsticAttackAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Attack");
    }
}
