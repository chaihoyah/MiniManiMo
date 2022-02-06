using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DDRTutorial : MonoBehaviour
{

    public static bool tutorial;
    public static bool nice = true;
    public Text text;
    Wall wall;
    DDArrowRes DAR;
    bool GoNext;
    public GameObject NextGoBut;
    // Use this for initialization
    void Awake()
    {
        if (PlayerPrefs.GetInt("isDDRTuto").Equals(0))
        {
            tutorial = true;
            StartCoroutine(Tutorial());
        }
        else tutorial = false;
        wall = GameObject.Find("WallPool").transform.GetComponent<Wall>();
        DAR = GameObject.Find("Map-DDR").transform.GetComponent<DDArrowRes>();
    }

    IEnumerator Tutorial()
    {
        GoNext = false;
        NextGoBut.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        text.text = "이것은 DDR 튜토리얼입니다";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        text.enabled = false;
        text.text = "DDR게임은 다가오는 피자를 피하면서 DDR을 깨는 게임입니다";
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
        text.text = "우선 다가오는 피자를 아래의 방향키로 피해봅시다!";
        text.enabled = true;
        yield return new WaitForSeconds(1);
        StartCoroutine(PopObject());//피자 피하기
    }

    IEnumerator PopObject()
    {
        text.enabled = false;
        wall.Tutorial();
        yield return new WaitForSeconds(3);
        if (!nice)
        {
            text.text = "다시 한번 해봅시다";
            text.enabled = true;
            yield return new WaitForSeconds(2);
            nice = true;
            StartCoroutine(PopObject());
        }
        else
        {
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
            text.text = "이번에는 왼쪽 통에 생기는 DDR의 방향에 맞는 방향키를 눌러 없애봅시다";
            text.enabled = true;
            nice = false;
            yield return new WaitForSeconds(2);
            text.enabled = false;
            yield return new WaitForSeconds(1);
            DAR.Tutorial();
            while (!nice)
            {
                yield return new WaitForSeconds(0.1f);
            }
            text.text = "잘하셨습니다";
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
            text.text = "DDR이 가득 차게 되면 죽게되니 조심하세요!!";
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
            text.text = "이제 게임을 하러 가볼까요??";
            text.enabled = true;
            yield return new WaitForSeconds(0.5f);
            NextGoBut.SetActive(true);
            while (!GoNext)
            {
                yield return new WaitForSeconds(0.5f);
            }
            GoNext = false;
            NextGoBut.SetActive(false);
            PlayerPrefs.SetInt("isDDRTuto", 1);
            tutorial = false;
            SceneManager.LoadScene(3);
        }
    }

    public void NextButton()
    {
        GoNext = true;
    }

}