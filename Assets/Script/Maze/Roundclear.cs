using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Roundclear : MonoBehaviour
{
    public GameObject panda;
    public GameObject ResultPanel;
    public GameObject MainTwo;
    public GameObject Success;
    public GameObject Fail;
    public GameObject But1;
    public GameObject But2;
    public GameObject But3;
    public Text LeftTime;

    public GameObject Retr;
    public GameObject RetReal;
    public GameObject Main;

    public Image Reward;

    public AdmobScript admob;

    public SoundManager SoundM;
    // Use this for initialization
    void Start()
    {
        Reward.enabled = false;
        StartCoroutine(Fini());
        admob = GameObject.Find("AdmobManager").GetComponent<AdmobScript>();
    }

    IEnumerator Fini()
    {
        while (true)
        {
            if (Finish.roundclear.Equals(1))
            {
                StartCoroutine(Result());
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Result()
    {
        Time.timeScale = 0.5f;
        But1.SetActive(false);
        But2.SetActive(false);
        But3.SetActive(false);

        yield return new WaitForSeconds(1f);

        ResultPanel.gameObject.SetActive(true);
        if (TimeMaze.time <= 0)
        {
            Fail.SetActive(true);
        }
        else
        {
            Success.SetActive(true);
            if (PlayerPrefs.GetInt("Mazeround") == StageScript.Round)
            {
                GlobalPoint.ChongPoint += 1500;
                PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);                
                Reward.enabled = true;
                SoundM.PlayBoxResultGood();
                PlayerPrefs.SetInt("Mazeround", StageScript.Round+1);
            }
            StageScript.Round++;
        }
        LeftTime.text = "LeftTime: ";
        yield return new WaitForSeconds(0.2f);
        LeftTime.text = "LeftTime: " + TimeMaze.time.ToString();
        yield return new WaitForSeconds(0.1f);

        admob.ShowAD();
        if(StageScript.Round.Equals(26))
        {
            MainTwo.SetActive(true);
        }
        else
        {
            if (TimeMaze.time > 0)
            {
                Retr.SetActive(true);
                Main.SetActive(true);
            }
            else
            {
                RetReal.SetActive(true);
                Main.SetActive(true);
            }
        }  
        Finish.roundclear = 0;

        TreasureBox.Point = 0;
        yield return new WaitForSeconds(1);
        Reward.enabled = false;

    }
    public void ToMain()
    {
        Finish.roundclear = 0;
        Time.timeScale = 1f;
        ResultPanel.gameObject.SetActive(false);
        Retr.SetActive(false);
        RetReal.SetActive(false);
        Main.SetActive(false);
        MainTwo.SetActive(false);
        SoundM.PlayButton();
        But1.SetActive(true);
        But2.SetActive(true);
        But3.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        Finish.roundclear = 0;
        Time.timeScale = 1f;
        ResultPanel.gameObject.SetActive(false);
        Retr.SetActive(false);
        RetReal.SetActive(false);
        Main.SetActive(false);
        MainTwo.SetActive(false);
        But1.SetActive(true);
        But2.SetActive(true);
        But3.SetActive(true);
        SoundM.PlayButton();
        SceneManager.LoadScene(6);
    }
}