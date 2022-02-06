using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateLocal : MonoBehaviour
{

    //로그인 씬에서 로컬 생성

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.Portrait;
        Time.timeScale = 1;
        //if (PlayerPrefs.HasKey("isFirst") == false)
        //{
            PlayerPrefs.SetInt("isFirst", 1);
            PlayerPrefs.SetInt("DDRgame", 0);
            PlayerPrefs.SetInt("Swimgame", 1);//게임 보유 유무
            PlayerPrefs.SetInt("Wolfgame", 0);
            PlayerPrefs.SetInt("userID", 0);
            PlayerPrefs.SetInt("gold", 0);//게임 머니
            PlayerPrefs.SetInt("silver", 0);
            PlayerPrefs.SetInt("Wallhigh", 0);//게임 하이스코어
            PlayerPrefs.SetInt("WallhighEasy",0);
            PlayerPrefs.SetInt("WallhighHard", 0);
            PlayerPrefs.SetInt("RunDistance", 0);
            PlayerPrefs.SetInt("Swimhigh", 0);
            PlayerPrefs.SetInt("NewSwimhigh", 0);
            PlayerPrefs.SetInt("Wolfhigh", 0);
            PlayerPrefs.SetInt("Mazeround", 0);//미로는 라운드로
            PlayerPrefs.SetInt("TotalScore", 0);
            //Item 생성
            PlayerPrefs.SetInt("Pizza1", 0);//item = 1
            PlayerPrefs.SetInt("Pizza2", 0);
            PlayerPrefs.SetInt("Pizza3", 0);
            PlayerPrefs.SetInt("DdrPet1", 0);
            PlayerPrefs.SetInt("DdrPet2", 0);
            PlayerPrefs.SetInt("DdrPet3", 0);
            PlayerPrefs.SetInt("SwimUpgrade", 0);
            PlayerPrefs.SetInt("SwimShoes1", 0);
            PlayerPrefs.SetInt("SwimShoes2", 0);
            PlayerPrefs.SetInt("SwimShoes3", 0);
            PlayerPrefs.SetInt("SwimPet1", 0);
            PlayerPrefs.SetInt("SwimPet2", 0);
            PlayerPrefs.SetInt("WolfFire", 0);
            PlayerPrefs.SetInt("WolfIce", 0);
            PlayerPrefs.SetInt("WolfThunder", 0);
            PlayerPrefs.SetInt("WolfHp1Upgrade", 0);
            PlayerPrefs.SetInt("WolfHp2Upgrade", 0);
            PlayerPrefs.SetInt("WolfHp3Upgrade", 0);
            PlayerPrefs.SetInt("WolfBirdGun", 0);
            PlayerPrefs.SetInt("WolfPotion", 0);//item = 20
            PlayerPrefs.SetInt("WolfSpeed1", 0);
            PlayerPrefs.SetInt("WolfSpeed2", 0);
            PlayerPrefs.SetInt("WolfWeapon1", 0);
            PlayerPrefs.SetInt("WolfWeapon2", 0);
            //게임 라운드
            PlayerPrefs.SetInt("Round_Jamsu", 1);
            PlayerPrefs.SetInt("Round_Snow", 1);
            PlayerPrefs.SetInt("Round_DDR", 1);
            PlayerPrefs.SetInt("Map_Snow", 1);
            //이미 가지고 있는 아이템
            PlayerPrefs.SetInt("Pizza0", 2);
            PlayerPrefs.SetFloat("sound", 1f);
            //제비뽑기
            System.DateTime Today = System.DateTime.Now.Date;
            PlayerPrefs.SetString("Date", Today.ToString());
            PlayerPrefs.SetInt("Ad", 0);
            //tuto
            PlayerPrefs.SetInt("PickFirst", 0);
            PlayerPrefs.SetInt("isJamTuto", 0);
            PlayerPrefs.SetInt("isMazeTuto", 0);
            PlayerPrefs.SetInt("isDDRTuto", 0);
            PlayerPrefs.SetInt("isWolfTuto", 0);
            PlayerPrefs.SetInt("isNewJamTuto", 0);
            PlayerPrefs.SetInt("isDaliTuto", 0);
        //}

        Invoke("MST", 5f);
    }

    void MST()
    {
        SceneManager.LoadScene(1);
    }
}