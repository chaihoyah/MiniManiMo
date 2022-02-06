using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AirScript : MonoBehaviour
{
    public GameObject AirBar;
    public float AirState;
    public GameObject But1;
    public GameObject But2;
    public GameObject But3;
    public GameObject But4;
    public GameObject SettingBut;
    public Image ResultPanel;
    public Text scoreText;
    public Text Highsco;
    public Text PointTwo;
    public GameObject Retr;
    public GameObject Main;

    public AdmobScript admob;

    public Text PointTex;
    public SoundManager SoundM;

    bool isSoundOn;
    bool isChangeOn;
    //*******
    public Image coloR;
    Color Init;
    Color ChgCol;

    void Start()
    {
        isSoundOn = false;

        AirState = 0.8467f;
        admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();
        Init = coloR.color;
        ChgCol = new Color((float)204 / 255, (float)33 / 255, (float)33 / 255, Init.a);
        if (!JamSoo_Tutorial.isPanTuto)
        {
            StartCoroutine(AirDec());
        }
    }
    IEnumerator AirDec()
    {
        while (true)
        {
            if (!DDangGlo.isFinished)
            {
                if (AirState <= 0.15f)
                {
                    if (!isSoundOn)
                    {
                        isSoundOn = true;
                        SoundM.PlayStop();
                        SoundM.PlayJamsuAlarm();
                    }
                    if(!isChangeOn)
                    {
                        isChangeOn = true;
                        StartCoroutine(Change());
                    }
                }
                if(AirState>0.15f)
                {
                    if (isSoundOn)
                    {
                        isSoundOn = false;
                    }
                    if(isChangeOn)
                    {
                        isChangeOn = false;
                    }
                }
                if (AirState > 0)
                {
                    AirState -= 0.003f;
                }
                else
                {
                    AirState = 0;
                    StartCoroutine(Result());                 
                }

                AirBar.transform.localScale = new Vector3(0.737f, AirState, 1);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Change()
    {
        while (isChangeOn)
        {
            yield return new WaitForSeconds(0.7f);
            coloR.color = ChgCol;
            yield return new WaitForSeconds(0.7f);
            coloR.color = Init;
        }
    }


IEnumerator Result()
    {
            Time.timeScale = 0.9f;
            DDangGlo.isFinished = true;
            DDangGlo.Level = 1;
            But1.SetActive(false);
            But2.SetActive(false);
            But3.SetActive(false);
            But4.SetActive(false);
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
            scoreText.text = "Score:" + " " + DDangGlo.Point.ToString();
            yield return new WaitForSeconds(0.1f);
        int a;
        a = Random.Range(0, 2);
        if (a.Equals(1)) admob.ShowAD();
        if (DDangGlo.Point >= DDangGlo.HighPoint)
        {
            //패널 하나더 넣을까?
            DDangGlo.HighPoint = DDangGlo.Point;
            PlayerPrefs.SetInt("Swimhigh", DDangGlo.HighPoint);
            int Total = (PlayerPrefs.GetInt("Wallhigh") + PlayerPrefs.GetInt("WallhighEasy") + PlayerPrefs.GetInt("WallhighHard")) + PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh") + PlayerPrefs.GetInt("Wolfhigh");
            PlayerPrefs.SetInt("TotalScore", Total);
            Social.ReportScore(DDangGlo.HighPoint, "CgkIqcqjsI0OEAIQAg", success => {
                Debug.Log("report_score");
            });
            Social.ReportScore(Total, "CgkIqcqjsI0OEAIQBA", success => {
                Debug.Log("report_score");
            });
            Highsco.text = "High Score:";
            yield return new WaitForSeconds(0.3f);
            Highsco.text = "High Score:" + " " + DDangGlo.HighPoint.ToString();
        }
        else
            {
                Highsco.text = "High Score:";
                yield return new WaitForSeconds(0.3f);
                Highsco.text = "High Score:" + " " + DDangGlo.HighPoint.ToString();
            }
            yield return new WaitForSeconds(0.1f);
            PointTex.text = "Silver: " + DDangGlo.Money.ToString();
            PointTwo.text = "Gold: " + DDangGlo.Gold.ToString();
            Retr.SetActive(true);
            Main.SetActive(true);
    }
}