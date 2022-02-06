using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeString : MonoBehaviour {

    public static float nowtime;
    public Text timeText;

    public static Text PointText;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Updat());
    }

    IEnumerator Updat()
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {

            yield return new WaitForEndOfFrame();
        }
    }
}
