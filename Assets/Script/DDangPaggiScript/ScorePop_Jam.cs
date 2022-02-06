using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePop_Jam : MonoBehaviour {

    public Text scorepop;
    int i = 1;
    WaitForSeconds delay = new WaitForSeconds(3f);

    void Start()
    {
        StartCoroutine(hello());
    }

    IEnumerator hello()
    {

        while (true)
        {
            if (DDangGlo.Point > i * 500)
            {
                int score = i * 500;
                scorepop.text = score.ToString() + "돌파!";
                i++;
                scorepop.gameObject.SetActive(true);
                yield return delay;
                scorepop.gameObject.SetActive(false);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }


        }

    }
}
