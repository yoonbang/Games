using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GoogleAdMob : MonoBehaviour {

	// Use this for initialization
	void Awake()
    {
        InterstitialAd interstitial = new InterstitialAd("ca-app-pub-1897145845153789/6001981353");

        AdRequest request = new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("3968A57FF28B0A54")
            .Build();
        interstitial.LoadAd(request);

        if(interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
}
