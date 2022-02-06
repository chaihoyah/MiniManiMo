using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class PandaDown : MonoBehaviour
{
    public GameObject Camera;

    public int PointNow;


    public static bool isSpurtOn;
    public Animator PanAnim;


    //***

    public Image ResultPanel;
    public Text scoreText;
    public Text Highsco;
    public Text PointTwo;

    public GameObject Retr;
    public GameObject Main;
    public GameObject Rank;

    public Text PointTex;

    public GameObject But1;
    public GameObject But2;
    public GameObject But1_UP;
    public GameObject But2_UP;
    public GameObject SettingBut;
    public SoundManager SoundM;

    public Image PartyTime;
    public GameObject PartyObject;
    public DDang DD;
    Color PartyOne;
    Color PartyTwo;

    public AdmobScript admob;
    public GameObject Panda;

    public Canvas AdsCanvas;//동영상 보기 전
    public Canvas RebornCanvas;//동영상 본 후(버튼 클릭 후 reborn)
    public static bool CanReborn_Jam = true;
    bool dataCheck = false;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.3f);

        isSpurtOn = false;
        PartyOne = new Color();
        PartyTwo = new Color();
        PartyOne = PartyTime.color;
        PartyTwo = new Color(PartyTime.color.r, PartyTime.color.g, PartyTime.color.b, (float)60 / 255);
        admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();

        But1.SetActive(true);
        But2.SetActive(true);
        PointNow = DDangGlo.Point;

        ResultPanel.gameObject.SetActive(false);
        if (CanReborn_Jam)
        {
            DDangGlo.Money = 0;
            DDangGlo.Point = 0;
            DDangGlo.Gold = 0;
        }
        AdsCanvas.enabled = false;
        RebornCanvas.enabled = false;

        StartCoroutine(GoDown());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wolf"))
        {
            if (!PandaDown.isSpurtOn)
            {
                SoundM.PlayJamsuDie();
                if (!DD.isPetOne)
                {
                    StartCoroutine(Result());
                }
                else if (DD.isPetOne && !DD.isPetTwo)
                {
                    Destroy(other.gameObject);
                    DDangGlo.isFinished = true;
                    StartCoroutine(WaitSec());
                    if (DDangPetOne.PetOneDie) StartCoroutine(Result());
                    else
                    {
                        DDangPetOne.PetOneDie = true;
                        DDangGlo.isFinished = false;
                    }
                }
                else
                {
                    Destroy(other.gameObject);
                    DDangGlo.isFinished = true;
                    StartCoroutine(WaitSec());
                    if (!DDangPetTwo.PetTwoDie)
                    {
                        DDangPetTwo.PetTwoDie = true;
                        DDangGlo.isFinished = false;
                    }
                    else if (DDangPetTwo.PetTwoDie && !DDangPetOne.PetOneDie)
                    {
                        DDangPetOne.PetOneDie = true;
                        DDangGlo.isFinished = false;
                    }
                    else if (DDangPetOne.PetOneDie) StartCoroutine(Result());

                    //DDangGlo.isFinished = true;
                }
            }
        }
        else if (other.CompareTag("Party"))
        {
            PartyObject.SetActive(false);
            StartCoroutine(SpurtStart());
        }
    }
    public void ResultStart()
    {
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
    IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Result()
    {
        if (CanReborn_Jam)
        {
            Time.timeScale = 0.9f;
            DDangGlo.isFinished = true;
            CanReborn_Jam = false;
            But1.SetActive(false);
            But2.SetActive(false);
            But1_UP.SetActive(false);
            But2_UP.SetActive(false);
            AdsCanvas.enabled = true;
            SettingBut.SetActive(false);
            yield return new WaitForSeconds(0.1f);

        }
        else
        {

            DDangGlo.Level = 1;
            Time.timeScale = 0.9f;
            DDangGlo.isFinished = true;
            But1.SetActive(false);
            But2.SetActive(false);
            But1_UP.SetActive(false);
            But2_UP.SetActive(false);
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
                int JamTotal = PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh");
                int Total = (PlayerPrefs.GetInt("Wallhigh") + PlayerPrefs.GetInt("WallhighEasy") + PlayerPrefs.GetInt("WallhighHard")) + PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh") + PlayerPrefs.GetInt("Wolfhigh");
                PlayerPrefs.SetInt("TotalScore", Total);
                Social.ReportScore(JamTotal, "CgkIqcqjsI0OEAIQAg", success => {
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
            Panda.transform.position = new Vector3(Panda.transform.position.x + 2, Panda.transform.position.y, Panda.transform.position.z);
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
        Panda.SetActive(true);
        Panda.transform.position = new Vector3(Panda.transform.position.x - 2, Panda.transform.position.y, Panda.transform.position.z);
        AdsCanvas.enabled = false;
        RebornCanvas.enabled = false;
        CanReborn_Jam = false;
        StartCoroutine(Result());
    }

    public void Reborn()//다시 게임하러 갑시다!!
    {
        SoundM.PlayButton();
        RebornCanvas.enabled = false;
        DDangGlo.isFinished = false;
        //But1.SetActive(true);
        //But2.SetActive(true);
        //But1_UP.SetActive(true);
        //But2_UP.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }

    IEnumerator GoDown()
    {
        while (true)
        {
            if (!DDangGlo.isFinished)
            {
                DDangGlo.Point += 1;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator SpurtStart()
    {
        yield return new WaitForSeconds(0.5f);
        PartyTime.gameObject.SetActive(true);
        int i = 0;

        isSpurtOn = true;

        while (i < 50)
        {
            if (i > 35) PartyTime.color = PartyTwo;
            DDangGlo.Point += 2;
            i++;
            yield return new WaitForSeconds(0.05f);
            PartyTime.color = PartyOne;
            yield return new WaitForSeconds(0.05f);
        }

        PartyTime.color = PartyOne;
        PartyTime.gameObject.SetActive(false);
        isSpurtOn = false;

        PointNow = DDangGlo.Point;

    }

    public void ToMain()
    {
        GlobalPoint.ChongPoint += DDangGlo.Money;
        GlobalPoint.GoldPoint += DDangGlo.Gold;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        DDangGlo.Gold = 0;
        DDangGlo.Money = 0;
        DDangGlo.Point = 0;
        MonsterRes.levelIdx = 0;
        CanReborn_Jam = true;

        Time.timeScale = 1;
        DDangGlo.isFinished = false;
        But1.SetActive(true);
        But2.SetActive(true);
        But1_UP.SetActive(true);
        But2_UP.SetActive(true);
        SettingBut.SetActive(true);
        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        SoundM.PlayButton();
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        GlobalPoint.ChongPoint += DDangGlo.Money;
        GlobalPoint.GoldPoint += DDangGlo.Gold;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        DDangGlo.Gold = 0;
        DDangGlo.Money = 0;
        DDangGlo.Point = 0;
        MonsterRes.levelIdx = 0;
        CanReborn_Jam = true;

        Time.timeScale = 1;
        DDangGlo.isFinished = false;
        But1.SetActive(true);
        But2.SetActive(true);
        But1_UP.SetActive(true);
        But2_UP.SetActive(true);
        SettingBut.SetActive(true);

        Retr.SetActive(false);
        Main.SetActive(false);
        Rank.SetActive(false);
        SoundM.PlayButton();
        SceneManager.LoadScene(4);
    }

}