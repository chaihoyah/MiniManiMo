using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StageScript : MonoBehaviour
{
    public static int Round=0;
    public Image Lock_Image;
    private Image[] LockImage;
    public Button[] stage;
    public Button stage0;
    public Button stage1;
    public Button stage2;
    public Button stage3;
    public Button stage4;
    public Button stage5;
    public Button stage6;
    public Button stage7;
    public Button stage8;
    public Button stage9;
    public Button stage10;
    public Button stage11;
    public Button stage12;
    public Button stage13;
    public Button stage14;
    public Button stage15;
    public Button stage16;
    public Button stage17;
    public Button stage18;
    public Button stage19;
    public Button stage20;
    public Button stage21;
    public Button stage22;
    public Button stage23;
    public Button stage24;
    public Button stage25;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;
    public GameObject FirstPage;
    public GameObject SecondPage;

    void Awake()
    {
        LockImage = new Image[26];
        stage = new Button[26];
        stage[0] = stage0;
        stage[1] = stage1;
        stage[2] = stage2;
        stage[3] = stage3;
        stage[4] = stage4;
        stage[5] = stage5;
        stage[6] = stage6;
        stage[7] = stage7;
        stage[8] = stage8;
        stage[9] = stage9;
        stage[10] = stage10;
        stage[11] = stage11;
        stage[12] = stage12;
        stage[13] = stage13;
        stage[14] = stage14;
        stage[15] = stage15;
        stage[16] = stage16;
        stage[17] = stage17;
        stage[18] = stage18;
        stage[19] = stage19;
        stage[20] = stage20;
        stage[21] = stage21;
        stage[22] = stage22;
        stage[23] = stage23;
        stage[24] = stage24;
        stage[25] = stage25;
        for (int j = 1; j <= 25; j++) stage[j].transform.FindChild("lock").gameObject.SetActive(false);
        for (int i = 1; i <= 25; i++)
        {
            if (PlayerPrefs.GetInt("Mazeround") < i)
            {
                stage[i].transform.FindChild("lock").gameObject.SetActive(true);
                stage[i].enabled = false;
            }
            else
            {
                stage[i].enabled = true;
            }
        }

    }

    public void Click0()
    {
        Round = 0;
        SceneManager.LoadScene("scene");
    }


    public void Click1()
    {
        Round = 1;
        SceneManager.LoadScene("scene");

    }
    public void Click2()
    {
        Round = 2;
        SceneManager.LoadScene("scene");

    }
    public void Click3()
    {
        Round = 3;
        SceneManager.LoadScene("scene");

    }
    public void Click4()
    {
        Round = 4;
        SceneManager.LoadScene("scene");

    }
    public void Click5()
    {
        Round = 5;
        SceneManager.LoadScene("scene");

    }
    public void Click6()
    {
        Round = 6;
        SceneManager.LoadScene("scene");

    }
    public void Click7()
    {
        Round = 7;
        SceneManager.LoadScene("scene");

    }
    public void Click8()
    {
        Round = 8;
        SceneManager.LoadScene("scene");

    }
    public void Click9()
    {
        Round = 9;
        SceneManager.LoadScene("scene");

    }
    public void Click10()
    {
        Round = 10;
        SceneManager.LoadScene("scene");

    }
    public void Click11()
    {
        Round = 11;
        SceneManager.LoadScene("scene");

    }
    public void Click12()
    {
        Round = 12;
        SceneManager.LoadScene("scene");

    }
    public void Click13()
    {
        Round = 13;
        SceneManager.LoadScene("scene");

    }
    public void Click14()
    {
        Round = 14;
        SceneManager.LoadScene("scene");

    }
    public void Click15()
    {
        Round = 15;
        SceneManager.LoadScene("scene");

    }
    public void Click16()
    {
        Round = 16;
        SceneManager.LoadScene("scene");

    }
    public void Click17()
    {
        Round = 17;
        SceneManager.LoadScene("scene");

    }
    public void Click18()
    {
        Round = 18;
        SceneManager.LoadScene("scene");

    }
    public void Click19()
    {
        Round = 19;
        SceneManager.LoadScene("scene");

    }
    public void Click20()
    {
        Round = 20;
        SceneManager.LoadScene("scene");

    }

    public void Click21()
    {
        Round = 21;
        SceneManager.LoadScene("scene");
    }

    public void Click22()
    {
        Round = 22;
        SceneManager.LoadScene("scene");
    }
    public void Click23()
    {
        Round = 23;
        SceneManager.LoadScene("scene");
    }
    public void Click24()
    {
        Round = 24;
        SceneManager.LoadScene("scene");
    }
    public void Click25()
    {
        Round = 25;
        SceneManager.LoadScene("scene");
    }

    public void RightClick()
    {
        StartCoroutine(RightMov());

    }

    public void LeftClick()
    {
        StartCoroutine(LeftMov());
    }

    IEnumerator RightMov()
    {
        ButtonRight.SetActive(false);
        SecondPage.transform.localPosition = new Vector3(-650, 0, 0);
        SecondPage.SetActive(true);
        while (FirstPage.transform.localPosition.x<650)
        {
            FirstPage.transform.localPosition += new Vector3(20, 0, 0);
            SecondPage.transform.localPosition += new Vector3(20, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        FirstPage.SetActive(false);
        SecondPage.transform.localPosition = new Vector3(0, 0, 0);
        ButtonLeft.SetActive(true);
    }

    IEnumerator LeftMov()
    {
        ButtonLeft.SetActive(false);
        FirstPage.transform.localPosition = new Vector3(650, 0, 0);
        FirstPage.SetActive(true);
        while (SecondPage.transform.localPosition.x > -650)
        {
            FirstPage.transform.localPosition -= new Vector3(20, 0, 0);
            SecondPage.transform.localPosition -= new Vector3(20, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        SecondPage.SetActive(false);
        FirstPage.transform.localPosition = new Vector3(0, 0, 0);
        ButtonRight.SetActive(true);
    }

}