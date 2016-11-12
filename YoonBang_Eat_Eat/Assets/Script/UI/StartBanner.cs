using UnityEngine;
using System.Collections;

public class StartBanner : MonoBehaviour {
    void Start()
    {
        AdManager.Instance.ShowBanner();
    }
	public void BannerOpen()
    {
        AdManager.Instance.ShowBanner();
    }
}
