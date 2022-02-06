using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController_Jamsu : MonoBehaviour
{

    public Image[] RoundCheck = new Image[2];
    public static int round;

    void Awake()
    {
        round = PlayerPrefs.GetInt("Round_Jamsu");
        switch (round)
        {
            case 1:
                RoundCheck[0].enabled = true;
                break;
            case 2:
                RoundCheck[1].enabled = true;
                break;
        }
    }

    public void Round1()
    {
        PlayerPrefs.SetInt("Round_Jamsu", 1);
        round = 1;
        RoundCheck[0].enabled = true;
        RoundCheck[1].enabled = false;
    }

    public void Round2()
    {
        PlayerPrefs.SetInt("Round_Jamsu", 2);
        round = 2;
        RoundCheck[1].enabled = true;
        RoundCheck[0].enabled = false;
    }
}