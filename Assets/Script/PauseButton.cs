using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseButton : MonoBehaviour
{

    public GameObject PaPa;

    public Button button1;
    public Button button2;
    public Button button3;

    public Canvas SettingCanvas;
    //DDR
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    //Jam
    public Button But1;
    public Button But2;
    public RightTouchMove RTM;
    public LeftTouchMove LTM;
    //new Jam
    public Button JamJum;
    //Maze
    public Button Bu1;
    public Button Bu2;
    public Button Bu3;

    public Button B1;
    public Button B2;
    public Button B3;

    public Button[] WolfAtt = new Button[4];
    public Button[] WolfDol = new Button[4];//마지막은 Next

    public static bool ddr = false, swim = false, wolf = false, run = false, maze = false;

    void Start()
    {
        SettingCanvas.enabled = false;
    }

    public void Pause()
    {
        WallCount.isFinished = true;
        DDangGlo.isFinished = true;
        ScoreScript.isFinished = true;
        Time.timeScale = 0;
        PaPa.gameObject.SetActive(true);
        if (Bu1 != null)
        {
            Bu1.gameObject.SetActive(false);
            Bu2.gameObject.SetActive(false);
            Bu3.gameObject.SetActive(false);
        }
        if (Button1 != null)
        {
            Button1.enabled = false;
            Button2.enabled = false;
            Button3.enabled = false;
            Button4.enabled = false;
            Button5.enabled = false;
        }
        if (But1 != null)
        {
            But1.enabled = false;
            But2.enabled = false;
            RTM.isPause = true;
            LTM.isPause = true;
        }

        if (B1 != null)
        {
            B1.enabled = false;
            B2.enabled = false;
            B3.gameObject.SetActive(false);
        }

        if (WolfDol[0] != null)
        {
            for (int i = 0; i < 4; i++)
            {
                if (WolfAtt[i].gameObject.activeInHierarchy == true)
                {
                    WolfAtt[i].enabled = false;
                }
                WolfDol[i].enabled = false;
            }
        }
        if (JamJum != null)
        {
            JamJum.enabled = false;
        }

    }
    public void DaligiQuit()
    {

        TimeString.nowtime = 0;

        B1.enabled = true;
        B2.enabled = true;
        B3.gameObject.SetActive(true);

        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }

    public void JamsuQuit()
    {
        RebornScript.reborn = false;
        DDangGlo.Money = 0;
        DDangGlo.Point = 0;
        MonsterRes.levelIdx = 0;
        DDangGlo.isFinished = false;
        Time.timeScale = 1;

        But1.enabled = true;
        But2.enabled = true;
        RTM.isPause = false;
        LTM.isPause = false;

        SceneManager.LoadScene(1);
    }

    public void WolfQuit()
    {
        Time.timeScale = 1;
        RebornScript.reborn = false;
        ScoreScript.time = 0;
        coinScript.coin = 0;
        coinScript.gold = 0;
        ScoreScript.isFinished = false;
        for (int i = 0; i < 4; i++)
        {
            if (WolfAtt[i].gameObject.activeInHierarchy == true)
            {
                WolfAtt[i].enabled = true;
            }
            WolfDol[i].enabled = true;
        }

        SceneManager.LoadScene(1);
    }

    public void MazeQuit()
    {
        Finish.roundclear = 0;
        Time.timeScale = 1;

        Bu1.gameObject.SetActive(true);
        Bu2.gameObject.SetActive(true);
        Bu3.gameObject.SetActive(true);

        SceneManager.LoadScene(1);
    }

    public void WallQuit()
    {
        Time.timeScale = 1;
        RebornScript.reborn = false;
        WallCount.isFinished = false;
        WallCount.Point = 0;
        WallCount.Score = 0;
        WallCount.Wallcnt = 0;
        Button1.enabled = true;
        Button2.enabled = true;
        Button3.enabled = true;
        Button4.enabled = true;
        Button5.enabled = true;

        SceneManager.LoadScene(1);
    }

    public void newJamQuit()
    {
        RebornScript.reborn = false;
        DDangGlo.Money = 0;
        DDangGlo.Point = 0;
        DDangGlo.isFinished = false;
        Time.timeScale = 1;

        JamJum.enabled = true;

        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        SettingCanvas.enabled = true;
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
    }

    public void SettingQuit()
    {
        SettingCanvas.enabled = false;
        button1.enabled = true;
        button2.enabled = true;
        button3.enabled = true;
    }

    public void ToGame()
    {
        ScoreScript.isFinished = false;
        WallCount.isFinished = false;
        DDangGlo.isFinished = false;
        Time.timeScale = 1f;

        if (Bu1 != null)
        {
            Bu1.gameObject.SetActive(true);
            Bu2.gameObject.SetActive(true);
            Bu3.gameObject.SetActive(true);
        }
        if (Button1 != null)
        {
            Button1.enabled = true;
            Button2.enabled = true;
            Button3.enabled = true;
            Button4.enabled = true;
            Button5.enabled = true;
        }
        if (But1 != null)
        {

            But1.enabled = true;
            But2.enabled = true;
            RTM.isPause = false;
            LTM.isPause = false;
        }
        if (B1 != null)
        {
            B1.enabled = true;
            B2.enabled = true;
            B3.gameObject.SetActive(true);
        }
        if (WolfDol[0] != null)
        {
            for (int i = 0; i < 4; i++)
            {
                if (WolfAtt[i].gameObject.activeInHierarchy == true)
                {
                    WolfAtt[i].enabled = true;
                }
                WolfDol[i].enabled = true;
            }
        }
        if (JamJum != null)
        {
            JamJum.enabled = true;
        }
        PaPa.gameObject.SetActive(false);
    }

    IEnumerator WaitSec(float time)
    {
        yield return new WaitForSeconds(time);
    }
}