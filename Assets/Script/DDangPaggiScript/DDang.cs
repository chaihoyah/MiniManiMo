using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DDang : MonoBehaviour
{
    public static GameObject Panda;
    public Material BackMate;
    public bool isShoes;
    public bool isShoePanOn;
    public bool isPetOne;
    public bool isPetTwo;
    public Button Left;
    public Button Right;
    public Button ShoeRight;
    public Button ShoeLeft;

    public GameObject PetOne;
    public GameObject PetTwo;
    public GameObject Pan;
    public GameObject UpPan;
    public GameObject GanziPan;
    public GameObject UpOnePan;
    public GameObject UpTwoPan;

    // Use this for initialization

    void Awake()
    {


    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        isPetOne = false;
        isPetTwo = false;
        isShoes = false;
        isShoePanOn = false;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (PlayerPrefs.GetInt("SwimUpgrade").Equals(1)) isShoes = true;
        if (PlayerPrefs.GetInt("SwimPet1").Equals(1)) isPetOne = true;
        if (PlayerPrefs.GetInt("SwimPet2").Equals(1)) isPetTwo = true;
        if (PlayerPrefs.GetInt("SwimShoes1").Equals(1)) isShoePanOn = true;
        Color color = new Color(0, (float)120 / 255, 1f, 1f);

        if (PlayerPrefs.GetInt("SwimShoes1").Equals(2))
        {
            Pan.SetActive(false);
            GanziPan.SetActive(true);

        }

        else if (PlayerPrefs.GetInt("SwimShoes2").Equals(2))
        {
            Pan.SetActive(false);
            UpOnePan.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("SwimShoes3").Equals(2))
        {
            Pan.SetActive(false);
            UpTwoPan.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("SwimUpgrade").Equals(1))
        {
            Pan.SetActive(false);
            UpPan.SetActive(true);

        }
        else
        {
            Pan.SetActive(true);

        }
        PetOne.SetActive(false);
        PetTwo.SetActive(false);
        BackMate.color = color;
        ShoeChecker();
        StartCoroutine(ColChange());
        
    }
    IEnumerator ColChange()
    {
        while (true)
        {
            BackMate.color -= new Color(0, 0.00001f, 0.00002f, 0);
            yield return new WaitForSeconds(0.25f);
        }
    }

    void ShoeChecker()
    {
        if(isPetOne)
        {
            PetOne.SetActive(true);
        }
        if(isPetTwo)
        {
            PetTwo.SetActive(true);
        }
        ShoeLeft.gameObject.SetActive(false);
        ShoeRight.gameObject.SetActive(false);
        Left.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        if (isShoes)
        {
            ShoeLeft.gameObject.SetActive(true);
            ShoeRight.gameObject.SetActive(true);
        }
        else
        {
            Left.gameObject.SetActive(true);
            Right.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
}
