using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewShopScript : MonoBehaviour
{

    public GameObject container;
    public GameObject SnowShop_HP;//ShopComponent
    public GameObject SnowShop_Speed;
    public GameObject DDRShop_Pizza;
    public GameObject DDRShop_Pet;
    public GameObject JamsuShop_Shoes;
    public GameObject JamsuShop_Pet;
    public GameObject[] JamsuItem_Pet = new GameObject[2];
    public GameObject[] JamsuItem_Shoes = new GameObject[4];
    public GameObject[] SnowItem_HP = new GameObject[3];
    public GameObject[] SnowItem_Speed = new GameObject[2];
    public GameObject[] DDRItem_Pet = new GameObject[2];
    public GameObject[] DDRItem_Pizza = new GameObject[3];
    GameObject[] Items = new GameObject[16];
    public GameObject DDRShopBut;
    public GameObject SnowShopBut;
    public GameObject JamsuShopBut;
    public GameObject JamBack;
    public GameObject DDRBack;
    public GameObject SnowBack;
    public Image[] SidebuttonsImage = new Image[6];
    Color Use_Color, NotUse_Color = Color.white;
    public Button Left;
    public Button Right;
    private int page;
    public string[] InsString = new string[16];
    public Text text;
    GameObject Target;
    int TextNum = 0;

    Vector3 FirstSetting_Position = new Vector3(0, 0, 0);
    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < 16; i++)
        {
            if (i < 4)
                Items[i] = JamsuItem_Shoes[i];
            else if (i < 6)
                Items[i] = JamsuItem_Pet[i - 4];
            else if (i < 9)
                Items[i] = DDRItem_Pizza[i - 6];
            else if (i < 11)
                Items[i] = DDRItem_Pet[i - 9];
            else if (i < 14)
                Items[i] = SnowItem_HP[i - 11];
            else
                Items[i] = SnowItem_Speed[i - 14];
        }
        InsString[0] = "잠수게임 신발 업그레이드!";
        InsString[1] = "잠수게임 루돌프신발!";
        InsString[2] = "잠수게임 노랑 오리발!\n 스피드 증가!";
        InsString[3] = "잠수게임 에메랄드 물갈퀴!\n 스피드 대폭 증가!";
        InsString[4] = "잠수게임 펫!\n 팬더를 보호하는 착한 복어!";
        InsString[5] = "잠수게임 펫 복어 2!";
        InsString[6] = "피자게임 불고기 피자!\n 점수 증가!";
        InsString[7] = "피자게임 포테이토 피자!\n 실버 증가!";
        InsString[8] = "피자게임 쉬림프 피자!\n 골드 증가!";
        InsString[9] = "피자게임 펫!\n 동전을 대신 먹는 악마토끼!";
        InsString[10] = "피자게임 펫!\n DDR을 하나씩 없애주는 너굴이!";
        InsString[11] = "눈싸움 체력 총 100 증가!";
        InsString[12] = "눈싸움 체력 총 200 증가!";
        InsString[13] = "눈싸움 체력 총 300 증가!";
        InsString[14] = "눈싸움 스피드 업!";
        InsString[15] = "눈싸움 스피드 업업!";
        Use_Color = SidebuttonsImage[0].color;
        container = DDRShop_Pizza;
        page = 1;
        ItemSetting();
        Left.gameObject.SetActive(false);
        ChangeTo_Jamsu();
    }

    private void ItemSetting()
    {
        //DDR 아이템 세팅
        if (PlayerPrefs.GetInt("Pizza1").Equals(0)) Instantiate(DDRItem_Pizza[0], DDRShop_Pizza.transform);
        if (PlayerPrefs.GetInt("Pizza2").Equals(0)) Instantiate(DDRItem_Pizza[1], DDRShop_Pizza.transform);
        if (PlayerPrefs.GetInt("Pizza3").Equals(0)) Instantiate(DDRItem_Pizza[2], DDRShop_Pizza.transform);
        if (PlayerPrefs.GetInt("DdrPet2").Equals(0)) Instantiate(DDRItem_Pet[0], DDRShop_Pet.transform);
        if (PlayerPrefs.GetInt("DdrPet3").Equals(0)) Instantiate(DDRItem_Pet[1], DDRShop_Pet.transform);

        //잠수 아이템 세팅
        if (PlayerPrefs.GetInt("SwimUpgrade").Equals(0)) Instantiate(JamsuItem_Shoes[0], JamsuShop_Shoes.transform);
        if (PlayerPrefs.GetInt("SwimShoes1").Equals(0)) Instantiate(JamsuItem_Shoes[1], JamsuShop_Shoes.transform);
        if (PlayerPrefs.GetInt("SwimShoes2").Equals(0)) Instantiate(JamsuItem_Shoes[2], JamsuShop_Shoes.transform);
        if (PlayerPrefs.GetInt("SwimShoes3").Equals(0)) Instantiate(JamsuItem_Shoes[3], JamsuShop_Shoes.transform);
        if (PlayerPrefs.GetInt("SwimPet1").Equals(0)) Instantiate(JamsuItem_Pet[0], JamsuShop_Pet.transform);
        if (PlayerPrefs.GetInt("SwimPet2").Equals(0)) Instantiate(JamsuItem_Pet[1], JamsuShop_Pet.transform);

        //눈던지기 아이템 세팅
        if (PlayerPrefs.GetInt("WolfHp1Upgrade").Equals(0)) Instantiate(SnowItem_HP[0], SnowShop_HP.transform);
        if (PlayerPrefs.GetInt("WolfHp2Upgrade").Equals(0)) Instantiate(SnowItem_HP[1], SnowShop_HP.transform);
        if (PlayerPrefs.GetInt("WolfHp3Upgrade").Equals(0)) Instantiate(SnowItem_HP[2], SnowShop_HP.transform);
        if (PlayerPrefs.GetInt("WolfSpeed1").Equals(0)) Instantiate(SnowItem_Speed[0], SnowShop_Speed.transform);
        if (PlayerPrefs.GetInt("WolfSpeed2").Equals(0)) Instantiate(SnowItem_Speed[1], SnowShop_Speed.transform);

        for (int i = 0; i < JamsuShop_Shoes.transform.childCount; i++)
        {
            ItemSetting_Position(i, JamsuShop_Shoes);
        }

        for (int i = 0; i < DDRShop_Pizza.transform.childCount; i++)
        {
            ItemSetting_Position(i, DDRShop_Pizza);
        }

        for (int i = 0; i < SnowShop_Speed.transform.childCount; i++)
        {
            ItemSetting_Position(i, SnowShop_Speed);
        }

        for (int i = 0; i < JamsuShop_Pet.transform.childCount; i++)
        {
            ItemSetting_Position(i, JamsuShop_Pet);
        }

        for (int i = 0; i < DDRShop_Pet.transform.childCount; i++)
        {
            ItemSetting_Position(i, DDRShop_Pet);
        }

        for (int i = 0; i < SnowShop_HP.transform.childCount; i++)
        {
            ItemSetting_Position(i, SnowShop_HP);
        }
    }

    private void ItemSetting_Position(int num, GameObject parent)
    {
        if (parent.transform.GetChild(num) != null)
        {
            parent.transform.GetChild(num).transform.localPosition = new Vector3(1000 * num, 128, 0);
            parent.transform.GetChild(num).transform.localScale = new Vector3(8, 8, 8);
        }
    }

    private void NextObject()
    {
        page++;
        StartCoroutine(MoveSlide_Right());
    }

    private void PreviousObject()
    {
        page--;
        StartCoroutine(MoveSlide_Left());
    }

    public void RightButton()
    {
        int _page;
        _page = container.transform.GetChildCount();
        if (page.Equals(_page - 1))
        {
            NextObject();
            Right.gameObject.SetActive(false);
            Left.gameObject.SetActive(true);
        }
        else if (page.Equals(1))
        {
            NextObject();
            Left.gameObject.SetActive(true);
        }
        else NextObject();
        ItemText();
    }

    public void LeftButton()
    {
        int _page;
        _page = container.transform.GetChildCount();
        if (page.Equals(2))
        {
            PreviousObject();
            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(true);
        }
        else if (page.Equals(_page))
        {
            PreviousObject();
            Right.gameObject.SetActive(true);
        }
        else PreviousObject();
        ItemText();
    }

    public void ChangeTo_DDR()
    {
        JamBack.SetActive(false);
        DDRBack.SetActive(true);
        SnowBack.SetActive(false);
        DDRShop_Pizza.SetActive(true);
        SnowShop_HP.SetActive(false);
        JamsuShop_Shoes.SetActive(false);
        DDRShop_Pet.SetActive(false);
        SnowShop_Speed.SetActive(false);
        JamsuShop_Pet.SetActive(false);
        DDRShopBut.SetActive(true);
        SnowShopBut.SetActive(false);
        JamsuShopBut.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            SidebuttonsImage[i].color = NotUse_Color;
        }
        SidebuttonsImage[2].color = Use_Color;
        page = 1;
        container = DDRShop_Pizza;
        ItemText();
        ChangeSetting();
    }

    public void ChangeTo_Snow()
    {
        JamBack.SetActive(false);
        DDRBack.SetActive(false);
        SnowBack.SetActive(true);
        DDRShop_Pizza.SetActive(false);
        SnowShop_HP.SetActive(true);
        JamsuShop_Shoes.SetActive(false);
        DDRShop_Pet.SetActive(false);
        SnowShop_Speed.SetActive(false);
        JamsuShop_Pet.SetActive(false);
        DDRShopBut.SetActive(false);
        SnowShopBut.SetActive(true);
        JamsuShopBut.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            SidebuttonsImage[i].color = NotUse_Color;
        }
        SidebuttonsImage[4].color = Use_Color;
        page = 1;
        container = SnowShop_HP;
        ItemText();
        ChangeSetting();
    }

    public void ChangeTo_Jamsu()
    {
        JamBack.SetActive(true);
        DDRBack.SetActive(false);
        SnowBack.SetActive(false);
        DDRShop_Pizza.SetActive(false);
        SnowShop_HP.SetActive(false);
        JamsuShop_Shoes.SetActive(true);
        DDRShop_Pet.SetActive(false);
        SnowShop_Speed.SetActive(false);
        JamsuShop_Pet.SetActive(false);
        DDRShopBut.SetActive(false);
        SnowShopBut.SetActive(false);
        JamsuShopBut.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            SidebuttonsImage[i].color = NotUse_Color;
        }
        SidebuttonsImage[0].color = Use_Color;
        page = 1;
        container = JamsuShop_Shoes;
        ItemText();
        ChangeSetting();
    }

    public void ChangeTo_DDR_pet()
    {
        DDRShop_Pizza.SetActive(false);
        SnowShop_HP.SetActive(false);
        JamsuShop_Shoes.SetActive(false);
        DDRShop_Pet.SetActive(true);
        SnowShop_Speed.SetActive(false);
        JamsuShop_Pet.SetActive(false);
        DDRShopBut.SetActive(true);
        SnowShopBut.SetActive(false);
        JamsuShopBut.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            SidebuttonsImage[i].color = NotUse_Color;
        }
        SidebuttonsImage[3].color = Use_Color;
        page = 1;
        container = DDRShop_Pet;
        ItemText();
        ChangeSetting();
    }

    public void ChangeTo_Snow_speed()
    {
        DDRShop_Pizza.SetActive(false);
        SnowShop_HP.SetActive(false);
        JamsuShop_Shoes.SetActive(false);
        DDRShop_Pet.SetActive(false);
        SnowShop_Speed.SetActive(true);
        JamsuShop_Pet.SetActive(false);
        DDRShopBut.SetActive(false);
        SnowShopBut.SetActive(true);
        JamsuShopBut.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            SidebuttonsImage[i].color = NotUse_Color;
        }
        SidebuttonsImage[5].color = Use_Color;
        page = 1;
        container = SnowShop_Speed;
        ItemText();
        ChangeSetting();
    }

    public void ChangeTo_Jamsu_pet()
    {
        DDRShop_Pizza.SetActive(false);
        SnowShop_HP.SetActive(false);
        JamsuShop_Shoes.SetActive(false);
        DDRShop_Pet.SetActive(false);
        SnowShop_Speed.SetActive(false);
        JamsuShop_Pet.SetActive(true);
        DDRShopBut.SetActive(false);
        SnowShopBut.SetActive(false);
        JamsuShopBut.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            SidebuttonsImage[i].color = NotUse_Color;
        }
        SidebuttonsImage[1].color = Use_Color;
        page = 1;
        container = JamsuShop_Pet;
        ItemText();
        ChangeSetting();
    }

    public void BuyItem(GameObject item)
    {
        int count = container.transform.childCount;
        int num = 0;

        if(count > 1)
        {
            for (int i = 0; i < count; i++)
            {
                if (item.Equals(container.transform.GetChild(i)))
                {
                    num = i;
                    break;
                }
                else continue;
            }
            if (item.Equals(container.transform.GetChild(count - 1)))
            {
                page--;
                container.transform.localPosition += new Vector3(1000, 0, 0);
            }
        }

        ItemText();
        Item.shopBool = true;
        Invoke("ItemSetting_Container", 0.2f);
    }

    void ItemSetting_Container()
    {
        int count = container.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            ItemSetting_Position(i, container);
        }
    }

    IEnumerator MoveSlide_Right()
    {
        int count = 0;
        while (count < 40)
        {
            container.transform.localPosition -= new Vector3(25, 0, 0);
            count++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator MoveSlide_Left()
    {
        int count = 0;
        while (count < 40)
        {
            container.transform.localPosition += new Vector3(25, 0, 0);
            count++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void ChangeSetting()
    {
        DDRShop_Pizza.transform.localPosition = FirstSetting_Position;
        JamsuShop_Pet.transform.localPosition = FirstSetting_Position;
        SnowShop_HP.transform.localPosition = FirstSetting_Position;
        DDRShop_Pet.transform.localPosition = FirstSetting_Position;
        JamsuShop_Shoes.transform.localPosition = FirstSetting_Position;
        SnowShop_Speed.transform.localPosition = FirstSetting_Position;
        if (container.transform.childCount <= 1)
        {
            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
        }
        else
        {
            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(true);
        }
    }

    private void ItemText()
    {
        bool isTargetExist;
        if (container.transform.childCount > 0)
        {
            isTargetExist = true;
            for (int i = 0; i < 16; i++)
            {
                if (container.transform.childCount <= page-1)
                {

                }
                else if (container.transform.GetChild(page - 1).name.Equals(Items[i].name + "(Clone)"))
                {
                    TextNum = i;
                }
            }
        }
        else
            isTargetExist = false;

        if (!isTargetExist)
            text.text = "구매할 아이템이 없습니다!!ㅠㅠ";
        else
        {
            switch (TextNum)
            {
                case 0:
                    text.text = InsString[0];
                    break;
                case 1:
                    text.text = InsString[1];
                    break;
                case 2:
                    text.text = InsString[2];
                    break;
                case 3:
                    text.text = InsString[3];
                    break;
                case 4:
                    text.text = InsString[4];
                    break;
                case 5:
                    text.text = InsString[5];
                    break;
                case 6:
                    text.text = InsString[6];
                    break;
                case 7:
                    text.text = InsString[7];
                    break;
                case 8:
                    text.text = InsString[8];
                    break;
                case 9:
                    text.text = InsString[9];
                    break;
                case 10:
                    text.text = InsString[10];
                    break;
                case 11:
                    text.text = InsString[11];
                    break;
                case 12:
                    text.text = InsString[12];
                    break;
                case 13:
                    text.text = InsString[13];
                    break;
                case 14:
                    text.text = InsString[14];
                    break;
                case 15:
                    text.text = InsString[15];
                    break;
            }
        }
    }
}