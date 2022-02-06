using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class UnityAdsHelper : MonoBehaviour
{
    public Canvas RebornCanvas;
    public Canvas CheckData;
    ShowOptions _ShowOpt = new ShowOptions();
    int cnt = 0;
    void Awake()
    {
        Advertisement.Initialize("1300839", false);
        _ShowOpt.resultCallback = OnAdShowResultCallBack;
    }

    void OnAdShowResultCallBack(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            cnt = 0;
            RebornCanvas.enabled = true;
        }
        else if (result == ShowResult.Failed)
        {
            if (cnt.Equals(0))
            {
                cnt += 1;
                CheckData.enabled = true;               
            }
            else
            {
                cnt += 1;
                CheckData.enabled = true;               
            }
        }
    }

    public void OnButtonUnityAds()
    {
        Advertisement.Show("advertisement", _ShowOpt);
    }

    public void Check_DataConnection_OK()
    {
        CheckData.enabled = false;
        if (cnt.Equals(1))
            OnButtonUnityAds();
        else cnt = 0;
    }
}
