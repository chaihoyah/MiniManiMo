using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour
{

    public Text scoreText;
    public static float time;
    public static float HighTime;
    public static bool isFinished;

    void Start()
    {
        isFinished = false;
        HighTime = PlayerPrefs.GetFloat("Wolfhigh");
        StartCoroutine(Updat());
    }
    IEnumerator Updat()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            if (isFinished == false)
            {
                time += 1;
                scoreText.text = "점수: " + (time*10).ToString("F2");
                yield return new WaitForSeconds(1f);
            }
            else break;
        }

    }

}