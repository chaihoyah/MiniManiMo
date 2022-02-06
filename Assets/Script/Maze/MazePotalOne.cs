using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazePotalOne : MonoBehaviour {
    public GameObject Move1;// 도착지점

    public float pandaspeed;


    public GameObject panda;

    public GameObject[] BlackOut = new GameObject[2];
    public Button[] Buttons = new Button[4];
    WaitForSeconds delay = new WaitForSeconds(0.1f);

    public Image floor;
    public GameObject pos;
    public GameObject pos2;
    bool isFirst;

    private void OnEnable()
    {
        panda = GameObject.Find("MazePanda");
    }

    IEnumerator Start()
    {
        BlackOut[0] = GameObject.Find("BlackOut1");
        BlackOut[1] = GameObject.Find("BlackOut2");
        Buttons[0] = GameObject.Find("Pause").GetComponent<Button>();
        Buttons[1] = GameObject.Find("GoGo").GetComponent<Button>();
        Buttons[2] = GameObject.Find("SightLeftMove").GetComponent<Button>();
        Buttons[3] = GameObject.Find("SightRightMove").GetComponent<Button>();
        floor = GameObject.Find("Floor").GetComponent<Image>();
        pos = GameObject.Find("FloorStop1");
        pos2 = GameObject.Find("FloorStop2");
        isFirst = false;
        yield return new WaitForSeconds(4f);

        pandaspeed = 5.0f;
    }

    IEnumerator moveup()
    {
        while (10f > panda.transform.position.y)
        {
            panda.transform.position += new Vector3(0, 0.35f, 0);
            panda.transform.Rotate(new Vector3(0, 0, 1), pandaspeed);
            yield return new WaitForSeconds(0.1f);
        }
        panda.transform.position = Move1.transform.position;
        int i = 0;
        while(i<10)
        {
            BlackOut[0].transform.localPosition -= new Vector3(0, 34, 0);
            BlackOut[1].transform.localPosition += new Vector3(0, 34, 0);
            i++;
            yield return new WaitForEndOfFrame();
        }
        i = 0;
        while (i < 10)
        {
            BlackOut[0].transform.localPosition += new Vector3(0, 34, 0);
            BlackOut[1].transform.localPosition -= new Vector3(0, 34, 0);
            i++;
            yield return new WaitForEndOfFrame();
        }
        Buttons[0].enabled = true;
        Buttons[1].enabled = true;
        Buttons[2].enabled = true;
        Buttons[3].enabled = true;
        StartCoroutine(flo());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Buttons[0].enabled = false;
            Buttons[1].enabled = false;
            Buttons[2].enabled = false;
            Buttons[3].enabled = false;
            if (!isFirst)
            {
                isFirst = true;
                StartCoroutine(moveup());
            }
        }
    }

    IEnumerator flo()
    {
        while (floor.transform.position.x < pos.transform.position.x)
        {
            floor.transform.position += new Vector3(15.0f, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
        int i = 0;
        while(i<5)
        {
            floor.transform.Rotate(0, 0, -6);
            floor.transform.localPosition += new Vector3(i + 3, 0, 0);
            i++;
            yield return new WaitForSeconds(0.05f);
        }
        i = 0;
        while (i < 5)
        {
            floor.transform.Rotate(0, 0, 6);
            floor.transform.localPosition -= new Vector3(i, 0, 0);
            i++;
            yield return new WaitForSeconds(0.05f);
        }


        yield return new WaitForSeconds(1.0f);

        while (floor.transform.position.x < pos2.transform.position.x)
        {
            floor.transform.position += new Vector3(15.0f, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
        floor.gameObject.SetActive(false);
    }
}
