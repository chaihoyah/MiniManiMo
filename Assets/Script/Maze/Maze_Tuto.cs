using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Maze_Tuto : MonoBehaviour {

    public Text TutoText;
    public bool[] TutoBool = new bool[2];
    public GameObject Player;
    public GameObject[] Image = new GameObject[4];
    bool finish;
    public GameObject TutBack;
    bool GoNext;
    public GameObject NextGoBut;

    // Use this for initialization

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (StageScript.Round==0)
        {

            TutBack.SetActive(true);
            NextGoBut.SetActive(false);
            yield return new WaitForSeconds(1f);
            StartCoroutine(Tuto());
        }
    }

    IEnumerator Tuto()
    {
        TutoText.text = "미로 게임에 오신걸 환영합니다~";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "팬더를 움직여 시간내에 나가는 곳을 찾아야 합니다!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "남은 시간은 위쪽 타이머를 통해 알 수 있어요!";
        yield return new WaitForSeconds(1f);
        Image[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[3].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[3].SetActive(false);
        TutoText.text = "그럼 본격적으로 시작해 볼까요~?";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "이 버튼을 누르면 팬더가 앞으로 이동합니다";
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        TutoText.text = "그럼 팬더를 한번 이동해 볼까요??";
        yield return new WaitForSeconds(1f);
        TutoText.text = "팬더를 이동시켜 보세요!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        yield return new WaitForSeconds(1f);
        TutoText.text = "잘하셨습니다!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "이 버튼들을 통해 팬더를 왼쪽, 오른쪽으로 방향전환 할 수 있어요~";
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(true);
        Image[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(false);
        Image[2].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(true);
        Image[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(false);
        Image[2].SetActive(false);
        yield return new WaitForSeconds(1f);
        TutoText.text = "미로 곳곳에 숨어있는 보물상자를 통해 시간 연장 및 단축, 팬더 이동속도의 일시적 증가 및 감소를 획들할 수 있습니다~";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "또한, 중간중간 팬더가 화살표를 남겨 지나온 방향을 알 수 있습니다!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "그럼 팬더를 움직여 끝지점으로 이동해 봅시다~";
        while(!finish)
        {
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(1f);
        TutoText.text = "수고하셨습니다!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "그럼 본격적으로 미로게임을 즐기러 가볼까요~?";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        StageScript.Round++;
        PlayerPrefs.SetInt("Mazeround", StageScript.Round);
        SceneManager.LoadScene(6);
        //yield return new WaitForSeconds(1f);
        //TutoText.text = "잘하셨습니다!";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Finish"))
        {
            finish = true;
        }
    }

    public void NextButton()
    {
        GoNext = true;
    }
}
