using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunTutorial : MonoBehaviour {

    public static bool tutorial = false;
    public Button rig;
    public Button lef;
    public Text text;
    public GameObject TutBack;
    bool GoNext;
    public GameObject NextGoBut;

    void Awake()
    {
        if(PlayerPrefs.GetInt("isDaliTuto").Equals(0))
        {
            tutorial = true;
        }
        else
        {
            tutorial = false;
        }
        if(tutorial)
        {
            NextGoBut.SetActive(false);
            TutBack.SetActive(true);
            GoNext = false;
            rig.enabled = false;
            lef.enabled = false;
            StartCoroutine(Tutorial());
        }
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(1);
        text.text = "이것은 달리기 튜토리얼입니다";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.text = "하단에 보이는 두 버튼이 달리기 버튼입니다";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.text = "두 버튼을 번갈아가며 누르면 캐릭터가 앞으로 빠르게 달려갑니다";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.text = "만약에 한 버튼을 연속으로 두번 누르게 되면 캐릭터가 멈추게되니 조심하세요!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.text = "이제 한번 달려볼까요?";
        yield return new WaitForSeconds(1);
        TutBack.SetActive(false);
        text.enabled = false;
        rig.enabled = true;
        lef.enabled = true;       
    }

    public void finish()
    {
        StartCoroutine(Finish());
    }

    IEnumerator Finish()
    {
        rig.enabled = false;
        lef.enabled = false;
        TutBack.SetActive(true);
        text.text = "잘하셨습니다!";
        text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.enabled = false;
        yield return new WaitForSeconds(1);
        text.text = "이렇게 어느 정도 달리면 1골드를 얻을 수 있습니다!";
        text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.text = "그럼 본격적으로 시작해 볼까요~?";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        PlayerPrefs.SetInt("isDaliTuto", 1);
        SceneManager.LoadScene(5);

    }

    public void Finish_Button()
    {
        SceneManager.LoadScene(1);
    }

    public void NextButton()
    {
        GoNext = true;
    }
}
