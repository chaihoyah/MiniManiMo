using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFinish_NewGame_Jamsu : MonoBehaviour
{

    public SoundManager SoundM;

    public Image ResultPanel;
    public Text scoreText;
    public Text Highsco;
    public Text PointTwo;

    public GameObject pet1;
    public GameObject pet2;

    public GameObject Retr;
    public GameObject Main;
    public GameObject Rank;

    public Text PointTex;

    public GameObject JoyStick;
    public GameObject VisionMove;
    public GameObject SettingBut;

    public AdmobScript admob;

    public Canvas AdsCanvas;//동영상 보기 전
    public Canvas RebornCanvas;//동영상 본 후(버튼 클릭 후 reborn)
    public static bool CanReborn_Jam_New = true;
    bool dataCheck = false;
    // Use this for initialization
    void Start()
    {
        admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();
        if (CanReborn_Jam_New)
        {
            TimeText.Money = 0;
            TimeText.Point = 0;
        }
        if (PlayerPrefs.GetInt("SwimPet2").Equals(1))
            pet2.SetActive(true);
        if (PlayerPrefs.GetInt("SwimPet1").Equals(1))
            pet1.SetActive(true);
        AdsCanvas.enabled = false;
        RebornCanvas.enabled = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wolf") || other.CompareTag("stone") || other.CompareTag("Mon"))
        {
            if (Time.timeScale.Equals(1))
            {
                SoundM.PlayJamsuDie();
                if (!NewJamsuPetTwo.PetTwoDie)
                {
                    NewJamsuPetTwo.PetTwoDie = true;
                    Destroy(other.gameObject);
                }
                else if (!NewJamsuPetOne.PetOneDie)
                {
                    NewJamsuPetOne.PetOneDie = true;
                    Destroy(other.gameObject);
                }
                else
                    StartCoroutine(Result());
            }
        }
    }

    IEnumerator Result()
    {
        if (CanReborn_Jam_New)
        {
            Time.timeScale = 0.9f;
            TimeText.isFinished = true;
            CanReborn_Jam_New = false;
            AdsCanvas.enabled = true;
            JoyStick.SetActive(false);
            VisionMove.SetActive(false);
            SettingBut.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            Time.timeScale = 0.9f;
            TimeText.isFinished = true;
            JoyStick.SetActive(false);
            VisionMove.SetActive(false);
            SettingBut.SetActive(false);


            yield return new WaitForSeconds(0.5f);

            ResultPanel.gameObject.SetActive(true);

            scoreText.text = "S";
            yield return new WaitForSeconds(0.15f);
            scoreText.text = "Sc";
            yield return new WaitForSeconds(0.15f);
            scoreText.text = "Sco";
            yield return new WaitForSeconds(0.15f);
            scoreText.text = "Scor";
            yield return new WaitForSeconds(0.15f);
            scoreText.text = "Score";
            yield return new WaitForSeconds(0.15f);
            scoreText.text = "Score:";
            yield return new WaitForSeconds(0.15f);
            scoreText.text = "Score:" + " " + (TimeText.Point * 10).ToString();
            yield return new WaitForSeconds(0.1f);
            int a;
            a = Random.Range(0, 2);
            if (a.Equals(1)) admob.ShowAD();
            if (TimeText.Point * 10 >= TimeText.HighPoint)
            {
                //패널 하나더 넣을까?
                TimeText.HighPoint = (TimeText.Point * 10);

                PlayerPrefs.SetInt("NewSwimhigh", TimeText.HighPoint);
                int JamTotal = PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh");
                int Total = (PlayerPrefs.GetInt("Wallhigh") + PlayerPrefs.GetInt("WallhighEasy") + PlayerPrefs.GetInt("WallhighHard")) + PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh") + PlayerPrefs.GetInt("Wolfhigh");
                PlayerPrefs.SetInt("TotalScore", Total);
                if (Social.localUser.authenticated)
                {
                    Social.ReportScore(JamTotal, "CgkIqcqjsI0OEAIQAg", success =>
                    {
                        Debug.Log("report_score");
                    });
                    Social.ReportScore(Total, "CgkIqcqjsI0OEAIQBA", success =>
                    {
                        Debug.Log("report_score");
                    });
                }
                Highsco.text = "High Score:";
                yield return new WaitForSeconds(0.3f);
                Highsco.text = "High Score:" + " " + (TimeText.Point * 10).ToString();
            }
            else
            {
                Highsco.text = "High Score:";
                yield return new WaitForSeconds(0.3f);
                Highsco.text = "High Score:" + " " + (PlayerPrefs.GetInt("NewSwimhigh")).ToString();
            }
            yield return new WaitForSeconds(0.1f);

            PointTex.text = "Silver: " + TimeText.Money.ToString();
            Rank.SetActive(true);
            Retr.SetActive(true);
            Main.SetActive(true);
        }
    }

    public void ResultStart()
    {
        StartCoroutine(Result());
    }

    public void NotConnectData()
    {
        if (!dataCheck) dataCheck = true;
        else
        {
            dataCheck = false;
            NotSeeAds();
        }
    }

    //REBORN
    public void SeeAds()
    {
        AdsCanvas.enabled = false;
    }

    public void NotSeeAds()
    {
        AdsCanvas.enabled = false;
        RebornCanvas.enabled = false;
        CanReborn_Jam_New = false;
        print(this.gameObject.name);
        StartCoroutine(Result());
    }

    public void Reborn()//다시 게임하러 갑시다!!
    {
        SoundM.PlayButton();
        RebornCanvas.enabled = false;
        TimeText.isFinished = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(9);
    }

    public void ToMain()
    {
        GlobalPoint.ChongPoint += TimeText.Money;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        TimeText.Money = 0;
        TimeText.Point = 0;
        MonsterRes.levelIdx = 0;
        CanReborn_Jam_New = true;

        Time.timeScale = 1;
        TimeText.isFinished = false;
        JoyStick.SetActive(true);
        VisionMove.SetActive(true);
        SettingBut.SetActive(true);
        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        SoundM.PlayButton();
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        GlobalPoint.ChongPoint += TimeText.Money;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        TimeText.Money = 0;
        TimeText.Point = 0;
        MonsterRes.levelIdx = 0;
        CanReborn_Jam_New = true;

        Time.timeScale = 1;
        TimeText.isFinished = false;
        JoyStick.SetActive(true);
        VisionMove.SetActive(true);
        SettingBut.SetActive(true);

        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        SoundM.PlayButton();
        SceneManager.LoadScene(9);
    }
}