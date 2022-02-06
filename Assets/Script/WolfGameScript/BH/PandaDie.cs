using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PandaDie : MonoBehaviour
{

    public Image ResultPanel;
    public Text scoreText;
    public Text Highsco;
    public Text PoTwo;

    public GameObject Retr;
    public GameObject Main;
    public GameObject Rank;

    public Text PointTex;

    public Button[] WolfAtt = new Button[4];
    public Button[] WolfDol = new Button[4];//마지막은 Next

    public GameObject SettingBut;

    public SoundManager SoundM;

    public AdmobScript admob;

    public Canvas AdsCanvas;
    public Canvas RebornCanvas;

    public static bool CanReborn_Wolf = true;

    public int PanHP;
    public int PanChongHP;

    public RawImage HPImg;
    float HP;
    bool dataCheck = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("WolfHp3Upgrade").Equals(1)) PanChongHP = 600;
        else if (PlayerPrefs.GetInt("WolfHp2Upgrade").Equals(1)) PanChongHP = 500;
        else if (PlayerPrefs.GetInt("WolfHp1Upgrade").Equals(1)) PanChongHP = 400;
        else PanChongHP = 300;// 지우기
        admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();
        if (CanReborn_Wolf)
        {
            coinScript.coin = 0;
            coinScript.gold = 0;
            ScoreScript.time = 0;
        }
        AdsCanvas.enabled = false;
        RebornCanvas.enabled = false;
        ResultPanel.gameObject.SetActive(false);
        Retr.SetActive(false);
        Main.SetActive(false);
        PanHP = PanChongHP;
        HP = (float)PanHP / PanChongHP;
        StartCoroutine(HPCheck());
    }

    IEnumerator HPCheck()
    {
        while(true)
        {
            if(PanHP<=0)
            {
                PanHP = 0;
                StartCoroutine(Result());
                yield break;
            }
            yield return new WaitForSeconds(0.5f);
        }
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

    IEnumerator Result()
    {
        if(CanReborn_Wolf)
        {
            for (int i = 0; i < 4; i++)
            {
                if (WolfAtt[i].gameObject.activeInHierarchy == true)
                {
                    WolfAtt[i].enabled = false;
                }
                WolfDol[i].enabled = false;
            }
            ScoreScript.isFinished = true;
            Time.timeScale = 0.5f;
            SettingBut.SetActive(false);
            AdsCanvas.enabled = true;
            yield return new WaitForSeconds(0.1f);

        }
        else
        {
            Time.timeScale = 0.5f;
            ScoreScript.isFinished = true;
            SettingBut.SetActive(false);
            for (int i = 0; i < 4; i++)
            {
                if (WolfAtt[i].gameObject.activeInHierarchy == true)
                {
                    WolfAtt[i].enabled = false;
                }
                WolfDol[i].enabled = false;
            }

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
            scoreText.text = "Score:" + " " + (ScoreScript.time*10).ToString();
            yield return new WaitForSeconds(0.1f);
            int a;
            a = Random.Range(0, 2);
            if (a.Equals(1)) admob.ShowAD();
            if (ScoreScript.time*10 >= ScoreScript.HighTime)
            {
                //패널 하나더 넣을까?
                ScoreScript.HighTime = ScoreScript.time*10;
                PlayerPrefs.SetFloat("Wolfhigh", ScoreScript.HighTime);
                int Total = (PlayerPrefs.GetInt("Wallhigh") + PlayerPrefs.GetInt("WallhighEasy") + PlayerPrefs.GetInt("WallhighHard")) + PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh") + PlayerPrefs.GetInt("Wolfhigh");
                PlayerPrefs.SetInt("TotalScore", Total);
                long High = (long)ScoreScript.HighTime;
                if (Social.localUser.authenticated)
                {
                    Social.ReportScore(High, "CgkIqcqjsI0OEAIQAw", success =>
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
                Highsco.text = "High Score:" + " " + ScoreScript.HighTime.ToString();

            }
            else
            {
                Highsco.text = "High Score:";
                yield return new WaitForSeconds(0.3f);
                Highsco.text = "High Score:" + " " + ScoreScript.HighTime.ToString();

            }
            yield return new WaitForSeconds(0.1f);
            PointTex.text = "Silver: " + coinScript.coin.ToString();
            PoTwo.text = "Gold: " + coinScript.gold.ToString();
            Rank.SetActive(true);
            Retr.SetActive(true);
            Main.SetActive(true);
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
        CanReborn_Wolf = false;
        StartCoroutine(Result());
    }

    public void Reborn()//다시 게임하러 갑시다!!
    {
        SoundM.PlayButton();
        RebornCanvas.enabled = false;
        ScoreScript.isFinished = false;
        SettingBut.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            if (WolfAtt[i].gameObject.activeInHierarchy == true)
            {
                WolfAtt[i].enabled = true;
            }
            WolfDol[i].enabled = true;
        }
        Time.timeScale = 1;
        CanReborn_Wolf = false;
        SceneManager.LoadScene(7);

    }

    public void ToMain()
    {
        GlobalPoint.GoldPoint += coinScript.gold;
        GlobalPoint.ChongPoint += coinScript.coin;
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        ScoreScript.time = 0;
        coinScript.coin = 0;
        coinScript.gold = 0;
        Time.timeScale = 1f;
        ScoreScript.isFinished = false;

        SettingBut.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            if (WolfAtt[i].gameObject.activeInHierarchy == true)
            {
                WolfAtt[i].enabled = true;
            }
            WolfDol[i].enabled = true;
        }
        CanReborn_Wolf = true;

        ResultPanel.gameObject.SetActive(false);

        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        SoundM.PlayButton();
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        GlobalPoint.GoldPoint += coinScript.gold;
        GlobalPoint.ChongPoint += coinScript.coin;
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        ScoreScript.time = 0;
        coinScript.coin = 0;
        coinScript.gold = 0;
        Time.timeScale = 1f;
        ScoreScript.isFinished = false;

        CanReborn_Wolf = true;
        for (int i = 0; i < 4; i++)
        {
            if (WolfAtt[i].gameObject.activeInHierarchy == true)
            {
                WolfAtt[i].enabled = true;
            }
            WolfDol[i].enabled = true;
        }
        ResultPanel.gameObject.SetActive(false);

        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        SoundM.PlayButton();
        SceneManager.LoadScene(7);
    }

    void Update()
    {
        if (PanHP > 0)
        {
            HP = (float)PanHP / PanChongHP;
            HPImg.transform.localScale = new Vector3(HP, 1, 1);
        }
        else
        {
            HPImg.transform.localScale = new Vector3(0, 1, 1);
        }
    }
}