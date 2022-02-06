using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DDangGlo : MonoBehaviour
{
    public static int NewHighPoint = 0;
    public static int Point = 0;
    public static int Money = 0;
    public static int Gold = 0;
    public static int HighPoint = 0;
    public static int Level = 1;
    public static Text PointText;
    public static Text MoneyText;
    public Text GoldText;

    public static bool isFinished;

    void Awake()
    {

        PointText = GameObject.Find("Point").GetComponent<Text>();
        MoneyText = GameObject.Find("Money").GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {
        isFinished = false;
        PointText.text = Point.ToString();
        MoneyText.text = Money.ToString();
        GoldText.text = Gold.ToString();
        HighPoint = PlayerPrefs.GetInt("Swimhigh");
        if (!JamSoo_Tutorial.isPanTuto)
            StartCoroutine(UpDat());
    }

    IEnumerator UpDat()
    {
        while (true)
        {
            PointText.text = "Point: " + Point.ToString();
            MoneyText.text = Money.ToString();
            GoldText.text = Gold.ToString();
            yield return new WaitForEndOfFrame();
        }
    }

}