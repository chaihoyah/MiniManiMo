using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobScript : MonoBehaviour
{

    // 전면 광고 id 등록
    InterstitialAd interstitial;

    void Awake()
    {
       interstitial = new InterstitialAd("ca-app-pub-7566633670552557/2474546423");
        // 애드몹 리퀘스트 초기화
        AdRequest request = new AdRequest.Builder().Build();

        // 애드몹 전면 광고 로드
        interstitial.LoadAd(request);

        // 여기서부터 밑에 부분은 앱 실행 부분에 두면 광고가 안나온다. 실행 후 얼마 뒤로 미루자.
        // 로드 되어 있다면 광고 보여줌
    }

    public void ShowAD()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
}
