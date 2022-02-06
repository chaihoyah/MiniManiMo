using UnityEngine;
using System.Collections;

public class RunRight : MonoBehaviour
{

    public Rigidbody playerRB;
    public int RightCnt;
    public RunLeft Left;
    public Animator ChickAnim;
    int dif;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        RightCnt = 0;
        dif = 0;
    }
    public void RightMove()
    {
        if (Time.timeScale > 0)
        {
            RightCnt++;
            dif = Mathf.Abs(RightCnt - Left.LeftCnt);

            if (dif > 1)
            {
                RightCnt = 0;
                Left.LeftCnt = 0;
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

    IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1f);
    }
}