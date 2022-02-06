using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JamSoo_Tutorial : MonoBehaviour {

    public Text TutoText;
    public bool[] TutoBool = new bool[10];
    public GameObject Player;
    public GameObject Shark_One;
    public GameObject Shark_Two;
    public GameObject Jelly_One;
    public GameObject Jelly_Two;
    public GameObject Air;
    public static bool isPanTuto= true;
    public GameObject[] Button = new GameObject[4];
    public GameObject[] Image = new GameObject[4];
    public GameObject[] Pandas = new GameObject[5];
    public GameObject TutBack;
    bool GoNext;
    public GameObject NextGoBut;
    // Use this for initialization

    private void Awake()
    {
        if (PlayerPrefs.GetInt("isJamTuto").Equals(0))
        {
            isPanTuto = true;
        }
        else isPanTuto = false;
    }

    IEnumerator Start () {
        Shark_Two = Instantiate(Shark_One) as GameObject;
        Jelly_Two = Instantiate(Jelly_One) as GameObject;
        for(int i=0;i<10;i++)
        {
            TutoBool[i] = false;
        }
        yield return new WaitForEndOfFrame();
        if (isPanTuto)
        {

            yield return new WaitForSeconds(1f);
            Pandas[0].SetActive(true);
            Pandas[1].SetActive(false);
            Pandas[2].SetActive(false);
            Pandas[3].SetActive(false);
            Pandas[4].SetActive(false);
            Button[0].GetComponent<Button>().enabled = false;
            Button[1].GetComponent<Button>().enabled = false;
            Button[2].SetActive(false);
            Button[3].SetActive(false);
            TutBack.SetActive(true);
            NextGoBut.SetActive(false);
            StartCoroutine(Tuto());
        }
	}

    IEnumerator Tuto()
    {
        TutoText.text = "잠수게임에 오신걸 환영합니다~";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "잠수게임은 팬더를 요리조리 움직여 몬스터들을 피하는 게임이에요";
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
        TutoText.text = "팬더 방향키를 이용해 팬더를 왼쪽, 오른쪽으로 이동할수 있습니다";
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        Image[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        Image[1].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        Image[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        Image[1].SetActive(false);
        TutoText.text = "그럼 팬더를 한번 이동해 볼까요??";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "팬더를 이동시켜 보세요!";
        Button[0].GetComponent<Button>().enabled = true;
        Button[1].GetComponent<Button>().enabled = true;
        while (!TutoBool[0] | !TutoBool[1])
        {
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2f);
        TutoText.text = "잘하셨습니다!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "이번엔 팬더를 이동하며 올라오는 해산물들을 피해보세요~!";
        yield return new WaitForSeconds(1f);
        TutBack.SetActive(false);
        StartCoroutine(MonsUp());


    }

    IEnumerator MonsUp()
    {
        Shark_Two.transform.position = new Vector3(0.635f, -5f, 0);
        Jelly_Two.transform.position = new Vector3(0.835f, -5f, 0.744f);
        yield return new WaitForSeconds(2f);
        TutoText.enabled = false;
        while(Shark_Two.transform.position.y<=1.1)
        {
            Shark_Two.transform.position+= new Vector3(0,0.03f,0);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        while (Jelly_Two.transform.position.y <= 1.1)
        {
            Jelly_Two.transform.position += new Vector3(0, 0.03f, 0);
            yield return new WaitForEndOfFrame();
        }
        TutBack.SetActive(true);
        TutoText.enabled = true;
        TutoText.text = "잘하셨습니다!";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        StartCoroutine(AirGO());
    }

    IEnumerator AirGO()
    {
        TutoText.text = "팬더가 산소를 안먹으면 산소바가 줄어요!";
        yield return new WaitForSeconds(1f);
        Image[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[2].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[2].SetActive(false);
        yield return new WaitForSeconds(1f);
        TutoText.text = "중간중간 올라오는 이런 산소들을 먹어줘야 합니다!";
        Air.SetActive(true);
        yield return new WaitForSeconds(1f);
        TutBack.GetComponent<Image>().enabled = false;
        TutoText.enabled = false;
        Image[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[3].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[3].SetActive(false);
        yield return new WaitForSeconds(1f);
        TutBack.GetComponent<Image>().enabled = true;
        TutoText.enabled = true;
        TutoText.text = "그럼 잠수게임을 즐기러 가볼까요~?";
        yield return new WaitForSeconds(0.5f);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        JamSoo_Tutorial.isPanTuto = false;
        PlayerPrefs.SetInt("isJamTuto", 1);
        SceneManager.LoadScene(4);
        yield return new WaitForEndOfFrame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("goldWolf"))
        {
            Shark_Two.transform.position = new Vector3(0.635f, -5f, 0);
            Jelly_Two.transform.position = new Vector3(0.835f, -5f, 0.744f);
            TutoBool[2] = true;
        }
    }

    public void NextButton()
    {
        GoNext = true;
    }
}
