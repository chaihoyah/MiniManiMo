using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour
{

    // Use this for initialization
    private Button startButton;
    public Button PushButton;

    public Button stop;
    public GameObject MoreMPanel;
    public GameObject Shinee;
    public GameObject Shineee;
    public GameObject Money;
    public GameObject DonNut;
    public GameObject StartBut;
    public GameObject PressBut;
    public SoundManager SM;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        PushButton.enabled = false;
        Time.timeScale = 0.9f;
        stop.enabled = false;
        StartCoroutine(ShiningStar());
    }

    public void Press()
    {
        if (GlobalPoint.ChongPoint >= 1000 || PlayerPrefs.GetInt("PickFirst").Equals(0))
        {
            StartCoroutine(MoneyGo());
            this.GetComponent<Button>().enabled = false;
        }
        else StartCoroutine(NeedMore());
    }

    IEnumerator MoneyGo()
    {
        SM.PlayPickMoneyInsert();
        Money.SetActive(true);
        while (Money.transform.localPosition.y <= (-290))
        {
            Money.transform.Translate(0, 1.7f, 0);
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 1;
        if (!PickGameTutorial.tutorial)
            GlobalPoint.ChongPoint -= 1000;
        PlayerPrefs.SetInt("silver", GlobalPoint.ChongPoint);
        DonNut.SetActive(false);
        PressBut.SetActive(true);
        StartBut.SetActive(false);
        PickGameTutorial.nice = true;
        yield return null;
    }

    IEnumerator NeedMore()
    {
        MoreMPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        MoreMPanel.SetActive(false);
    }

    IEnumerator ShiningStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Shinee.SetActive(true);
            Shineee.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Shinee.SetActive(false);
            Shineee.SetActive(false);
        }
    }


}