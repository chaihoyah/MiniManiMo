using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RandomItem : MonoBehaviour
{

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject skinbox;
    public GameObject bar;
    public GameObject Panel1;//아이템 겟
    public GameObject Panel2;//꽝
    public Text getPoint;
    public Button StartButton;
    public SoundManager SoundM;
    public static bool panel;

    public GameObject[] GoldArr = new GameObject[12];
    int GoldChk;

    Vector3 box1Pos, box2Pos, box3Pos, box4Pos, skinBoxPos, barPos;//시작위치
    int random1, random2, random3, random4, random5;//확률용
    int point_gold;//얻은 골드
    int point_silver;

    void Start()
    {
        point_silver = 0;
        point_gold = 0;
        GoldChk = 0;
        barPos = bar.transform.position;
        box1Pos = box1.transform.position;
        box2Pos = box2.transform.position;
        box3Pos = box3.transform.position;
        box4Pos = box4.transform.position;
        skinBoxPos = skinbox.transform.position;

        Panel1.SetActive(false);
        Panel2.SetActive(false);


    }
    //박스 함수(수정할꺼 있으면 수정좀)
    void RandomBox1()
    {
        random1 = Random.Range(0, 100);
        if (random1 < 40)
        {
            GoldChk = 1;
            point_silver = 1000;
        }
        else if (random1 < 55)
        {
            GoldChk = 3;
            point_silver = 2000;
        }

        else if(random1 <70)
        {
            GoldChk = 4;
            point_silver = 3000;
        }
        else
        {
            GoldChk = 0;
            point_silver = 500;
        }

        Get();
    }

    void RandomBox2()
    {
        random2 = Random.Range(0, 100);
        if (random2 < 30)
        {
            GoldChk = 1;
            point_silver = 1000;
        }
        else if (random2 < 40)
        {
            GoldChk = 3;
            point_silver = 2000;
        }
        else if(random2 <45)
        {
            GoldChk = 5;
            point_silver = 6000;
        }

        else if(random2<50)
        {
            GoldChk = 8;
            point_silver = 10000;
        }
        else
        {
            GoldChk = 0;
            point_silver = 500;
        }

        Get();
    }

    void RandomBox3()
    {
        random3 = Random.Range(0, 100);

        if (random3 < 40)
        {
            GoldChk = 9;
            point_gold = 10;
        }
        else if (random3 < 80)
        {
            GoldChk = 1;
            point_silver = 1000;
        }
        else
        {
            GoldChk = 3;
            point_silver = 2000;
        }

        Get();
    }

    void RandomBox4()
    {
        random4 = Random.Range(0, 100);
        if (random4 < 15)
        {
            GoldChk = 9;
            point_gold = 10;
        }
        else if (random4 < 40)
        {
            GoldChk = 3;
            point_silver = 2000;
        }
        else
        {
            GoldChk = 1;
            point_silver = 1000;
        }

        Get();
    }

    void SkinBox()
    {
        random5 = Random.Range(0, 100);

        if (random5 < 70)
        {
            GoldChk = 8;
            point_gold = 3;
        }
        else if (random5 < 85)
        {
            GoldChk = 9;
            point_gold = 10;
        }
        else if (random5 < 95)
        {
            GoldChk = 10;
            point_gold = 15;
        }
        else
        {
            GoldChk = 11;
            point_gold = 20;
        }
        Get();
    }

    IEnumerator OpenPanel()
    {
        if(!PickGameTutorial.tutorial)
        {
            if (panel != true) StartCoroutine(OpenPanel());
            else StartCoroutine(Pick());
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Pick()
    {
        if (box1.transform.position.y < 0)
        {
            SoundM.PlayPickGameBoxFloor();
            if (PickGameTutorial.tutorial) PickGameTutorial.success = true;
            else RandomBox1();
        }
        else if (box2.transform.position.y < 0)
        {
            SoundM.PlayPickGameBoxFloor();
            if (PickGameTutorial.tutorial) PickGameTutorial.success = true;
            else
                RandomBox2();
        }
        else if (box3.transform.position.y < 0)
        {
            SoundM.PlayPickGameBoxFloor();
            if (PickGameTutorial.tutorial) PickGameTutorial.success = true;
            else
                RandomBox3();
        }
        else if (box4.transform.position.y < 0)
        {
            SoundM.PlayPickGameBoxFloor();
            if (PickGameTutorial.tutorial) PickGameTutorial.success = true;
            else
                RandomBox4();
        }
        else if (skinbox.transform.position.y < 0)
        {
            SoundM.PlayPickGameBoxFloor();
            if (PickGameTutorial.tutorial) PickGameTutorial.success = true;
            else
                SkinBox();
        }
        else if (PickButtonPress.floorCol == true)
        {
            SoundM.PlayBoxResultBad();
            if (PickGameTutorial.tutorial) PickGameTutorial.success = false;
            else
                NOGet();
        }
        else
        {
            SoundM.PlayBoxResultBad();
            if (PickGameTutorial.tutorial) PickGameTutorial.success = false;
            else
                NOGet();
        }
        if (!PickGameTutorial.tutorial)
            Time.timeScale = 0;

        yield return new WaitForEndOfFrame();
    }
    //패널 띄우는 함수들
    void Get()
    {
        SoundM.PlayBoxResultGood();
        GlobalPoint.ChongPoint += point_silver;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        GlobalPoint.GoldPoint += point_gold;
        PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
        StartCoroutine(WaitForSeconds(2));
        Panel1.SetActive(true);
        StartCoroutine(WaitForSeconds(1));
        GoldArr[GoldChk].SetActive(true);
    }

    void NOGet()
    {
        SoundM.PlayBoxResultBad();
        StartCoroutine(WaitForSeconds(2));
        Panel2.SetActive(true);
    }

    public void Okay()//패널 버튼
    {
        GoldArr[GoldChk].SetActive(false);
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        StartButton.enabled = true;

        box1.transform.position = box1Pos;
        box2.transform.position = box2Pos;
        box3.transform.position = box3Pos;
        box4.transform.position = box4Pos;
        skinbox.transform.position = skinBoxPos;
        bar.transform.position = barPos;

        panel = false;
        SceneManager.LoadScene(2);
    }

    IEnumerator WaitForSeconds(int time)
    {
        yield return new WaitForSeconds(time);
    }

    void Update()
    {
        if (panel == true)
        {
            StartCoroutine(Pick());
            panel = false;
        }
    }
}