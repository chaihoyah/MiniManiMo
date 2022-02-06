using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLockOff : MonoBehaviour
{

    public Canvas DDR_Buy;
    public Canvas Wolf_Buy;

    public Image DDRLocker;
    public Image WolfLocker;

    int silver;

    void Awake()
    {
        Wolf_Buy.enabled = false;
        DDR_Buy.enabled = false;

        silver = PlayerPrefs.GetInt("silver");

        if (PlayerPrefs.GetInt("Wolfgame") == 0) WolfLocker.enabled = true;
        else WolfLocker.enabled = false;
        if (PlayerPrefs.GetInt("DDRgame") == 0) DDRLocker.enabled = true;
        else DDRLocker.enabled = false;
    }
    //잠수하기 게임 사기
    public void Buy_DDR()
    {
        if (PlayerPrefs.GetInt("DDRgame") == 0)
        {
            if (PlayerPrefs.GetInt("silver") >= 7000)
            {
                DDR_Buy.enabled = true;
            }
        }
    }

    public void Buying_DDR()
    {
        PlayerPrefs.SetInt("DDRgame", 1);
        GlobalPoint.ChongPoint -= 7000;
        silver -= 7000;
        PlayerPrefs.SetInt("silver", silver);
        DDRLocker.enabled = false;
    }

    public void NotBuying_Swim()
    {
        DDR_Buy.enabled = false;
    }

    //돌던지기 게임 사기
    public void Buy_Wolf()
    {
        if (PlayerPrefs.GetInt("Wolfgame") == 0)
        {
            if (PlayerPrefs.GetInt("silver") >= 10000)
            {
                Wolf_Buy.enabled = true;
            }
        }
    }

    public void Buying_Wolf()
    {
        PlayerPrefs.SetInt("Wolfgame", 1);
        GlobalPoint.ChongPoint -= 10000;
        silver -= 10000;
        PlayerPrefs.SetInt("silver", silver);
        WolfLocker.enabled = false;
    }

    public void NotBuying_Wolf()
    {
        Wolf_Buy.enabled = false;
    }
}