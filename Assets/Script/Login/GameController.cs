using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	
	public GameObject inputSetObj;
	
	public InputField InputField_Login;
	
	public string host = "http://localhost:3000";

    public Canvas InputUsername;
    public Canvas TooLongUsername;
    public Canvas SuccessRegister;
    public Canvas AlreadyRegistered;

    // Use this for initialization
    void Start ()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
		inputSetObj.SetActive(true);

        InputUsername.enabled = false;
        TooLongUsername.enabled = false;
        SuccessRegister.enabled = false;
        AlreadyRegistered.enabled = false;
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
	
	public void AddUser()
	{
        if (InputField_Login.text.Length == 0)
        {
            InputUsername.enabled = true;
        }
        else if (InputField_Login.text.Length > 10)
        {
            TooLongUsername.enabled = true;
        }
        else
        {
            string url = string.Format("{0}/users/add/{1}", host, InputField_Login.text);
            WWWForm temp = new WWWForm();
            temp.AddField("temp", "1");
            StartCoroutine(RequestServer(url, temp, CallbackAddUser));
        }
	}
	
	void CallbackAddUser(string result) 
	{
		var dict = MiniJSON.Json.Deserialize(result) as Dictionary<string, object>;
		long resultCode = (long)dict["result"];
		switch(resultCode) 
		{
			case 0:
				//정상 등록 완료.
				var bodyDict = (Dictionary<string, object>)dict["body"];
				long id = (long)bodyDict["id"];
				Debug.Log(id);
				userID = System.Convert.ToInt32(id);
                SuccessRegister.enabled = true;
                PlayerPrefs.SetString("Username", InputField_Login.text);

                //	SendScoreProcess();
                break;
			case 99:
				//이미 등록된 아이디.
				Debug.Log((string)dict["body"]);
                AlreadyRegistered.enabled = true;
				break;
		}
	}
	
	IEnumerator RequestServer(string URL, WWWForm form = null, System.Action<string> callback = null) 
	{
		WWW www = (form == null) ? new WWW(URL) : new WWW(URL, form);
		
		yield return www;
		
		if(callback != null) {
			Debug.Log(www.text);
			callback(www.text);
		}
	}
    //켄버스 버튼
    public void CloseCanvas()
    {
        InputUsername.enabled = false;
        TooLongUsername.enabled = false;
        AlreadyRegistered.enabled = false;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(0);
    }

}
