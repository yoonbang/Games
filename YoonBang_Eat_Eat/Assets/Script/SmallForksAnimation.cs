using UnityEngine;
using System.Collections;

public class SmallForksAnimation : MonoBehaviour {
    public void SmallForksAttackAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Attack");
    }
}
