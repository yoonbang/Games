using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public void AttackAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Attack");
    }
}
