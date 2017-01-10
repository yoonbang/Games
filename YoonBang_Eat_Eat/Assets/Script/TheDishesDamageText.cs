using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TheDishesDamageText : MonoBehaviour {
    public int animationNumber = 0;
    // Use this for initialization
    void Start () {

        animationNumber = Random.Range(1, 3);
        if (animationNumber == 1)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack1");
        }
        if (animationNumber == 2)
        {
            this.GetComponent<Animator>().Rebind();
            this.GetComponent<Animator>().Play("Attack2");
        }

        Destroy(this.gameObject, 0.7f);
    }
}
