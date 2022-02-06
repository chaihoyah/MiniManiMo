using UnityEngine;
using System.Collections;

public class WolfGameRound : MonoBehaviour {

    public static int round = 1;

    void Start ()
    {
        StartCoroutine(RoundFunction());
	}

    IEnumerator RoundFunction()
    {
        while (!ScoreScript.isFinished)
        {
            if (round == 1)
            {
                yield return new WaitForSeconds(60);
                round += 1;
            }
            if (round == 2)
            {
                yield return new WaitForSeconds(60);
                round += 1;
            }
            if (round == 3)
            {
                yield return new WaitForSeconds(80);
                round += 1;
            }
            else yield return new WaitForEndOfFrame();
        }
    }
}
