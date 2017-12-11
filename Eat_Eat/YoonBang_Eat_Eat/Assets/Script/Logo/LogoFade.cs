using UnityEngine;
using System.Collections;

public class LogoFade : MonoBehaviour
{
    CanvasGroup canvasGroup;
    private float logeRate = 3.0f;
    // Use this for initialization
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > logeRate)
        {
            if (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime *2;
            }
            else
            {
                canvasGroup.interactable = false;
                Application.LoadLevel("Loading");

            }
        }
    }
}
