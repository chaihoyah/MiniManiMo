using UnityEngine;
using System.Collections;

public class MonsterRes : MonoBehaviour
{

    public static int Level;
    public GameObject MonsterOne;// 오른쪽이동 몬스터
    public GameObject MonsterTwo;// 왼쪽이동 몬스터
    public ObjectPooling[] MonPool;
    int[] RandomInt = new int[10];
    int[] CoinRanArray = new int[8];
    float[] RanArray = new float[8];
    int[] LevelArray = new int[14];
    int idx = 0;
    public static int levelIdx=0;
    int PointChk = 200;
    int RanArrayidx = 0;

    public GameObject Coin;
    public GameObject Air;
    public ObjectPooling CoinPool;
    public ObjectPooling AirPool;

    private SoundManager SoundM;

    public bool SpurtUsed;
    bool SpurtStart;
    public GameObject PartyObject;

    // Use this for initialization
    void Awake()
    {
        MonPool = new ObjectPooling[2];
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        SpurtUsed = false;
        AirPool = new ObjectPooling();
        AirPool.InitPool(Air, 10);

        CoinPool = new ObjectPooling();
        CoinPool.InitPool(Coin, 10);
        MonPool[0] = new ObjectPooling();
        MonPool[1] = new ObjectPooling();
        MonPool[0].InitPool(MonsterOne, 10);
        MonPool[1].InitPool(MonsterTwo, 10);

        RanArray[0] = -1.51f;
        RanArray[1] = -1.025f;
        RanArray[2] = -0.582f;
        RanArray[3] = -0.145f;
        RanArray[4] = 0.346f;
        RanArray[5] = 0.744f;
        RanArray[6] = 1.148f;
        RanArray[7] = 1.464f;

        for (int i = 0; i < 8; i++)
        {
            CoinRanArray[i] = i;
        }
        for (int i = 0; i < 5; i++)
        {
            LevelArray[i] = i + 1;
        }
        for (int i = 0; i < 4; i++)
        {
            LevelArray[i + 5] = i + 2;
        }
        for (int i = 0; i < 3; i++)
        {
            LevelArray[i + 9] = i + 3;
        }
        LevelArray[12] = 4;
        LevelArray[13] = 5;

        for (int i = 0; i < 10; i++)
        {
            RandomInt[i] = Random.Range(0, 2);
            idx = 0;
        }
        DDangGlo.Level = LevelArray[levelIdx];
        RandomArray();

        SpurtStart = true;
        yield return new WaitForSeconds(1f);
        if (!JamSoo_Tutorial.isPanTuto)
        {
            StartCoroutine(Updat());
            StartCoroutine(MonRes());
            StartCoroutine(CoAiRes());
            StartCoroutine(Spurt());
        }
    }

    IEnumerator MonResThree()
    {
        while (true)
        {
            Vector3 MonPos = Vector3.zero;
            if (idx.Equals(10)) idx = 0;

            if (RandomInt[idx].Equals(0))
            {
                RandomArray();
                for (int i = 0; i < DDangGlo.Level + 1; i++)
                {
                    MonPos = new Vector3(0.635f, -5f, RanArray[i]);

                    ObjectPop(MonPool[0].PopObject(), MonPos);
                    SoundM.PlayJamsuMonster();
                }
            }
            else
            {
                RandomArray();
                for (int i = 0; i < DDangGlo.Level + 1; i++)
                {
                    MonPos = new Vector3(0.835f, -5f, RanArray[i]);

                    ObjectPop(MonPool[1].PopObject(), MonPos);
                    SoundM.PlayJamsuMonster();
                }
            }

            for (int i = 0; i < DDangGlo.Level + 1; i++)
            {
                ObjectPop(CoinPool.PopObject(), new Vector3(0.635f, -4, RanArray[CoinRanArray[i]]));
            }
            idx++;
            yield return new WaitForSeconds(6 / DDangGlo.Level);
        }
    }

    IEnumerator MonRes()
    {
        while (true)
        {
            Vector3 MonPos = Vector3.zero;
            if (idx.Equals(10))
            {
                RanMon();
                idx = 0;
            }
            if (RanArrayidx.Equals(3))
            {
                RandomArray();
                RanArrayidx = 0;
            }

            if (RandomInt[idx].Equals(0))
            {

                MonPos = new Vector3(0.635f, -5f, RanArray[RanArrayidx]);

                ObjectPop(MonPool[0].PopObject(), MonPos);


            }
            else
            {

                MonPos = new Vector3(0.835f, -5f, RanArray[RanArrayidx]);

                ObjectPop(MonPool[1].PopObject(), MonPos);

            }
            idx++;
            RanArrayidx++;

            if (DDangGlo.Level.Equals(1))
            {
                SpurtUsed = false;
                yield return new WaitForSeconds(1.7f);
            }
            else if (DDangGlo.Level.Equals(2))
            {
                SpurtUsed = false;
                yield return new WaitForSeconds(1.4f);
            }
            else if (DDangGlo.Level.Equals(3))
            {
                SpurtUsed = false;
                yield return new WaitForSeconds(0.9f);
            }
            else if (DDangGlo.Level.Equals(4))
            {
                SpurtUsed = false;
                yield return new WaitForSeconds(0.65f);
            }
            else
            {
             /**   if(!SpurtUsed)
                {
                    PartyObject.transform.position = new Vector3(0.635f, -4, RanArray[3]);
                    PartyObject.SetActive(true);
                    SpurtUsed = true;
                }
                SpurtStart = true;**/
                yield return new WaitForSeconds(0.45f);
            }
        }
    }

    IEnumerator Spurt()
    {
        while (true)
        {
            yield return new WaitForSeconds(90f);
            PartyObject.transform.position = new Vector3(0.635f, -4, RanArray[3]);
            PartyObject.SetActive(true);
            SpurtStart = true;
        }
    }

    IEnumerator CoAiRes()
    {
        while (true)
        {

            CoinRan();
            if (DDangGlo.Level.Equals(1) || DDangGlo.Level.Equals(2) || DDangGlo.Level.Equals(3))
            {
                ObjectPop(AirPool.PopObject(), new Vector3(0.635f, -4, RanArray[CoinRanArray[0]]));
            }
            else
            {
                ObjectPop(AirPool.PopObject(), new Vector3(0.635f, -4, RanArray[CoinRanArray[0]]));
            }
            CoinRan();
            ObjectPop(CoinPool.PopObject(), new Vector3(0.635f, -4, RanArray[CoinRanArray[0]]));

            yield return new WaitForSeconds(1.8f);


        }
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }

    void SpurtCoinRes()
    {
        for (int i = 0; i < 10; i++)
        {
            float RanX = Random.Range(-1.5f, 1.5f);
            float RanY = Random.Range(-5.0f, -2.0f);
            ObjectPop(CoinPool.PopObject(), new Vector3(0.635f, RanY, RanX));
        }
    }

    void RandomArray()
    {
        for (int i = 0; i < 8; i++)
        {
            int RanNum = Random.Range(i, 8);

            float tmp = RanArray[RanNum];
            RanArray[RanNum] = RanArray[i];
            RanArray[i] = tmp;
        }
    }

    void CoinRan()
    {
        for (int i = 0; i < 8; i++)
        {
            int RanNum = Random.Range(i, 8);

            int tmp = CoinRanArray[RanNum];
            CoinRanArray[RanNum] = CoinRanArray[i];
            CoinRanArray[i] = tmp;
        }
    }

    void RanMon()
    {
        for (int i = 0; i < 10; i++)
        {
            RandomInt[i] = Random.Range(0, 2);
            idx = 0;
        }
    }

    IEnumerator Updat()
    {
        while (true)
        {
            if (PandaDown.isSpurtOn && SpurtStart)
            {
                yield return new WaitForSeconds(0.5f);
                SpurtCoinRes();
                SpurtStart = false;
            }

            if (DDangGlo.Point >= PointChk)
            {
                levelIdx++;
                DDangGlo.Level = LevelArray[levelIdx];
                PointChk += 200;
            }
            if (levelIdx > 13) break;
            yield return new WaitForEndOfFrame();
        }
    }

}
