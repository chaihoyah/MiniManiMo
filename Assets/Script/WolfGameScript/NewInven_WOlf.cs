using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInven_WOlf : MonoBehaviour
{

    public GameObject[] FoxOB = new GameObject[2];
    public Image[] Pan1 = new Image[2];
    public int[] isPan1 = new int[2];
    public Image[] Pan2 = new Image[6];
    public bool[] isPan2 = new bool[5];
    public Button[] Buttons = new Button[2];
    public Image[] CheckBox = new Image[2];
    Vector3 StartPosOne, StartPosTwo, MovePos, StartScale, MoveScale;
    bool isBig;


    void WeaponChk()
    {
        if (PlayerPrefs.GetInt("WolfWeapon1").Equals(1))
        {
            isPan1[0] = 1;

        }
        else if (PlayerPrefs.GetInt("WolfWeaPon1").Equals(2))
        {
            isPan1[0] = 2;

        }
        else
        {
            isPan1[0] = 0;
        }

        if (PlayerPrefs.GetInt("WolfWeapon2").Equals(1))
        {
            isPan1[1] = 1;
        }
        else if (PlayerPrefs.GetInt("WolfWeaPon2").Equals(2))
        {
            isPan1[1] = 2;
        }
        else
        {
            isPan1[1] = 0;
        }
        StartCoroutine(Pan_Two_FadeOut());
    }

    private void OnEnable()
    {
        isBig = false;
        MoveScale = new Vector3(4.715249f, 61.39252f, 4.715249f);
        MovePos = new Vector3(15, -147, 0);
        StartPosOne = new Vector3(0,0,0);
        StartPosTwo = new Vector3(182,0,0);
        Pan1[0].transform.localPosition = StartPosOne;
        Pan1[1].transform.localPosition = StartPosTwo;
        FoxOB[1].SetActive(false);
        FoxOB[0].SetActive(true);
        Buttons[0].gameObject.SetActive(true);
        Buttons[1].gameObject.SetActive(false);
        EnableCh();
    }

    void EnableCh()
    {
        PlayerPrefs.SetInt("WolfWeapon1", 1);
        PlayerPrefs.SetInt("WolfWeapon2", 2);
        if (PlayerPrefs.GetInt("WolfWeapon1").Equals(1))
        {
            Pan1[0].gameObject.SetActive(true);
            CheckBox[0].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("WolfWeaPon1").Equals(2))
        {
            Pan1[0].gameObject.SetActive(true);
            CheckBox[0].gameObject.SetActive(true);
        }
        else
        {
            Pan1[0].gameObject.SetActive(false);
            CheckBox[1].gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("WolfWeapon2").Equals(1))
        {
            Pan1[1].gameObject.SetActive(true);
            CheckBox[1].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("WolfWeapon2").Equals(2))
        {
            Pan1[1].gameObject.SetActive(true);
            CheckBox[1].gameObject.SetActive(true);
        }
        else
        {
            Pan1[1].gameObject.SetActive(false);
            CheckBox[1].gameObject.SetActive(false);
        }
        //1이면 카드 셋액티브 2면 체크박스 액티브 알파 1 0이면 없기 알파 0 
    }

    void UpgradeChk()
    {
        if (PlayerPrefs.GetInt("WolfHp3Upgrade").Equals(1))
        {
            for (int i = 0; i < 3; i++)
            {
                isPan2[i] = true;
            }
        }
        else if (PlayerPrefs.GetInt("WolfHp2Upgrade").Equals(1))
        {
            for (int i = 0; i < 2; i++)
            {
                isPan2[i] = true;
            }
            isPan2[2] = false;
        }
        else if (PlayerPrefs.GetInt("WolfHp1Upgrade").Equals(1))
        {
            isPan2[0] = true;
            for (int i = 1; i < 3; i++)
            {
                isPan2[i] = false;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                isPan2[i] = false;
            }
        }

        if (PlayerPrefs.GetInt("WolfSpeed2").Equals(1))
        {
            isPan2[3] = true;
            isPan2[4] = true;
        }

        else if (PlayerPrefs.GetInt("WolfSpeed1").Equals(1))
        {
            isPan2[3] = true;
            isPan2[4] = false;
        }

        else
        {
            isPan2[3] = false;
            isPan2[4] = false;
        }

        StartCoroutine(Pan_One_FadeOut());
    }

    IEnumerator Pan_One_FadeOut()
    {
        int i = 0;
        while (i < 20)
        {
            Pan1[0].color -= new Color(0, 0, 0, 0.05f);
            Pan1[1].color -= new Color(0, 0, 0, 0.05f);
            CheckBox[0].color -= new Color(0, 0, 0, 0.05f);
            CheckBox[1].color -= new Color(0, 0, 0, 0.05f);
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        for (int j = 0; j < 2; j++)
        {
            Pan1[j].gameObject.SetActive(false);
            CheckBox[j].gameObject.SetActive(false);
        }
        StartCoroutine(Pan_Two_FadeIn());
    }

    IEnumerator Pan_Two_FadeOut()
    {
        int i = 0;
        while (i < 20)
        {
            Pan2[0].color -= new Color(0, 0, 0, 0.05f);
            Pan2[1].color -= new Color(0, 0, 0, 0.05f);
            Pan2[2].color -= new Color(0, 0, 0, 0.05f);
            Pan2[3].color -= new Color(0, 0, 0, 0.05f);
            Pan2[4].color -= new Color(0, 0, 0, 0.05f);
            Pan2[5].color -= new Color(0, 0, 0, 0.05f);

            i++;
            yield return new WaitForSeconds(0.1f);
        }
        for (int j = 0; j < 6; j++)
        {
            Pan2[j].gameObject.SetActive(false);
        }
        StartCoroutine(Pan_One_FadeIn());
    }

    IEnumerator Pan_Two_FadeIn()
    {
        int i = 0;
        for (int j = 0; j < 5; j++)
        {
            if (isPan2[j])
                Pan2[j].gameObject.SetActive(true);
        }
        while (i < 20)
        {
            Pan2[0].color += new Color(0, 0, 0, 0.05f);
            Pan2[1].color += new Color(0, 0, 0, 0.05f);
            Pan2[2].color += new Color(0, 0, 0, 0.05f);
            Pan2[3].color += new Color(0, 0, 0, 0.05f);
            Pan2[4].color += new Color(0, 0, 0, 0.05f);
            Pan2[5].color += new Color(0, 0, 0, 0.05f);
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Pan_One_FadeIn()
    {
        int i = 0;
        for (int j = 0; j < 2; j++)
        {
            if (isPan1[j].Equals(1))
                Pan1[j].gameObject.SetActive(true);
            else if (isPan1[j].Equals(2))
            {
                Pan1[j].gameObject.SetActive(true);
                CheckBox[j].gameObject.SetActive(true);
            }
        }
        while (i < 20)
        {

            Pan1[0].color += new Color(0, 0, 0, 0.05f);
            Pan1[1].color += new Color(0, 0, 0, 0.05f);
            CheckBox[0].color += new Color(0, 0, 0, 0.05f);
            CheckBox[1].color += new Color(0, 0, 0, 0.05f);
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForEndOfFrame();
    }

    public void SwapOne()
    {
        FoxOB[0].SetActive(false);
        FoxOB[1].SetActive(true);
        Buttons[1].gameObject.SetActive(true);
        Buttons[0].gameObject.SetActive(false);
        UpgradeChk();
    }

    public void SwapTwo()
    {
        FoxOB[1].SetActive(false);
        FoxOB[0].SetActive(true);
        Buttons[0].gameObject.SetActive(true);
        Buttons[1].gameObject.SetActive(false);
        WeaponChk();
    }

    public void ChangeWeaponToOne()
    {
        PlayerPrefs.SetInt("WolfWeapon1", 2);
        CheckBox[0].gameObject.SetActive(false);
        CheckBox[1].gameObject.SetActive(false);
        isPan1[0] = 2;
        if (PlayerPrefs.GetInt("WolfWeapon2").Equals(2))
        {
            PlayerPrefs.SetInt("WolfWeapon2", 1);
            isPan1[1] = 1;
        }
        if (!isBig)
        {
            Pan1[0].transform.SetAsLastSibling();
            StartScale = Pan1[0].transform.localScale;
            StartPosOne = Pan1[0].transform.localPosition;
            Pan1[0].transform.localScale = MoveScale;
            Pan1[0].transform.localPosition = MovePos;
            isBig = true;
        }
        else
        {
            Pan1[0].transform.localScale = StartScale;
            Pan1[0].transform.localPosition = StartPosOne;
            isBig = false;
            CheckBox[0].gameObject.SetActive(true);
            CheckBox[1].gameObject.SetActive(false);
        }
    }

    public void ChangeWeaponToTwo()
    {
        PlayerPrefs.SetInt("WolfWeapon2", 2);
        CheckBox[0].gameObject.SetActive(false);
        CheckBox[1].gameObject.SetActive(false);
        isPan1[1] = 2;
        if (PlayerPrefs.GetInt("WolfWeapon1").Equals(2))
        {
            PlayerPrefs.SetInt("WolfWeapon1", 1);
            isPan1[0] = 1;
        }
        if (!isBig)
        {
            Pan1[1].transform.SetAsLastSibling();
            StartScale = Pan1[1].transform.localScale;
            StartPosTwo = Pan1[1].transform.localPosition;
            Pan1[1].transform.localScale = MoveScale;
            Pan1[1].transform.localPosition = MovePos;
            isBig = true;
        }
        else
        {
            Pan1[1].transform.localScale = StartScale;
            Pan1[1].transform.localPosition = StartPosTwo;
            isBig = false;
            CheckBox[0].gameObject.SetActive(false);
            CheckBox[1].gameObject.SetActive(true);
        }
    }

}
