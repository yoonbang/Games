using UnityEngine;
using System.Collections;

public class StartSmallFoodAnimation : MonoBehaviour {

    public void SmallFoodAnimation()
    {
        this.GetComponent<Animator>().Rebind();
        this.GetComponent<Animator>().Play("SmallFood_Animation");
    }
}
