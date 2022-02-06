using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JebbyLimit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        JebbyInit();
	}

    void JebbyInit()
    {
        if(PlayerPrefs.GetString("Date")=="")
        {
            PlayerPrefs.SetString("Date", System.DateTime.Now.Date.ToString());
        }
        string Ad = PlayerPrefs.GetString("Date");
        int DateDif = DateDifCal(Ad);
        if (DateDif >= 1)
        {
            PlayerPrefs.SetString("Date", System.DateTime.Now.Date.ToString());
            PlayerPrefs.SetInt("Ad", 0);
        }
    }

    //로컬날짜받아서 현재날짜와비교함수
    int DateDifCal(string LocalDate)
    {
        System.DateTime Local = System.Convert.ToDateTime(LocalDate);
        System.DateTime Now = System.DateTime.Now.Date;
        System.TimeSpan TimeCal = Now - Local;

        int TimeCalDay = TimeCal.Days;

        return TimeCalDay;
    }

}
