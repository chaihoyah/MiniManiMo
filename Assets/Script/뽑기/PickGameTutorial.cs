using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickGameTutorial : MonoBehaviour
{

    public Button Left;
    public Button Right;
    public Button Money;
    public Text text;
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public static bool tutorial = false;
    public static bool nice = false, success;
    bool GoNext;
    public GameObject NextGoBut;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("PickFirst").Equals(0))
        {
            NextGoBut.SetActive(true);
            GoNext = false;
            Right.enabled = false;
            Left.enabled = false;
            tutorial = true;
            Money.enabled = false;
            StartCoroutine(Tutorial());
        }

    }

    IEnumerator Tutorial()
    {
        text.text = "안녕하세요!!뽑기 튜토리얼입니다";
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
        text.text = "뽑기는 1000실버를 넣고 알을 뽑는 게임입니다";
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
        text.text = "알 속에는 다양한 금액의 실버가 들어있습니다";
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
        text.text = "우선 돈을 넣는 법을 알려드리겠습니다";
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
        text.text = "돈은 아래에 보이는 버튼을 눌러 돈을 투입합니다";
        text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Arrow1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Arrow1.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Arrow1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Arrow1.SetActive(false);
        yield return new WaitForSeconds(1);
        text.enabled = false;
        yield return new WaitForSeconds(1);
        text.text = "이제 돈을 넣어 보세요";
        text.enabled = true;
        Money.enabled = true;
        while (!nice)
            yield return new WaitForSeconds(0.1f);
        Left.enabled = false;
        text.text = "잘하셨습니다";
        text.enabled = true;
        nice = false;
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.enabled = false;
        text.text = "돈을 넣으면 보이는 거와 같이 아래에 한 개의 버튼이 생깁니다";
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
        text.text = "왼쪽 버튼을 누르면 오른쪽으로 막대기가 움직이고 다시 왼쪽 버튼을 눌러야 멈출 수 있습니다";
        text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Arrow2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Arrow2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Arrow2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Arrow2.SetActive(false);
        yield return new WaitForSeconds(1);
        text.enabled = false;
        yield return new WaitForSeconds(1);
        text.text = "한번 해봅시다!!";
        text.enabled = true;
        Left.enabled = true;
        while (!nice)
            yield return new WaitForSeconds(0.1f);
        Left.enabled = false;
        text.text = "잘하셨습니다";
        text.enabled = true;
        nice = false;
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.enabled = false;
        text.text = "오른쪽으로 움직였다면 이제 위로 움직여야겠죠?";
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
        text.text = "오른쪽 버튼도 마찬가지로 누르면 막대기가 위로 움직이고 다시 오른쪽 버튼을 눌러야 멈출 수 있습니다";
        text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Arrow3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Arrow3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Arrow3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Arrow3.SetActive(false);
        yield return new WaitForSeconds(1);
        text.enabled = false;
        yield return new WaitForSeconds(1);
        text.text = "한번 해봅시다!!";
        text.enabled = true;
        Right.enabled = true;
        while (!nice)
            yield return new WaitForSeconds(0.1f);
        text.text = "잘하셨습니다";
        text.enabled = true;
        Right.enabled = false;
        nice = false;
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
        if (success)
        {
            text.text = "처음인데도 잘 하시네요!!";
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
            text.text = "이제 정말로 뽑기를 하러 가볼까요??";
            text.enabled = true;
            yield return new WaitForSeconds(0.5f);
            NextGoBut.SetActive(true);
            while (!GoNext)
            {
                yield return new WaitForSeconds(0.5f);
            }
            GoNext = false;
            NextGoBut.SetActive(false);
            tutorial = false;
            PlayerPrefs.SetInt("PickFirst", 1);
            text.enabled = false;
        }
        else
        {
            text.text = "아 너무 아쉽네요!!ㅠㅠ";
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
            text.text = "방금 실수했으니 실전에선 실수하지 않겠죠??";
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
            text.text = "이제 정말로 뽑기를 하러 가볼까요??";
            text.enabled = true;
            yield return new WaitForSeconds(0.5f);
            NextGoBut.SetActive(true);
            while (!GoNext)
            {
                yield return new WaitForSeconds(0.5f);
            }
            GoNext = false;
            NextGoBut.SetActive(false);
            tutorial = false;
            PlayerPrefs.SetInt("PickFirst", 1);
            text.enabled = false;
        }
        SceneManager.LoadScene(2);
    }

    public void NextButton()
    {
        GoNext = true;
    }

}