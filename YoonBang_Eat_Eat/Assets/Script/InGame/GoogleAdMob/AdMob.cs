using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
public class AdMob : MonoBehaviour {
    BannerView bannerView = null;
    InterstitialAd interstitial = null;

    public void EventAdClose(object sender, System.EventArgs args)
    {
        print("event ad close!");
        AdRequest.Builder builder = new AdRequest.Builder();
        AdRequest request = builder.AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("3968A57FF28B0A54").Build();
        interstitial.LoadAd(request);
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10,200,300,200),"interstitial Show"))
        {
            interstitial.Show();
        }
    }
	// Use this for initialization
	void Start () {
        interstitial = new InterstitialAd("ca-app-pub-1897145845153789/6001981353");
        interstitial.OnAdClosed += EventAdClose;

        bannerView = new BannerView("pub-1897145845153789",AdSize.SmartBanner,AdPosition.Bottom);

        AdRequest.Builder builder = new AdRequest.Builder();
        AdRequest request = builder.AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("3968A57FF28B0A54").Build();

        interstitial.LoadAd(request);

        bannerView.LoadAd(request);
        bannerView.Show();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
