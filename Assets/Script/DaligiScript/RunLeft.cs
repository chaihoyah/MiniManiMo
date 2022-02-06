using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RunLeft : MonoBehaviour
{

    public Rigidbody playerRB;
    public int LeftCnt;
    public RunRight Right;
    public Animator ChickAnim;
    int dif;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        LeftCnt = 0;
        dif = 0;
        StartCoroutine(SlowDown());
    }
    public void LeftMove()
    {
        if (Time.timeScale > 0)
        {
            LeftCnt++;
            dif = Mathf.Abs(LeftCnt - Right.RightCnt);

            if (dif > 1)
            {

                LeftCnt = 0;
                Right.RightCnt = 0;
                ChickAnim.SetBool("isCrushed", true);
                playerRB.velocity = Vector3.zero;
                playerRB.angularVelocity = Vector3.zero;
                StartCoroutine(WaitSec());
                ChickAnim.SetBool("isCrushed", false);

            }
            else
            {
                playerRB.AddForce(-300, 0, 0);
            }
        }
    }

    IEnumerator SlowDown()
    {
        while (true)
        {
            if (Time.timeScale > 0)
            {
                playerRB.velocity = playerRB.velocity * 0.9f;
                playerRB.angularVelocity = playerRB.angularVelocity * 0.9f;
            }
            yield return new WaitForSeconds(0.2f);

        }
    }

    IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1f);
    }


}