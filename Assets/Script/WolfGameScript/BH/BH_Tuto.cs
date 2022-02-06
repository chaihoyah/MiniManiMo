using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BH_Tuto : MonoBehaviour {

    public Text TutoText;
    public GameObject TutBack;
    public bool[] TutoBool = new bool[2];
    public GameObject Player;
    public GameObject WolfOne;
    public GameObject WolfTwo;
    public GameObject GolWolf;
    public static bool isPanTuto = false;
    public GameObject[] Button = new GameObject[4];
    public GameObject[] Image = new GameObject[3];
    public BHTreasureRes TreasureRes;
    public GameObject Pool;
    bool GoNext;
    public GameObject NextGoBut;

    // Use this for initialization
    private void Awake()
    {
        if (PlayerPrefs.GetInt("isWolfTuto").Equals(0)) isPanTuto = true;
        else isPanTuto = false;
    }
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (isPanTuto)
        {
            GoNext = false;
            NextGoBut.SetActive(false);
            TutBack.SetActive(true);
            Pool.GetComponent<WolfRespawn>().enabled = false;
            Pool.GetComponent<GoldWolfRespawn>().enabled = false;
            yield return new WaitForSeconds(1f);
            StartCoroutine(Tuto());
        }
    }

    IEnumerator Tuto()
    {
        TutoText.text = "눈싸움에 오신걸 환영합니다~";
        
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while(!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "눈싸움은 꼬꼬를 요리조리 움직이며 늑대들에게 눈을 던져 내쫓는 게임이에요";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "그럼 본격적으로 시작해 볼까요~?";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "조이스틱을 이용해 꼬꼬를 이동 시킬 수 있습니다";
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "그럼 꼬꼬를 한번 이동해 볼까요??";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "꼬꼬를 이동시켜 보세요!";
        while (!TutoBool[0])
        {
            yield return new WaitForSeconds(0.5f);
        }
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
        TutoText.text = "오른쪽 버튼을 통해 눈을 던질 수 있습니다";
        yield return new WaitForSeconds(2f);
        Image[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(false);
        TutoText.text = "그럼 눈을 던져 볼까요~?";
        while (!TutoBool[1])
        {
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);
        TutoText.text = "그럼 이제 눈을 던져 쫓아오는 늑대들을 내쫓아 볼까요~?";
        yield return new WaitForSeconds(2f);
        NextGoBut.SetActive(true);
        TutBack.SetActive(false);
        WolfOne.SetActive(true);
        while (WolfOne.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.5f);
        }

        WolfTwo.SetActive(true);
        while (WolfTwo.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);
        TutBack.SetActive(true);
        TutoText.text = "황금 늑대는 더 빠르고 쎄지만, 더 좋은 보상을 줍니다!";
        yield return new WaitForSeconds(1.5f);
        TutBack.SetActive(false);
        GolWolf.SetActive(true);
        while (GolWolf.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);
        TutBack.SetActive(true);
        TutoText.text = "20초에 한 번씩 여러 종류의 아이템들을 제공하니 아이템들을 잘 활용해 오래 살아남아 봅시다!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TreasureRes.TreasureItemRes();
        Image[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[2].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[2].SetActive(false);
        yield return new WaitForSeconds(2f);
        TutoText.text = "그럼 눈싸움을 본격적으로 즐기러 가볼까요~??";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        PlayerPrefs.SetInt("isWolfTuto", 1);
        isPanTuto = false;
        SceneManager.LoadScene(7);
    }

    public void NextButton()
    {
        GoNext = true;
    }
}
