using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureBox : MonoBehaviour
{
    public static int item = 0;
    public static int Point = 0;

    public SoundManager SoundM;
    private Animator TreasureAnim;

    private Image SpeedUpImg;
    private Image SpeedDownImg;
    private Image TimeUpImg;
    private Image TimeDownImg;
    private GameObject Gold;
    GameObject DesOb;
    Color SpeedUpCol = new Color();
    Color SpeedDownCol = new Color();
    Color TimeUpCol = new Color();
    Color TimeDownCol = new Color();

    Color SpeedTwo = new Color();
    Color SpeedTwoDown = new Color();
    Color TimeTwo = new Color();
    Color TimeTwoDown = new Color();

    bool trigger;

    void Awake()
    {
        SpeedUpImg = GameObject.Find("SpeedUp").GetComponent<Image>();
        SpeedDownImg = GameObject.Find("SpeedDown").GetComponent<Image>();
        TimeUpImg = GameObject.Find("TimeUp").GetComponent<Image>();
        TimeDownImg = GameObject.Find("TimeDown").GetComponent<Image>();

        SpeedUpCol = SpeedUpImg.color;
        SpeedDownCol = SpeedDownImg.color;
        TimeUpCol = TimeUpImg.color;
        TimeDownCol = TimeDownImg.color;
        SpeedTwo = new Color(SpeedUpCol.r, SpeedUpCol.g, SpeedUpCol.b, (float)20 / 255);
        SpeedTwoDown = new Color(SpeedDownCol.r, SpeedDownCol.g, SpeedDownCol.b, (float)20 / 255);
        TimeTwo = new Color(TimeUpCol.r, TimeUpCol.g, TimeUpCol.b, (float)20 / 255);
        TimeTwoDown = new Color(TimeDownCol.r, TimeDownCol.g, TimeDownCol.b, (float)20 / 255);


        SoundM = GameObject.Find("SoundM").GetComponent<SoundManager>();
    }
    void Start()
    {
        trigger = true;
        SpeedUpImg.gameObject.SetActive(false);
        SpeedDownImg.gameObject.SetActive(false);
        TimeUpImg.gameObject.SetActive(false);
        TimeDownImg.gameObject.SetActive(false);

    }


    void OnTriggerEnter(Collider col)
    {
        if (trigger == true)
        {
            if (col.CompareTag("goldWolf"))
            {
                SoundM.PlayBoxOpen();
                DesOb = col.gameObject;
                StartCoroutine(Item());
                trigger = false;
                Invoke("MakeTriggerTrue", 2);
            }
        }
    }

    void MakeTriggerTrue()
    {
        trigger = true;
    }

    IEnumerator Item()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(DesOb);
        item = Random.Range(2, 6);

        switch (item)
        {
            case 2:
                TimeMaze.time += 60f;
                StartCoroutine(TimeUp());
                break;
            case 3:
                TimeMaze.time -= 60f;
                StartCoroutine(TimeDown());
                break;
            case 4:
                StartCoroutine(SpeedUpMoon());
                break;
            case 5:
                StartCoroutine(SpeedDownMoon());
                break;
            default: break;
        }
    }

    IEnumerator TimeUp()
    {
        SoundM.PlayBoxResultGood();
        TimeUpImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        TimeUpImg.color = TimeTwo;
        yield return new WaitForSeconds(0.2f);
        TimeUpImg.color = TimeUpCol;
        yield return new WaitForSeconds(0.2f);
        TimeUpImg.color = TimeTwo;
        yield return new WaitForSeconds(0.2f);
        TimeUpImg.color = TimeUpCol;
        yield return new WaitForSeconds(0.1f);

        TimeUpImg.gameObject.SetActive(false);

    }

    IEnumerator TimeDown()
    {
        SoundM.PlayBoxResultBad();
        TimeDownImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        TimeDownImg.color = TimeTwoDown;
        yield return new WaitForSeconds(0.2f);
        TimeDownImg.color = TimeDownCol;
        yield return new WaitForSeconds(0.2f);
        TimeDownImg.color = TimeTwoDown;
        yield return new WaitForSeconds(0.2f);
        TimeDownImg.color = TimeDownCol;
        yield return new WaitForSeconds(0.1f);
        TimeDownImg.gameObject.SetActive(false);
    }


    IEnumerator SpeedUpMoon()
    {
        SoundM.PlayBoxResultGood();
        PlayerMoveMaze.speed = -0.04f;
        SpeedUpImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        SpeedUpImg.color = SpeedTwo;
        yield return new WaitForSeconds(0.2f);
        SpeedUpImg.color = SpeedUpCol;
        yield return new WaitForSeconds(0.2f);
        SpeedUpImg.color = SpeedTwo;
        yield return new WaitForSeconds(0.2f);
        SpeedUpImg.color = SpeedUpCol;
        yield return new WaitForSeconds(0.2f);
        SpeedUpImg.color = SpeedTwo;
        yield return new WaitForSeconds(0.1f);
        SpeedUpImg.color = SpeedUpCol;
        yield return new WaitForSeconds(0.1f);

        PlayerMoveMaze.speed = -0.03f;
        SpeedUpImg.gameObject.SetActive(false);
    }

    IEnumerator SpeedDownMoon()
    {
        SoundM.PlayBoxResultBad();
        PlayerMoveMaze.speed = -0.02f;
        SpeedDownImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        SpeedDownImg.color = SpeedTwoDown;
        yield return new WaitForSeconds(0.2f);
        SpeedDownImg.color = SpeedDownCol;
        yield return new WaitForSeconds(0.2f);
        SpeedDownImg.color = SpeedTwoDown;
        yield return new WaitForSeconds(0.2f);
        SpeedDownImg.color = SpeedDownCol;
        yield return new WaitForSeconds(0.2f);
        SpeedDownImg.color = SpeedTwoDown;
        yield return new WaitForSeconds(0.1f);
        SpeedDownImg.color = SpeedDownCol;
        yield return new WaitForSeconds(0.1f);
        PlayerMoveMaze.speed = -0.03f;
        SpeedDownImg.gameObject.SetActive(false);
    }
}