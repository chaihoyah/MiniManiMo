using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewJam_Tuto : MonoBehaviour {

    public Text TutoText;
    public bool[] TutoBool = new bool[2];
    public GameObject Player;
    public GameObject Shark_Two;
    public GameObject Jelly_Two;
    public GameObject Pool;
    public static bool isPanTuto = true;
    public GameObject[] Image = new GameObject[2];
    public GameObject Gauge;
    public VisionMove_Button VB;
    public GameObject TutBack;
    bool GoNext;
    public GameObject NextGoBut;

    // Use this for initialization
    private void Awake()
    {
        if (PlayerPrefs.GetInt("isNewJamTuto").Equals(0)) isPanTuto = true;
        else isPanTuto = false;

        if (isPanTuto) Pool.SetActive(false);
    }
    IEnumerator Start()
    {
        Player = VisionMove_Button.Player;
        yield return new WaitForEndOfFrame();
        if (isPanTuto)
        {
            NextGoBut.SetActive(false);
            GoNext = false;
            TutBack.SetActive(true);
            yield return new WaitForSeconds(1f);
            StartCoroutine(Tuto());
        }
    }

    IEnumerator Tuto()
    {
        TutoText.text = "잠수게임 Upgrade~에 오신걸 환영합니다~";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "Upgrade 버전도 팬더를 요리조리 움직여 몬스터들을 피하는 게임이에요";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "그럼 본격적으로 시작해 볼까요~?";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "조이스틱을 이용해 팬더를 이동할수 있습니다!";
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[0].SetActive(false);
        TutoText.text = "그럼 팬더를 한번 이동해 볼까요??";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "팬더를 이동시켜 보세요!";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        yield return new WaitForSeconds(2f);
        TutoText.text = "잘하셨습니다!";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "이번엔 팬더를 이동하며 다가오는 해산물들을 피해보세요~!";
        StartCoroutine(MonsUp());
        //yield return new WaitForSeconds(1f);
        //TutoText.text = "잘하셨습니다!";

    }

    IEnumerator MonsUp()
    {
        Shark_Two.transform.position = new Vector3(-121.4f, 5, -44.5f);
        Jelly_Two.transform.position = new Vector3(181.7f, -6.449f, -61.2f);
        yield return new WaitForSeconds(1f);

        float dX = Player.transform.position.x - Shark_Two.transform.position.x;
        float dY = Player.transform.position.z - Shark_Two.transform.position.z;
        float angle = Mathf.Atan2(dX, dY);
        Shark_Two.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI)-90, 0);

        dX = Player.transform.position.x - Jelly_Two.transform.position.x;
        dY = Player.transform.position.z - Jelly_Two.transform.position.z;
        angle = Mathf.Atan2(dX, dY);
        Jelly_Two.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);

        while (Shark_Two.transform.position.x <= 140)
        {
            Shark_Two.gameObject.transform.Translate(0.8f, 0, 0);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2f);
        while (Jelly_Two.transform.position.x >= -140)
        {
            Jelly_Two.gameObject.transform.Translate(0, 0, 0.8f);
            yield return new WaitForEndOfFrame();
        }

        TutoText.text = "잘하셨습니다!";
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
        TutoText.text = "위험한 순간에 순간이동 버튼을 통해 빠져나갈 수 있습니다!";
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(false);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Image[1].SetActive(false);
        yield return new WaitForSeconds(1f);
        TutoText.text = "순간이동 버튼을 누르고 있으면 팬더가 이동할 위치가 보입니다!";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);

        TutoText.text = "손을 떼는 순간 팬더가 게이지 만큼 순간이동 합니다!";
        yield return new WaitForSeconds(1f);
        Gauge.transform.localScale = new Vector3(1, 0, 1);
        Player.transform.Translate(0, -9, 0);
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        TutoText.text = "그럼 한번 해볼까요?";
        while(!VB.press)
        {
            yield return new WaitForEndOfFrame();
        }
        while(VB.press)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        TutoText.text = "그럼 잠수 Upgrade~ 게임을 즐기러 가볼까요~?";
        NextGoBut.SetActive(true);
        while (!GoNext)
        {
            yield return new WaitForSeconds(0.5f);
        }
        GoNext = false;
        NextGoBut.SetActive(false);
        PlayerPrefs.SetInt("isNewJamTuto", 1);
        isPanTuto = false;
        SceneManager.LoadScene(9);
        yield return new WaitForEndOfFrame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("goldWolf"))
        {
            TutoText.text = "팬더를 움직여 몬스터를 피해보세요!";
            Shark_Two.transform.position = new Vector3(-121.4f, 5, -44.5f);
            Jelly_Two.transform.position = new Vector3(181.7f, -6.449f, -61.2f);
            TutoBool[1] = true;
        }
    }

    public void NextButton()
    {
        GoNext = true;
    }
}
