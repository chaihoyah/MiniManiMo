using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Common;
using UnityEngine.UI;

public class DDArrowRes : MonoBehaviour
{
    public GameObject LeftUp;
    public GameObject RightUp;
    public GameObject LeftDown;
    public GameObject RightDown;
    public GameObject Center;
    public GameObject RanDDR;
    public GameObject DDRPa;
    public GameObject DDRPet;

    public GameObject DDR;

    public GameObject CoinPet;

    public int[] ArrowArr = new int[7];
    public GameObject[] ObjArr = new GameObject[7];
    public int ArrowCnt = 0;
    public int Combo = 0;
    public Text ComboText;
    public bool isArrFull = false;
    public bool isNextGo = false;
    public Text PointTexTwo;
    Vector3 ArrowRes = Vector3.zero;
    //리저트
    public GameObject ResultPanel;
    public Text scoreText;
    public Text Highsco;
    public GameObject Buttons;
    public GameObject SettingBut;
    public GameObject Retr;
    public GameObject Main;
    public Text PointTex;
    public SoundManager SoundM;
    private int ComboAward;

    public AdmobScript admob;

    public Canvas AdsCanvas;
    public Wall Wl;
    public Animator NuAnim;
    bool isRandomBack;

    int FirPoint;
    //gold tex
    public Text GoldText;
    public GameObject GoldObj;
    public bool isSmalling;

    IEnumerator Start()
    {
        isRandomBack = false;
        if (RoundController_DDR.round > 1 || DDRTutorial.tutorial)
        {
            DDR.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            FirPoint = 15;
            if (PlayerPrefs.GetInt("Pizza3").Equals(2))
            {
                ComboAward = 3;
            }
            else
            {
                ComboAward = 1;
            }
            DDRPa = GameObject.Find("DDRPa");
            ArrowRes = new Vector3(1, 41.2f, 0);
            Wl = GameObject.Find("WallPool").GetComponent<Wall>();
            SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
            admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();
            if (!DDRTutorial.tutorial)
            {
                if (RoundController_DDR.round.Equals(3))
                {
                    StartCoroutine(SitCheckTwo());
                }
                else
                {
                    StartCoroutine(SitCheck());
                }
                StartCoroutine(ComBoAW());
                if (PlayerPrefs.GetInt("DdrPet2") != 2) CoinPet.SetActive(false);
                if (PlayerPrefs.GetInt("DdrPet3") != 2)
                {
                    DDRPet.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("DdrPet3") == 2)
                {
                    StartCoroutine(DDRpet());
                }
                SettingBut.SetActive(true);
                Buttons.SetActive(true);
                Invoke("PiChk", 1.5f);
            }
            else
            {
                CoinPet.SetActive(false);
                DDRPet.SetActive(false);
                SettingBut.SetActive(true);
                Buttons.SetActive(true);
            }
        }
        else
        {
            DDR.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            Wl = GameObject.Find("WallPool").GetComponent<Wall>();
            SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
            admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();
            if (PlayerPrefs.GetInt("DdrPet2") != 2) CoinPet.SetActive(false);
            if (PlayerPrefs.GetInt("DdrPet3") != 2)
            {
                DDRPet.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("DdrPet3") == 2)
            {
                StartCoroutine(DDRpet());
            }
            SettingBut.SetActive(true);
            Buttons.SetActive(true);
        }
    }

    void PiChk()
    {
        if (Wl.isShr)
        {
            FirPoint = 20;
        }
    }

    IEnumerator ComBoAW()
    {
        int MaxCombo = 0;
        while (true)
        {
            if (Combo > MaxCombo)
            {
                MaxCombo = Combo;
                WallCount.Gold += ComboAward;
                ComboAward++;
                StartCoroutine(GoldTextShow());
            }
            
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator GoldTextShow()
    {
        GoldText.text = Combo.ToString();
        GoldText.gameObject.SetActive(true);
        GoldObj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        GoldText.gameObject.SetActive(true);
        GoldObj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        GoldText.gameObject.SetActive(true);
        GoldObj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        GoldText.gameObject.SetActive(true);
        GoldObj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        GoldText.gameObject.SetActive(false);
        GoldObj.SetActive(false);
    }

    IEnumerator SitCheck()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            if (ArrowCnt > 5)
            {
                WallCount.isFinished = true;
                StartCoroutine(Result());
                isArrFull = true;
            }
            if (!WallCount.isFinished)
                ArrowShow();
            if (isArrFull) yield break;
            if (Wall.round.Equals(1)) yield return new WaitForSeconds(2f);
            else if (Wall.round.Equals(2)) yield return new WaitForSeconds(1.8f);
            else yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator SitCheckTwo()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            if (ArrowCnt > 5)
            {
                WallCount.isFinished = true;
                StartCoroutine(Result());
                isArrFull = true;
            }
            if (!WallCount.isFinished)
                ArrowShowHard();
            if (isArrFull) yield break;
            if (Wall.round.Equals(1)) yield return new WaitForSeconds(2f);
            else if (Wall.round.Equals(2)) yield return new WaitForSeconds(1.8f);
            else yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator DDRpet()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            NuAnim.SetBool("isDo", true);
            if (ArrowCnt - 1 >= 0)
            {
                SoundM.PlayDDR();
                StartCoroutine(small(ObjArr[ArrowCnt - 1]));
                //Destroy(ObjArr[ArrowCnt - 1]);
                ArrowCnt--;
            }
            for (int i = ArrowCnt; i < ObjArr.Length - 1; i++)
            {
                if (ArrowCnt - 1 < 0) continue;
                ArrowArr[i] = ArrowArr[i + 1];
                ObjArr[i] = ObjArr[i + 1];
            }
            yield return new WaitForSeconds(1);
            NuAnim.SetBool("isDo", false);
        }
    }

    IEnumerator small(GameObject ddr)
    {
        Vector3 scale = ddr.transform.localScale;
        for (int i = 0; i < 15; i++)
        {
            if(ddr !=null)
            ddr.transform.localScale -= 0.05f * scale;
            yield return new WaitForSeconds(0.01f);
        }
        if (ddr.Equals(RanDDR)) WallCount.Score += 50;
        else WallCount.Score += 10;
        Destroy(ddr);
        isSmalling = false;
    }

    private void ArrowShow()
    {
        int ArrowNum = Random.Range(1, 6);
        if (ArrowCnt < 0) ArrowCnt = 0;
        else if (ArrowCnt > 6) ArrowCnt = 6;
        if (ArrowNum.Equals(1))
        {
            var createImage = Instantiate(LeftUp, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 1;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(2))
        {
            var createImage = Instantiate(RightUp, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 2;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(3))
        {
            var createImage = Instantiate(LeftDown, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 3;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(4))
        {
            var createImage = Instantiate(RightDown, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 4;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(5))
        {
            var createImage = Instantiate(Center, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 5;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }
    }

    private void ArrowShowHard()
    {
        int ArrowNum=1;
        if (isRandomBack)
        {
            ArrowNum = Random.Range(1, 6);
            isRandomBack = false;
        }
        else { ArrowNum = Random.Range(1, 7); }
        if (ArrowCnt < 0) ArrowCnt = 0;
        else if (ArrowCnt > 6) ArrowCnt = 6;
        if (ArrowNum.Equals(1))
        {
            var createImage = Instantiate(LeftUp, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 1;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(2))
        {
            var createImage = Instantiate(RightUp, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 2;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(3))
        {
            var createImage = Instantiate(LeftDown, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 3;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(4))
        {
            var createImage = Instantiate(RightDown, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 4;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }

        else if (ArrowNum.Equals(5))
        {
            var createImage = Instantiate(Center, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
            createImage.transform.SetParent(DDRPa.transform, false);
            ArrowArr[ArrowCnt] = 5;
            ObjArr[ArrowCnt] = createImage;
            ArrowCnt++;
        }
        else if (ArrowNum.Equals(6))
        {
            int RanGO = Random.Range(1, 3);
            if (RanGO.Equals(1))
            {
                var createImage = Instantiate(RanDDR, ArrowRes, new Quaternion(0, 0, 0, 0)) as GameObject;
                createImage.transform.SetParent(DDRPa.transform, false);
                ArrowArr[ArrowCnt] = Random.Range(1, 6);
                ObjArr[ArrowCnt] = createImage;
                ArrowCnt++;
            }
            else
            {
                isRandomBack = true;
                ArrowShowHard();
            }
        }

    }

    private void NextGo()
    {
        ArrowCnt--;
        for (int i = 0; i < ArrowArr.Length - 1; i++)
        {
            ArrowArr[i] = ArrowArr[i + 1];
            ObjArr[i] = ObjArr[i + 1];
            isNextGo = false;
        }
    }

    IEnumerator Result()
    {
        if (PlayerCollids.CanReborn_Wall)
        {
            Buttons.SetActive(false);
            SettingBut.SetActive(false);
            Time.timeScale = 0.9f;
            WallCount.isFinished = true;
            AdsCanvas.enabled = true;
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
                int Total = (PlayerPrefs.GetInt("Wallhigh") + PlayerPrefs.GetInt("WallhighEasy") + PlayerPrefs.GetInt("WallhighHard")) + PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh") + PlayerPrefs.GetInt("Wolfhigh");
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
            Retr.SetActive(true);
            Main.SetActive(true);
            GlobalPoint.ChongPoint += WallCount.Point;
            WallCount.Point = 0;
            WallCount.Wallcnt = 0;
            WallCount.Score = 0;
        }
    }

    void Update()
    {
        if (isNextGo)
        {
            NextGo();
        }
        if (RoundController_DDR.round != 1)
            ComboText.text = Combo.ToString() + " 콤보!!";
    }

    public void Tutorial()
    {
        ArrowShow();
    }
}