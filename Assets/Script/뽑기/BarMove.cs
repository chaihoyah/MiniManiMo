using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarMove : MonoBehaviour
{
    public GameObject bar;
    public GameObject floor1;
    public GameObject floor2;
    private Button Stop;
    private Vector3 barPos;
    bool hor;
    bool ver;


    void Start()
    {
        hor = true;
        ver = false;
        barPos = bar.transform.position;
    }

    public void StopPress()
    {
        if (hor == true && ver == false)
        {
            Stop1();
        }
        else if (ver == true && hor == false)
        {
            Stop2();
        }
    }

    void Stop1()//처음 버튼누름(위아래로 바뀜)
    {
        hor = false;
        ver = true;
    }

    void Stop2()//두번째 버튼누름(앞뒤로 바뀜)
    {
        hor = false;
        ver = false;
        Invoke("Judge", 5);
        StartCoroutine(WaitASecond());
        hor = false;
        ver = false;
        PickButtonPress.buttonPress = true;
    }

    void Hor()
    {
        if ( bar.transform.position.x >= 5)
        {
            hor = false;
            ver = true;
        }
    }

    void Ver()
    {
        if (barPos.y >= 13)
        {
            hor = false;
            ver = false;
            Invoke("Judge", 5);
            StartCoroutine(WaitASecond());
            PickButtonPress.buttonPress = true;
        }
    }

    void Judge()
    {
        RandomItem.panel = true;
        hor = true;
        ver = false;
        Time.timeScale = 0f;
    }

    IEnumerator WaitASecond()
    {
        yield return new WaitForSeconds(2);
    }

    void Update()
    {
        barPos = bar.transform.position;
        if (Time.timeScale == 1)
        {
            if (hor == true && ver == false)//처음
            {
                    bar.transform.position += new Vector3(0.2f, 0, 0);
                    Hor();
            }
            else if (hor == false && ver == true)//버튼 한번 누르고
            {

                    bar.transform.position = bar.transform.position + new Vector3(0, 0.2f, 0);
                    Ver();
            }
        }
    }
}