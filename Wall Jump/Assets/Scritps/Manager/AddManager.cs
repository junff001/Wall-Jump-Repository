using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AddManager : MonoBehaviour
{
    private RewardedAd rewardedAd;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }

    public void CreateAndLoadRewardedAd()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-6872104911579710/3568691876";
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);
        //this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        UserChoseToWatchAd();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }

    private void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
