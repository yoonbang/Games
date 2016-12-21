using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
    public int animationNumber=0;

    public void AttackAnimation()
    {
        //animationNumber++;
        animationNumber = Random.Range(1, 4);
        if (animationNumber == 1)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack2");
        }
        if(animationNumber==2)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack3");
        }
        if(animationNumber == 3)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack1");
            //animationNumber = 0;
        }
    }

    public void SuperModeAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("Attack1");
    }
}
