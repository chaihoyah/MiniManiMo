using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController_Snow : MonoBehaviour
{

    public Image[] RoundCheck = new Image[2];
    public Image[] MapCheck = new Image[3];
    public static int round;
    public static int Snow_map;

    void Awake()
    {
        round = PlayerPrefs.GetInt("Round_Snow");
        Snow_map = PlayerPrefs.GetInt("Map_Snow");
        switch (round)
        {
            case 1:
                RoundCheck[0].enabled = true;
                WolfScript.Calculation = 1;
                break;
            case 2:
                RoundCheck[1].enabled = true;
                WolfScript.Calculation = 2;
                break;
        }

        if (Snow_map.Equals(1))
        {
            MapCheck[0].enabled = true;

        }
        else if (Snow_map.Equals(2))
        {
            MapCheck[1].enabled = true;
        }
        else
        {
            MapCheck[2].enabled = true;
        }
    }

    public void Round1()
    {
        PlayerPrefs.SetInt("Round_Snow", 1);
        round = 1;
        RoundCheck[0].enabled = true;
        RoundCheck[1].enabled = false;
        WolfScript.Calculation = 1;
    }

    public void Round2()
    {
        PlayerPrefs.SetInt("Round_Snow", 2);
        round = 2;
        RoundCheck[1].enabled = true;
        RoundCheck[0].enabled = false;
        WolfScript.Calculation = 2;
    }

    public void Map1()
    {
        PlayerPrefs.SetInt("Map_Snow", 1);
        Snow_map = 1;
        MapCheck[0].enabled = true;
        MapCheck[1].enabled = false;
        MapCheck[2].enabled = false;
    }

    public void Map2()
    {
        PlayerPrefs.SetInt("Map_Snow", 2);
        Snow_map = 2;
        MapCheck[0].enabled = false;
        MapCheck[1].enabled = true;
        MapCheck[2].enabled = false;
    }

    public void Map3()
    {
        PlayerPrefs.SetInt("Map_Snow", 3);
        Snow_map = 3;
        MapCheck[0].enabled = false;
        MapCheck[1].enabled = false;
        MapCheck[2].enabled = true;
    }
}