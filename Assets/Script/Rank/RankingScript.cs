using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingScript : MonoBehaviour {

    public string host = "http://minimanimo.azurewebsites.net";
    public List<ListItem> scoreBoardList = new List<ListItem>();

    // Use this for initialization
    void Start()
    {
        
        SendScoreProcess();
    }

    int userID
    {
        get
        {
            return PlayerPrefs.GetInt("userID");
        }

        set
        {
            PlayerPrefs.SetInt("userID", value);
        }
    }

    void SendScoreProcess()
    {
        //점수 보낸다.
        //TODO : Score send 기능 제작 후 작동 가능.
        SendScoreToServer(() => {
            //TODO : ranker 로딩 기능 제작 후 작동 가능.
            GetTopRanker();

        });
    }


    void SendScoreToServer(System.Action callback = null)
    {
        string url = string.Format("{0}/score/add/{1}/{2}", host, userID, PlayerPrefs.GetInt("TotalScore"));
        WWWForm temp = new WWWForm();
        temp.AddField("temp", "1");
        StartCoroutine(RequestServer(url, temp, (string result) => {
            if (callback != null)
            {
                callback();
            }
        }));
    }

    public void GetTopRanker(System.Action callback = null)
    {
        string url = string.Format("{0}/score/ranker", host);
        WWWForm temp = new WWWForm();
        StartCoroutine(RequestServer(url, temp, (string result) => {
            var dict = MiniJSON.Json.Deserialize(result) as Dictionary<string, object>;
            List<object> itemDatas = (List<object>)dict["Rank"];

            for (int i = 0; i < itemDatas.Count; ++i)
            {
                var item = (Dictionary<string, object>)itemDatas[i];
                scoreBoardList[i].SetItem(
                   System.Convert.ToInt32(item["Rank"]),
                   (string)item["username"],
                   System.Convert.ToInt32(item["score"]));
            }
            if (callback != null)
            {
                callback();
            }
            Debug.Log(temp);
        }));
    }

    IEnumerator RequestServer(string URL, WWWForm form = null, System.Action<string> callback = null)
    {
        WWW www = (form == null) ? new WWW(URL) : new WWW(URL, form);

        yield return www;
        Debug.Log(www.text);

        if (callback != null)
        {
            Debug.Log(www.text);
            callback(www.text);
        }
    }

}

