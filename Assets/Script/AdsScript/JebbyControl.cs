using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class JebbyControl : MonoBehaviour, IDragHandler
{
    public bool isDrag;
    public Image JebbyImg;
    public GameObject[] Result = new GameObject[5];
    public GameObject NoJebbyToday;
    Vector3 OriginEndPos;
    public Vector2 JebbyVec;
    int Ad;

    public static int result = 0;
    // Use this for initialization
    void Start () {
        NoJebbyToday.SetActive(false);
        JebbyVec = this.transform.position;
        isDrag = false;
        OriginEndPos = JebbyImg.transform.position;
        result = 0;
        for (int i = 0; i < 5; i++)
        {
            Result[i].SetActive(false);
        }
        
    }

    // Use this for initialization

    public virtual void OnDrag(PointerEventData ped)
    {
        Ad = PlayerPrefs.GetInt("Ad");
        Vector2 pos = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JebbyImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            if (!isDrag)
            {
                if(Ad>5)
                {
                    StartCoroutine(NoJeb());
                }
                else
                {                   
                    StartCoroutine(Pick());
                    isDrag = true;
                }
            }

        }
    }

    IEnumerator Pick()
    {
        Vector3 MovePos= new Vector3(0,5f,0);
        int k = 0;
        while(k<80)
        {
            JebbyImg.rectTransform.Translate(MovePos);
            k++;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        int Ran = Random.Range(0, 5);

        if(Ran.Equals(0))
        {
            Result[0].SetActive(true);
            this.transform.position = JebbyVec;
            result = 0;
        }
        else if(Ran.Equals(1))
        {
            Result[1].SetActive(true);
            this.transform.position = JebbyVec;
            result = 1;
        }
        else if (Ran.Equals(2))
        {
            Result[2].SetActive(true);
            this.transform.position = JebbyVec;
            result = 2;
        }
        else if (Ran.Equals(3))
        {
            Result[3].SetActive(true);
            this.transform.position = JebbyVec;
            result = 3;
        }
        else if (Ran.Equals(4))
        {
            Result[4].SetActive(true);
            this.transform.position = JebbyVec;
            result = 4;
        }
        yield return new WaitForSeconds(1f);
        JudgeScript.shop = true;
    }

    public void Back()
    {
        JudgeScript.shop = true;
        SceneManager.LoadScene(1);
    }

    public void NotSeeAds()
    {
        for(int i = 0; i < 5; i++)
        {
            Result[i].SetActive(false);
        }
    }

    IEnumerator NoJeb()
    {
        NoJebbyToday.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        NoJebbyToday.SetActive(false);
    }

    IEnumerator WaitSec(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                JudgeScript.shop = true;
                SceneManager.LoadScene(1);
            }
            StartCoroutine(WaitSec(2f));
        }
    }
}
