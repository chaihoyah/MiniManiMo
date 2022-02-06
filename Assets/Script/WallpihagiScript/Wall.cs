using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Wall : MonoBehaviour
{
    public GameObject ComboText;
    public static ObjectPooling[] objPoolArr = new ObjectPooling[5];
    public static bool spur = false;

    public GameObject Wall_One;
    public GameObject Wall_Two;
    public GameObject Wall_Three;
    public GameObject Wall_Four;
    public GameObject Wall_Five;

    public GameObject Wall_One_Bul;
    public GameObject Wall_Two_Bul;
    public GameObject Wall_Three_Bul;
    public GameObject Wall_Four_Bul;
    public GameObject Wall_Five_Bul;

    public GameObject Wall_One_Pota;
    public GameObject Wall_Two_Pota;
    public GameObject Wall_Three_Pota;
    public GameObject Wall_Four_Pota;
    public GameObject Wall_Five_Pota;

    public GameObject Wall_One_Shr;
    public GameObject Wall_Two_Shr;
    public GameObject Wall_Three_Shr;
    public GameObject Wall_Four_Shr;
    public GameObject Wall_Five_Shr;

    public bool isPota;
    public bool isShr;


    Vector3 RespawnPosOne;

    public static int round = 1;
    public static int Difficulty = 1; //1:쉬움, 2:보통, 3:어려움

    Vector3[] WallPos = new Vector3[5];

    private Text Score, Coin;
    public Text Gold;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.Portrait;
        WallPos[0] = Wall_One.transform.position;
        WallPos[1] = Wall_Two.transform.position;
        WallPos[2] = Wall_Three.transform.position;
        WallPos[3] = Wall_Four.transform.position;
        WallPos[4] = Wall_Five.transform.position;
        Score = GameObject.Find("Score").GetComponent<Text>();
        Coin = GameObject.Find("Coin").GetComponent<Text>();

    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        isPota = false;
        isShr = false;
        WallCount.isFinished = false;

        objPoolArr[0] = new ObjectPooling();
        objPoolArr[1] = new ObjectPooling();
        objPoolArr[2] = new ObjectPooling();
        objPoolArr[3] = new ObjectPooling();
        objPoolArr[4] = new ObjectPooling();
        if (PlayerPrefs.GetInt("Pizza0") == 2)
        {
            objPoolArr[0].InitPool(Wall_One, 8);
            objPoolArr[1].InitPool(Wall_Two, 8);
            objPoolArr[2].InitPool(Wall_Three, 8);
            objPoolArr[3].InitPool(Wall_Four, 8);
            objPoolArr[4].InitPool(Wall_Five, 8);
        }
        else if (PlayerPrefs.GetInt("Pizza1") == 2)
        {
            objPoolArr[0].InitPool(Wall_One_Bul, 8);
            objPoolArr[1].InitPool(Wall_Two_Bul, 8);
            objPoolArr[2].InitPool(Wall_Three_Bul, 8);
            objPoolArr[3].InitPool(Wall_Four_Bul, 8);
            objPoolArr[4].InitPool(Wall_Five_Bul, 8);
        }
        else if (PlayerPrefs.GetInt("Pizza2") == 2)
        {
            objPoolArr[0].InitPool(Wall_One_Pota, 8);
            objPoolArr[1].InitPool(Wall_Two_Pota, 8);
            objPoolArr[2].InitPool(Wall_Three_Pota, 8);
            objPoolArr[3].InitPool(Wall_Four_Pota, 8);
            objPoolArr[4].InitPool(Wall_Five_Pota, 8);
            isPota = true;
        }
        else if (PlayerPrefs.GetInt("Pizza3") == 2)
        {
            objPoolArr[0].InitPool(Wall_One_Shr, 8);
            objPoolArr[1].InitPool(Wall_Two_Shr, 8);
            objPoolArr[2].InitPool(Wall_Three_Shr, 8);
            objPoolArr[3].InitPool(Wall_Four_Shr, 8);
            objPoolArr[4].InitPool(Wall_Five_Shr, 8);
            isShr = true;
        }
        RespawnPosOne = new Vector3(0, 0, -10);

        if (!DDRTutorial.tutorial)//
        {
            StartCoroutine(RoundFunction());
            if (Wall.Difficulty.Equals(3))
            {
                StartCoroutine(WallRe());
            }
            else
            {
                ComboText.SetActive(false);
                StartCoroutine(WallReEasy());
            }
        }
        StartCoroutine(Updat());
    }

    IEnumerator WallRe()
    {
        while (true)
        {
            if (round == 1)
            {
                if (ObjectNumber.wallpop == true)
                {
                    int k = Random.Range(1, 9);
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1:
                            GameObject RandomPizza = objPoolArr[0].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizza.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(RandomPizza, new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[0].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 2:
                            GameObject RandomPizzaTwo = objPoolArr[1].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzaTwo.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(RandomPizzaTwo, new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[1].z));
                            ObjectNumber.wallpop = false;
                            break;
                    }

                }
                yield return new WaitForSeconds(0.01f);

            }
            else if (round == 2)
            {
                if (ObjectNumber.wallpop == true)
                {
                    int k = Random.Range(1, 6);
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1:
                            GameObject RandomPizza = objPoolArr[0].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizza.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[0].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[0].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 2:
                            GameObject RandomPizzatwo = objPoolArr[1].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzatwo.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[1].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[1].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 3:
                            GameObject RandomPizzathree = objPoolArr[2].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzathree.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[2].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[2].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 4:
                            GameObject RandomPizzafour = objPoolArr[3].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzafour.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[3].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[3].z));
                            ObjectNumber.wallpop = false;
                            break;
                    }

                }
                yield return new WaitForSeconds(0.01f);
            }
            else if (round == 3)
            {
                if (ObjectNumber.wallpop == true)
                {
                    int k = Random.Range(1, 5);
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1:
                            GameObject RandomPizza = objPoolArr[0].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizza.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[0].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[0].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 2:
                            GameObject RandomPizzatwo = objPoolArr[1].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzatwo.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[1].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[1].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 3:
                            GameObject RandomPizzathree = objPoolArr[2].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzathree.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[2].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[2].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 4:
                            GameObject RandomPizzafour = objPoolArr[3].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzafour.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[3].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[3].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 5:
                            GameObject RandomPizzafive = objPoolArr[4].PopObject();
                            if (k.Equals(1))
                            {
                                RandomPizzafive.transform.FindChild("FullPizza").gameObject.SetActive(true);
                            }
                            ObjectPop(objPoolArr[4].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[4].z));
                            ObjectNumber.wallpop = false;
                            break;
                    }

                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator WallReEasy()
    {
        while (true)
        {
            if (round == 1)
            {
                if (ObjectNumber.wallpop == true)
                {
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1:
                            GameObject RandomPizza = objPoolArr[0].PopObject();
                            ObjectPop(RandomPizza, new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[0].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 2:
                            GameObject RandomPizzaTwo = objPoolArr[1].PopObject();
                            ObjectPop(RandomPizzaTwo, new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[1].z));
                            ObjectNumber.wallpop = false;
                            break;
                    }

                }
                yield return new WaitForSeconds(0.01f);

            }
            else if (round == 2)
            {
                if (ObjectNumber.wallpop == true)
                {
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1:
                            GameObject RandomPizza = objPoolArr[0].PopObject();
                            ObjectPop(objPoolArr[0].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[0].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 2:
                            GameObject RandomPizzatwo = objPoolArr[1].PopObject();
                            ObjectPop(objPoolArr[1].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[1].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 3:
                            GameObject RandomPizzathree = objPoolArr[2].PopObject();
                            ObjectPop(objPoolArr[2].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[2].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 4:
                            GameObject RandomPizzafour = objPoolArr[3].PopObject();
                            ObjectPop(objPoolArr[3].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[3].z));
                            ObjectNumber.wallpop = false;
                            break;
                    }

                }
                yield return new WaitForSeconds(0.01f);
            }
            else if (round == 3)
            {
                if (ObjectNumber.wallpop == true)
                {
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1:
                            GameObject RandomPizza = objPoolArr[0].PopObject();
                            ObjectPop(objPoolArr[0].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[0].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 2:
                            GameObject RandomPizzatwo = objPoolArr[1].PopObject();
                            ObjectPop(objPoolArr[1].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[1].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 3:
                            GameObject RandomPizzathree = objPoolArr[2].PopObject();
                            ObjectPop(objPoolArr[2].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[2].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 4:
                            GameObject RandomPizzafour = objPoolArr[3].PopObject();
                            ObjectPop(objPoolArr[3].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[3].z));
                            ObjectNumber.wallpop = false;
                            break;
                        case 5:
                            GameObject RandomPizzafive = objPoolArr[4].PopObject();
                            ObjectPop(objPoolArr[4].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[4].z));
                            ObjectNumber.wallpop = false;
                            break;
                    }

                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator RoundFunction()
    {
        while (true)
        {
            if (round == 1)
            {
                yield return new WaitForSeconds(30);
                round += 1;
            }
            if (round == 2)
            {
                yield return new WaitForSeconds(30);
                round += 1;
            }
            else break;
        }
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }

    IEnumerator Updat()
    {
        while (true)
        {
            Coin.text = WallCount.Point.ToString();
            Gold.text = WallCount.Gold.ToString();
            Score.text = "점수 :" + " " + WallCount.Score.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Tutorial()
    {
        int num;
        num = Random.Range(1, 6);
        switch (num)
        {
            case 1:
                ObjectPop(objPoolArr[0].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[0].z));
                break;
            case 2:
                ObjectPop(objPoolArr[1].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[1].z));
                break;
            case 3:
                ObjectPop(objPoolArr[2].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[2].z));
                break;
            case 4:
                ObjectPop(objPoolArr[3].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[3].z));
                break;
            case 5:
                ObjectPop(objPoolArr[4].PopObject(), new Vector3(RespawnPosOne.x, RespawnPosOne.y, WallPos[4].z));
                break;
        }
    }

}