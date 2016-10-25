using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Google_AdMob : MonoBehaviour {
    BannerView bannerView;
	// Use this for initialization
	void Start () {
         AdSize adSize = new AdSize(360, 50);
         bannerView = new BannerView("ca-app-pub-1897145845153789/7001036558", adSize, AdPosition.Bottom);
         AdRequest request = new AdRequest.Builder().Build();
         bannerView.LoadAd(request);
         bannerView.Show();


    }
	
	// Update is called once per frame
	void Update () {
	
	}

}
