using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour
{
    public Canvas BuyCanvas;
    public Canvas AlreadyCanvas;
    public Canvas NotReadyCanvas;
    public Canvas NotEnoughMoney;
    public Canvas GoldORSilver_Fire;
    public Canvas GoldORSilver_Ice;
    public Canvas GoldORSilver_Thunder;

    public GameObject[] PizzaIt = new GameObject[3];
    public GameObject[] DDRPetIt = new GameObject[2];
    public GameObject[] ShoeIt = new GameObject[3];
    public GameObject[] JamPetIt = new GameObject[2];
    public GameObject ShoeUpIt;
    //   public GameObject[] StoneIt = new GameObject[3];
    //  public GameObject SlingIt;
    public GameObject[] HPIt = new GameObject[3];
    public GameObject PotionIt;
    public GameObject[] WolfSpeedIt = new GameObject[2];
    public GameObject[] WolfWeaponIt = new GameObject[2];

    public Button[] Buttons = new Button[20];
    public Button[] ShopUIBut = new Button[12];

    public SoundManager SoundM;
    //public string[] InsString = new string[18];

    bool isGold;

    int ItemNumber = 0;

    int WolfPotion_Number;
    NewShopScript NS;
    public GameObject NSContainer;
    //******효괴
    public GameObject card;
    public GameObject CardWalletBack;
    public GameObject CardWalletFront;
    public GameObject cardout;
    public GameObject cardin;
    public static bool shopBool = false;

    void Start()
    {
        WolfPotion_Number = PlayerPrefs.GetInt("WolfPotion");
        NS = NSContainer.transform.GetComponent<NewShopScript>();
    }

    public void Buy_Pizza1()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("Pizza1") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 8000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 1;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_Pizza2()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("Pizza2") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 9000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 2;
            BuyCanvas.enabled = true;

        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }


    public void Buy_Pizza3()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("Pizza3") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 10000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 3;
            BuyCanvas.enabled = true;

        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_DDRPet1()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("DdrPet1") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("gold") < 400)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 4;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_DDRPet2()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("DdrPet2") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("gold") < 500)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 5;
            BuyCanvas.enabled = true;

        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_DDRPet3()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("DdrPet3") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("gold") < 450)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 6;
            BuyCanvas.enabled = true;

        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_SwimUpgrade()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("SwimUpgrade") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 5000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 7;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_SwimShoes1()
    {

        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("SwimShoes1") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("SwimUpgrade") == 0)
        {
            NotReadyCanvas.enabled = true;

        }
        else if (PlayerPrefs.GetInt("silver") < 5000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 8;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if(Buttons[i] != null)
            Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_SwimShoes2()
    {

        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("SwimShoes2") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("SwimUpgrade") == 0)
        {
            NotReadyCanvas.enabled = true;

        }
        else if (PlayerPrefs.GetInt("silver") < 8000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 9;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_SwimShoes3()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("SwimShoes3") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("SwimUpgrade") == 0)
        {
            NotReadyCanvas.enabled = true;

        }
        else if (PlayerPrefs.GetInt("silver") < 10000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 10;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_SwimPet1()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("SwimPet1") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("gold") < 400)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 11;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_SwimPet2()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("SwimPet2") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("SwimPet1") == 0)
        {
            NotReadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("gold") < 400)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 12;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_WolfHp1Upgrade()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("WolfHp1Upgrade") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 4000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 16;
            BuyCanvas.enabled = true;
        }

        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_WolfHp2Upgrade()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("WolfHp2Upgrade") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("WolfHp1Upgrade") == 0)
        {
            NotReadyCanvas.enabled = true;

        }
        else if (PlayerPrefs.GetInt("silver") < 5000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 17;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_WolfHp3Upgrade()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("WolfHp3Upgrade") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("WolfHp2Upgrade") == 0)
        {
            NotReadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 6000)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            ItemNumber = 18;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }
    public void Buy_WolfPotion()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("silver") < 700) StartCoroutine(NotEnough());
        else
        {
            ItemNumber = 20;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_WolfSpeed1()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("WolfSpeed1") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 1000) StartCoroutine(NotEnough());
        else
        {
            ItemNumber = 21;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_WolfSpeed2()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("WolfSpeed2") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 1000) StartCoroutine(NotEnough());
        else
        {
            ItemNumber = 22;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_WolfWeapon1()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("WolfWeapon1") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 1000) StartCoroutine(NotEnough());
        else
        {
            ItemNumber = 23;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void Buy_WolfWeapon2()
    {
        SoundM.PlayButton();
        if (PlayerPrefs.GetInt("WolfWeapon2") != 0)
        {
            AlreadyCanvas.enabled = true;
        }
        else if (PlayerPrefs.GetInt("silver") < 1000) StartCoroutine(NotEnough());
        else
        {
            ItemNumber = 24;
            BuyCanvas.enabled = true;
        }
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = false;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = false;
    }

    public void BuyingItem()
    {
        SoundM.PlayButton();
        int gold = PlayerPrefs.GetInt("gold");
        int silver = PlayerPrefs.GetInt("silver");
        switch (ItemNumber)
        {
            case 1: PlayerPrefs.SetInt("Pizza1", 1); GlobalPoint.ChongPoint -= 8000; PlayerPrefs.SetInt("silver", silver - 8000); break;
            case 2: PlayerPrefs.SetInt("Pizza2", 1); GlobalPoint.ChongPoint -= 9000; PlayerPrefs.SetInt("silver", silver - 9000); break;
            case 3: PlayerPrefs.SetInt("Pizza3", 1); GlobalPoint.ChongPoint -= 10000; PlayerPrefs.SetInt("silver", silver - 10000); break;
            case 4: PlayerPrefs.SetInt("DdrPet1", 1); GlobalPoint.GoldPoint -= 400; PlayerPrefs.SetInt("gold", gold - 400); break;
            case 5: PlayerPrefs.SetInt("DdrPet2", 1); GlobalPoint.GoldPoint -= 500; PlayerPrefs.SetInt("gold", gold - 500); break;
            case 6: PlayerPrefs.SetInt("DdrPet3", 1); GlobalPoint.GoldPoint -= 450; PlayerPrefs.SetInt("gold", gold - 450); break;
            case 7: PlayerPrefs.SetInt("SwimUpgrade", 1); GlobalPoint.ChongPoint -= 5000; PlayerPrefs.SetInt("silver", silver - 5000); break;
            case 8: PlayerPrefs.SetInt("SwimShoes1", 1); GlobalPoint.ChongPoint -= 5000; PlayerPrefs.SetInt("silver", silver - 5000); break;
            case 9: PlayerPrefs.SetInt("SwimShoes2", 1); GlobalPoint.ChongPoint -= 8000; PlayerPrefs.SetInt("silver", silver - 8000); break;
            case 10: PlayerPrefs.SetInt("SwimShoes3", 1); GlobalPoint.ChongPoint -= 10000; PlayerPrefs.SetInt("silver", silver - 10000); break;
            case 11: PlayerPrefs.SetInt("SwimPet1", 1); GlobalPoint.GoldPoint -= 400; PlayerPrefs.SetInt("gold", gold - 400); break;
            case 12: PlayerPrefs.SetInt("SwimPet2", 1); GlobalPoint.GoldPoint -= 500; PlayerPrefs.SetInt("gold", gold - 500); break;
            /**            case 13: PlayerPrefs.SetInt("WolfFire", 1); if (isGold) { PlayerPrefs.SetInt("gold", gold - 350); GlobalPoint.GoldPoint -= 350; } else { GlobalPoint.ChongPoint -= 20000; PlayerPrefs.SetInt("silver", silver - 20000); } StoneIt[1].transform.FindChild("Image").gameObject.SetActive(true); break;
                           case 14: PlayerPrefs.SetInt("WolfIce", 1); if (isGold) { GlobalPoint.GoldPoint -= 300; PlayerPrefs.SetInt("gold", gold - 300); } else { GlobalPoint.ChongPoint -= 15000; PlayerPrefs.SetInt("silver", silver - 15000); } StoneIt[0].transform.FindChild("Image").gameObject.SetActive(true); break;
                           case 15: PlayerPrefs.SetInt("WolfThunder", 1); if (isGold) { GlobalPoint.GoldPoint -= 350; PlayerPrefs.SetInt("gold", gold - 350); } else { GlobalPoint.ChongPoint -= 20000; PlayerPrefs.SetInt("silver", silver - 20000); } StoneIt[2].transform.FindChild("Image").gameObject.SetActive(true); break;**/
            case 16: PlayerPrefs.SetInt("WolfHp1Upgrade", 1); GlobalPoint.ChongPoint -= 4000; PlayerPrefs.SetInt("silver", silver - 4000); break;
            case 17: PlayerPrefs.SetInt("WolfHp2Upgrade", 1); GlobalPoint.ChongPoint -= 5000; PlayerPrefs.SetInt("silver", silver - 5000); break;
            case 18: PlayerPrefs.SetInt("WolfHp3Upgrade", 1); GlobalPoint.ChongPoint -= 6000; PlayerPrefs.SetInt("silver", silver - 6000); break;
            //         case 19: PlayerPrefs.SetInt("WolfBirdGun", 1); GlobalPoint.ChongPoint -= 10000; PlayerPrefs.SetInt("silver", silver - 10000); SlingIt.transform.FindChild("Image").gameObject.SetActive(true); break;
            case 20: PlayerPrefs.SetInt("WolfPotion", WolfPotion_Number + 1); WolfPotion_Number = PlayerPrefs.GetInt("WolfPotion"); GlobalPoint.ChongPoint -= 700; PlayerPrefs.SetInt("silver", silver - 700); NS.BuyItem(PotionIt); break;
            case 21: PlayerPrefs.SetInt("WolfSpeed1", 1); GlobalPoint.ChongPoint -= 1000; PlayerPrefs.SetInt("silver", silver - 1000); break;
            case 22: PlayerPrefs.SetInt("WolfSpeed2", 1); GlobalPoint.ChongPoint -= 1000; PlayerPrefs.SetInt("silver", silver - 1000); break;
            case 23: PlayerPrefs.SetInt("WolfWeapon1", 1); GlobalPoint.ChongPoint -= 5000; PlayerPrefs.SetInt("silver", silver - 5000); break;
            case 24: PlayerPrefs.SetInt("WolfWeapon2", 1); GlobalPoint.ChongPoint -= 5000; PlayerPrefs.SetInt("silver", silver - 5000); break;
        }
        BuyCanvas.enabled = false;
        GoldORSilver_Fire.enabled = false;
        GoldORSilver_Ice.enabled = false;
        GoldORSilver_Thunder.enabled = false;

        StartCoroutine(moveUp());
    }

    IEnumerator moveUp()
    {
        card.transform.parent = GameObject.Find("Shop 1").transform;
        card.transform.SetAsLastSibling();
        CardWalletFront.transform.SetAsLastSibling();
        card.transform.localPosition = CardWalletBack.transform.localPosition;


        while (cardout.transform.position.y > card.transform.position.y)
        {
            card.transform.position += new Vector3(0, 14.0f, 0);
            card.transform.Rotate(new Vector3(0, 1, 0), 10);
            yield return new WaitForEndOfFrame();
        }

        CardWalletBack.SetActive(true);
        CardWalletFront.SetActive(true);

        cardout.transform.localPosition = new Vector3(30, 1100, 0);

        card.transform.rotation = cardin.transform.rotation;
        card.transform.position = cardout.transform.position;

        /**while (image1.transform.localPosition.x > 0)
        {
            image1.transform.position -= new Vector3(8, 0, 0);
            image2.transform.position -= new Vector3(8, 0, 0);
            image3.transform.position -= new Vector3(8, 0, 0);
            image4.transform.position -= new Vector3(8, 0, 0);
            image5.transform.position -= new Vector3(8, 0, 0);
            yield return new WaitForSeconds(0.012f);
        }**/

        yield return new WaitForSeconds(0.5f);

        while (cardin.transform.position.y < card.transform.position.y)
        {
            card.transform.position -= new Vector3(0, 14.0f, 0);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f);
        NS.BuyItem(card);
        while (!shopBool)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(card.gameObject);
        CardWalletBack.SetActive(false);
        CardWalletFront.SetActive(false);
        shopBool = false;
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = true;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = true;
    }

    public void NotBuyingItem()
    {
        SoundM.PlayButton();
        BuyCanvas.enabled = false;
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = true;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = true;

    }

    public void CloseAlreadyCanvas()
    {
        SoundM.PlayButton();
        AlreadyCanvas.enabled = false;
        GoldORSilver_Fire.enabled = false;
        GoldORSilver_Ice.enabled = false;
        GoldORSilver_Thunder.enabled = false;
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = true;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = true;

    }

    public void CloseNotReadyCanvas()
    {
        SoundM.PlayButton();
        NotReadyCanvas.enabled = false;
        GoldORSilver_Fire.enabled = false;
        GoldORSilver_Ice.enabled = false;
        GoldORSilver_Thunder.enabled = false;
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = true;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = true;

    }

    public void CloseNotEnoughCanvas()
    {
        SoundM.PlayButton();
        NotEnoughMoney.enabled = false;
        GoldORSilver_Fire.enabled = false;
        GoldORSilver_Ice.enabled = false;
        GoldORSilver_Thunder.enabled = false;
        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = true;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = true;

    }
    IEnumerator NotEnough()
    {
        NotEnoughMoney.enabled = true;
        yield return new WaitForSeconds(1f);
        NotEnoughMoney.enabled = false;

        for (int i = 0; i <= 18; i++)
        {
            if (Buttons[i] != null)
                Buttons[i].enabled = true;
        }
        for (int i = 0; i < 12; i++) ShopUIBut[i].enabled = true;

    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (AlreadyCanvas.enabled) CloseAlreadyCanvas();
                else if (NotReadyCanvas.enabled) CloseNotReadyCanvas();
                else if (BuyCanvas.enabled) NotBuyingItem();
            }
        }
    }

}