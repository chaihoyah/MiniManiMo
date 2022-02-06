using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePop_Wall : MonoBehaviour {

    public Text ScorePop;
    int i = 1;
    WaitForSeconds delay = new WaitForSeconds(3f);

    void Start()
    {
        i = 1;
        StartCoroutine(hello());
    }

    IEnumerator hello()
    {

        while (true)
        {
            if (WallCount.Score > i * 500)
            {
                int score = i * 500;
                ScorePop.text = score.ToString() + "돌파!";
                i++;
                ScorePop.gameObject.SetActive(true);
                yield return delay;
                ScorePop.gameObject.SetActive(false);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }


        }

    }
}
