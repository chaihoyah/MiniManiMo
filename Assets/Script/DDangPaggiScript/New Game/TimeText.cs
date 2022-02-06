using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{

    public static int Point = 0;
    public static int Money = 0;
    public static int HighPoint = 0;
    public Text Timetext;
    public Text MoneyText;

    public static bool isFinished;
    int T;
    // Use this for initialization

    void Start()
    {
        if (!NewJam_Tuto.isPanTuto)
        {
            T = Point;
            StartCoroutine(TimeTT());
            StartCoroutine(TimeT());
        }

    }

    IEnumerator TimeT()
    {
        while (true)
        {
            if (!isFinished && Time.timeScale.Equals(1))
            {
                MoneyText.text = Money.ToString();
                yield return new WaitForSeconds(0.01f);
            }
            else
                yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator TimeTT()
    {
        while (true)
        {
            if (!isFinished && Time.timeScale.Equals(1))
            {
                yield return new WaitForSeconds(1);
                Point++;
                Timetext.text = (Point * 10).ToString();
            }
            else
                yield return new WaitForSeconds(0.01f);
        }
    }

}