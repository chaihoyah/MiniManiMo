using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeMaze: MonoBehaviour {
    public static float time;
    public Text timetext;

    public GameObject StartImg;
	// Use this for initialization
	IEnumerator Start () {
	time = 150 + StageScript.Round*10;

        StartImg.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartImg.SetActive(false);
        if(StageScript.Round!=0)
        StartCoroutine(TimeGone());
	}
	
	IEnumerator TimeGone()
    {
        while (true)
        {
            if(Finish.roundclear.Equals(0))
            {
                time -= 0.1f;
                if (time <= 0)
                {
                    Finish.roundclear = 1;
                }
                timetext.text = "남은 시간: "+time.ToString("F2");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

}
