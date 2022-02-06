using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.UI;

public class UnityAdsManager_Jebby : MonoBehaviour
{    
    ShowOptions _ShowOpt = new ShowOptions();
    public Canvas CheckData;

    public static int Result;

    int Ad;
    public Text JebbyCnt;
    void Awake()
    {
        Advertisement.Initialize("1300839", false);
        _ShowOpt.resultCallback = OnAdShowResultCallBack;
    }
    void Start()
    {
        Ad = PlayerPrefs.GetInt("Ad");
        JebbyCnt.text = "남은 제비: " + (5 - Ad).ToString();
    }
    void OnAdShowResultCallBack(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Ad++;
            PlayerPrefs.SetInt("Ad", Ad);
            JebbyCnt.text = "남은 제비: " + (5 - Ad).ToString();
            switch (JebbyControl.result)
            {
                case 0:
                    GlobalPoint.GoldPoint += 20;
                    PlayerPrefs.SetInt("gold",GlobalPoint.GoldPoint);
                    break;
                case 1:
                    GlobalPoint.GoldPoint += 30;
                    PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
                    break;
                case 2:
                    GlobalPoint.GoldPoint += 40;
                    PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
                    break;
                case 3:
                    GlobalPoint.GoldPoint += 50;
                    PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
                    break;
                case 4:
                    GlobalPoint.GoldPoint += 60;
                    PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
                    break;
                default: break;
            }
        }
        else if(result == ShowResult.Failed)
        {
            CheckData.enabled = true;
        }
    }

    public void OnButtonUnityAds()
    {
        Advertisement.Show("advertisement", _ShowOpt);
    }

    public void Check_DataConnection_OK()
    {
        CheckData.enabled = false;
    }
}