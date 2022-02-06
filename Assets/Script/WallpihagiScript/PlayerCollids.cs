using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollids : MonoBehaviour
{
    public GameObject ResultPanel;
    public Text scoreText;
    public Text Highsco;
    public GameObject Buttons;
    public GameObject Retr;
    public GameObject Main;
    public GameObject Rank;
    public Text PointTex;
    public Text PointTexTwo;
    public GameObject SettingBut;

    public Canvas AdsCanvas;
    public Canvas RebornCanvas;
    public static bool CanReborn_Wall = true;
    public static int WallPlusScore;
    public static int BullWallPlusScore;

    public AdmobScript admob;


    public static SoundManager SoundM;
    bool dataCheck = false;

    private void Awake()
    {
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
    }
    void Start()
    {
        ResultPanel.gameObject.SetActive(false);
        SettingBut.SetActive(true);
        Buttons.SetActive(true);
        Retr.SetActive(false);
        Main.SetActive(false);
        admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();
        if (Wall.Difficulty.Equals(2))
        {
            WallCount.HighScore = PlayerPrefs.GetInt("Wallhigh");
            WallPlusScore = 10;
            BullWallPlusScore = 12;
        }
        else if(Wall.Difficulty.Equals(1))
        {
            WallCount.HighScore = PlayerPrefs.GetInt("WallhighEasy");
            WallPlusScore = 6;
            BullWallPlusScore = 7;
        }
        else if(Wall.Difficulty.Equals(3))
        {
            WallCount.HighScore = PlayerPrefs.GetInt("WallhighHard");
            WallPlusScore = 17;
            BullWallPlusScore = 20;
        }

        if (CanReborn_Wall)
        {
            WallCount.Gold = 0;
            WallCount.Point = 0;
            WallCount.Wallcnt = 0;
            WallCount.Score = 0;
        }
        AdsCanvas.enabled = false;
        RebornCanvas.enabled = false;

    }

    void OnTriggerEnter(Collider order)
    {
        if (order.CompareTag("Wall"))
        {
            if (!DDRTutorial.tutorial)
            {
                if (!WallpihagiSpurt.isSpurt)
                {
                    SoundM.PlayWolfGameDie();
                    WallCount.isFinished = true;

                    StartCoroutine(Result());
                }

            }
            else
            {
                DDRTutorial.nice = false;
            }
        }
    }

    IEnumerator Result()
    {
        if(CanReborn_Wall)
        {
            Time.timeScale = 0.9f;
            Buttons.SetActive(false);
            WallCount.isFinished = true;
            AdsCanvas.enabled = true;
            SettingBut.SetActive(false);
        }
        else
        {
            WallCount.isFinished = true;
            Buttons.SetActive(false);
            SettingBut.SetActive(false);
            // 애니메이션, fade in?
            Time.timeScale = 0.9f;
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
            scoreText.text = "Score:" + " " + WallCount.Score.ToString();
            yield return new WaitForSeconds(0.1f);
            int a;
            a = Random.Range(0, 2);
            if (a.Equals(1)) admob.ShowAD();
            if (WallCount.Score >= WallCount.HighScore)
            {
                //패널 하나더 넣을까?
                WallCount.HighScore = WallCount.Score;
                if (Wall.Difficulty.Equals(2))
                {
                    PlayerPrefs.SetInt("Wallhigh", WallCount.HighScore);
                }
                else if (Wall.Difficulty.Equals(1))
                {
                    PlayerPrefs.SetInt("WallhighEasy", WallCount.HighScore);
                }
                else if (Wall.Difficulty.Equals(3))
                {
                    PlayerPrefs.SetInt("WallhighHard", WallCount.HighScore);
                }
                int Total = (PlayerPrefs.GetInt("Wallhigh")+PlayerPrefs.GetInt("WallhighEasy")+PlayerPrefs.GetInt("WallhighHard"))+ PlayerPrefs.GetInt("NewSwimhigh")+ PlayerPrefs.GetInt("Swimhigh") + PlayerPrefs.GetInt("Wolfhigh");
                PlayerPrefs.SetInt("TotalScore", Total);
                int DD = (PlayerPrefs.GetInt("Wallhigh") + PlayerPrefs.GetInt("WallhighEasy") + PlayerPrefs.GetInt("WallhighHard"));
                Social.ReportScore(DD, "CgkIqcqjsI0OEAIQAQ", success => {
                    Debug.Log("report_score");
                });
                Social.ReportScore(Total, "CgkIqcqjsI0OEAIQBA", success => {
                    Debug.Log("report_score");
                });
                Highsco.text = "High Score:";
                yield return new WaitForSeconds(0.3f);
                Highsco.text = "High Score:" + " " + WallCount.HighScore.ToString();
            }
            else
            {
                Highsco.text = "High Score:";
                yield return new WaitForSeconds(0.3f);
                Highsco.text = "High Score:" + " " + WallCount.HighScore.ToString();
            }
            yield return new WaitForSeconds(0.1f);
            PointTex.text = "Silver: " + WallCount.Point.ToString();
            PointTexTwo.text = "Gold: " + WallCount.Gold.ToString();
            Rank.SetActive(true);
            Retr.SetActive(true);
            Main.SetActive(true);
        }
    }

    public void ToMain()
    {
        GlobalPoint.ChongPoint += WallCount.Point;
        GlobalPoint.GoldPoint += WallCount.Gold;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        WallCount.Gold = 0;
        WallCount.Point = 0;
        WallCount.Wallcnt = 0;
        WallCount.Score = 0;
        Buttons.SetActive(true);
        WallCount.isFinished = false;
        ResultPanel.gameObject.SetActive(false);
        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        SettingBut.SetActive(true);

        Wall.round = 1;
        Time.timeScale = 1;
        SoundM.PlayButton();
        CanReborn_Wall = true;
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        GlobalPoint.ChongPoint += WallCount.Point;
        GlobalPoint.GoldPoint += WallCount.Gold;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        WallCount.Gold = 0;
        WallCount.Point = 0;
        WallCount.Wallcnt = 0;
        WallCount.Score = 0;
        Buttons.SetActive(true);
        SettingBut.SetActive(true);

        WallCount.isFinished = false;
        ResultPanel.gameObject.SetActive(false);
        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        Wall.round = 1;
        Time.timeScale = 1;
        SoundM.PlayButton();
        CanReborn_Wall = true;
        SceneManager.LoadScene(3);
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
        CanReborn_Wall = false;
        StartCoroutine(Result());
    }

    public void NotConnectData()
    {
        if (dataCheck == false) dataCheck = true;
        else
        {
            dataCheck = false;
            NotSeeAds();
        }
    }

    public void Reborn()//다시 게임하러 갑시다!!
    {
        SoundM.PlayButton();
        RebornCanvas.enabled = false;
        WallCount.isFinished = false;

        Time.timeScale = 1;
        CanReborn_Wall = false;
        SceneManager.LoadScene(3);

    }

}