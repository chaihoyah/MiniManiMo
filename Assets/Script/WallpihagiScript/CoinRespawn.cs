using UnityEngine;
using System.Collections;

public class CoinRespawn : MonoBehaviour
{
    public static ObjectPooling CoinPool;
    public GameObject Coin;

    Vector3[] respawnPos = new Vector3[15];

    int round = 1;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.3f);
        respawnPos[0] = new Vector3(-1, 1, -20); respawnPos[5] = new Vector3(-1, 1, -21); respawnPos[6] = new Vector3(-1, 1, -21);
        respawnPos[1] = new Vector3(1, 1, -20); respawnPos[7] = new Vector3(1, 1, -21); respawnPos[8] = new Vector3(1, 1, -22);
        respawnPos[2] = new Vector3(-1, -1, -20); respawnPos[9] = new Vector3(-1, -1, -21); respawnPos[10] = new Vector3(-1, -1, -22);
        respawnPos[3] = new Vector3(1, -1, -20); respawnPos[11] = new Vector3(1, -1, -21); respawnPos[12] = new Vector3(1, -1, -22);
        respawnPos[4] = new Vector3(0, 0, -20); respawnPos[13] = new Vector3(0, 0, -21); respawnPos[14] = new Vector3(0, 0, -22);

        CoinPool = new ObjectPooling();
        CoinPool.InitPool(Coin, 8);
        if(!DDRTutorial.tutorial)
        StartCoroutine(CoinRes());
    }

    IEnumerator CoinRes()
    {
        while (true)
        {
            if (round == 1)
            {
                if (ObjectNumber.coinpop == true && ObjectNumber.randomCoin == 1)
                {
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1: ObjectPop(CoinPool.PopObject(), respawnPos[0]); ObjectPop(CoinPool.PopObject(), respawnPos[5]); ObjectPop(CoinPool.PopObject(), respawnPos[6]); ObjectNumber.coinpop = false; break;
                        case 2: ObjectPop(CoinPool.PopObject(), respawnPos[1]); ObjectPop(CoinPool.PopObject(), respawnPos[7]); ObjectPop(CoinPool.PopObject(), respawnPos[8]); ObjectNumber.coinpop = false; break;
                    }
                }
            }
            else if (round == 2)
            {
                if (ObjectNumber.coinpop == true && ObjectNumber.randomCoin == 1)
                {
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1: ObjectPop(CoinPool.PopObject(), respawnPos[0]); ObjectPop(CoinPool.PopObject(), respawnPos[5]); ObjectPop(CoinPool.PopObject(), respawnPos[6]); ObjectNumber.coinpop = false; break;
                        case 2: ObjectPop(CoinPool.PopObject(), respawnPos[1]); ObjectPop(CoinPool.PopObject(), respawnPos[7]); ObjectPop(CoinPool.PopObject(), respawnPos[8]); ObjectNumber.coinpop = false; break;
                        case 3: ObjectPop(CoinPool.PopObject(), respawnPos[2]); ObjectPop(CoinPool.PopObject(), respawnPos[9]); ObjectPop(CoinPool.PopObject(), respawnPos[10]); ObjectNumber.coinpop = false; break;
                        case 4: ObjectPop(CoinPool.PopObject(), respawnPos[3]); ObjectPop(CoinPool.PopObject(), respawnPos[11]); ObjectPop(CoinPool.PopObject(), respawnPos[12]); ObjectNumber.coinpop = false; break;
                    }
                }
            }
            else
            {
                if (ObjectNumber.coinpop == true && ObjectNumber.randomCoin == 1)
                {
                    switch (ObjectNumber.ObjNum)
                    {
                        case 1: ObjectPop(CoinPool.PopObject(), respawnPos[0]); ObjectPop(CoinPool.PopObject(), respawnPos[5]); ObjectPop(CoinPool.PopObject(), respawnPos[6]); ObjectNumber.coinpop = false; break;
                        case 2: ObjectPop(CoinPool.PopObject(), respawnPos[1]); ObjectPop(CoinPool.PopObject(), respawnPos[7]); ObjectPop(CoinPool.PopObject(), respawnPos[8]); ObjectNumber.coinpop = false; break;
                        case 3: ObjectPop(CoinPool.PopObject(), respawnPos[2]); ObjectPop(CoinPool.PopObject(), respawnPos[9]); ObjectPop(CoinPool.PopObject(), respawnPos[10]); ObjectNumber.coinpop = false; break;
                        case 4: ObjectPop(CoinPool.PopObject(), respawnPos[3]); ObjectPop(CoinPool.PopObject(), respawnPos[11]); ObjectPop(CoinPool.PopObject(), respawnPos[12]); ObjectNumber.coinpop = false; break;
                        case 5: ObjectPop(CoinPool.PopObject(), respawnPos[4]); ObjectPop(CoinPool.PopObject(), respawnPos[13]); ObjectPop(CoinPool.PopObject(), respawnPos[14]); ObjectNumber.coinpop = false; break;
                    }
                }
            }
            if (Time.time <= 30) round = 1;
            else if (Time.time <= 60) round = 2;
            else round = 3;

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }

}