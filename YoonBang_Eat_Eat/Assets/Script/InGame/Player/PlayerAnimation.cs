using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
    public int animationNumber=0;

    public void AttackAnimation()
    {
        animationNumber++;
        if (animationNumber == 1)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack2");
        }
        if(animationNumber==2)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack3");
            animationNumber = 0;
        }
    }

    public void SuperModeAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Attack1");
    }
}
