using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController_DDR : MonoBehaviour
{

    public Image[] RoundCheck = new Image[3];
    public static int round = 2;

    void Awake()
    {
        round = PlayerPrefs.GetInt("Round_DDR");
        switch (round)
        {
            case 1:
                RoundCheck[0].enabled = true;
                Wall.Difficulty = 1;
                break;
            case 2:
                RoundCheck[1].enabled = true;
                Wall.Difficulty = 2;
                break;
            case 3:
                RoundCheck[2].enabled = true;
                Wall.Difficulty = 3;
                break;
        }
    }

    public void Round1()
    {
        PlayerPrefs.SetInt("Round_DDR", 1);
        round = 1;
        Wall.Difficulty = 1;
        RoundCheck[0].enabled = true;
        RoundCheck[1].enabled = false;
        RoundCheck[2].enabled = false;
    }

    public void Round2()
    {
        PlayerPrefs.SetInt("Round_DDR", 2);
        round = 2;
        Wall.Difficulty = 2;
        RoundCheck[1].enabled = true;
        RoundCheck[0].enabled = false;
        RoundCheck[2].enabled = false;
    }

    public void Round3()
    {
        PlayerPrefs.SetInt("Round_DDR", 3);
        round = 3;
        Wall.Difficulty = 3;
        RoundCheck[2].enabled = true;
        RoundCheck[1].enabled = false;
        RoundCheck[0].enabled = false;
    }
}