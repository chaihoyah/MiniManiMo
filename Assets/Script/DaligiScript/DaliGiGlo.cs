using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DaliGiGlo : MonoBehaviour {
    public static float ResultPoint=0;
    public static float ResultTime=0;
    public static int Rundis = 0;
    public Image GoldImg;
    public GameObject Gold;
    public GameObject GoldTwo;
    public GameObject Player;
    public SoundManager SoundM;

    public GameObject Summer;
    public GameObject Winter;
    public int PlusGold;
    Vector3 NowPos;
    Vector3 Offset;
    bool isWinter;
    public GameObject Coincoco;
    public RunTutorial RT;
    // Use this for initialization
    private void Awake()
    {
        Offset = Winter.transform.position - Player.transform.position;
        Winter.SetActive(false);

    }
    IEnumerator Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Rundis = 0;
        PlusGold = 1;
        isWinter = false;
        GoldImg.fillAmount = 0;
        NowPos = Vector3.zero;
        NowPos = Player.transform.position;
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(RunDisCheck());
        StartCoroutine(MapChange());
	}

    IEnumerator RunDisCheck()
    {
        while(true)
        {
            if(Player.transform.position.x<=NowPos.x-10)
            {
                NowPos = Player.transform.position;
                GoldImg.fillAmount += 0.025f;
                Rundis++;
            }

            if(GoldImg.fillAmount>=0.995f)
            {
                GlobalPoint.GoldPoint += PlusGold;
                PlayerPrefs.SetInt("gold", GlobalPoint.GoldPoint);
                SoundM.PlayCoin();
                GoldImg.fillAmount = 0;
                if (isWinter)
                {
                    Coincoco.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    GoldTwo.SetActive(true);
                    
                    yield return new WaitForSeconds(0.5f);
                    GoldTwo.SetActive(false);
                }
                else
                {
                    if(RunTutorial.tutorial)
                    RT.finish();
                    Coincoco.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    Gold.SetActive(true);
                    yield return new WaitForSeconds(0.5f);

                    Gold.SetActive(false);
                }
                
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void GolOne()
    {

    }

    IEnumerator MapChange()
    {
        while(true)
        {
            if (Rundis > 300)
            {
                PlusGold = 3;
                Summer.SetActive(false);
                Winter.transform.position = Player.transform.position + Offset;
                Winter.SetActive(true);
                isWinter = true;
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


}
