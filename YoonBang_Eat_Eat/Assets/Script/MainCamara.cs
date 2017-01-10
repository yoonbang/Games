using UnityEngine;
using System.Collections;

public class MainCamara : MonoBehaviour {
    public void MainCamaraAnimationStart()
    {
            this.gameObject.GetComponent<Animator>().Rebind();
            this.gameObject.GetComponent<Animator>().Play("Fail");
    }
}
