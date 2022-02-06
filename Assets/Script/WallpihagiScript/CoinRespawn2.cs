using UnityEngine;
using System.Collections;

public class CoinRespawn2 : MonoBehaviour {

    ObjectPooling CoinPool;
    public GameObject Coin;

    Vector3[] respawnPos = new Vector3[5];

    int Position,time;

    void Start()
    {
        respawnPos[0] = new Vector3(-1, 1, -20);
        respawnPos[1] = new Vector3(1, 1, -20);
        respawnPos[2] = new Vector3(-1, -1, -20);
        respawnPos[3] = new Vector3(1, -1, -20);
        respawnPos[4] = new Vector3(0, 0, -20);
        if(!DDRTutorial.tutorial)
        StartCoroutine(CoinRes());
    }

    IEnumerator CoinRes()
    {
        time = Random.Range(1, 3);
        yield return new WaitForSeconds(time);
        CoinPool = CoinRespawn.CoinPool;
        while (true)
        {
            Position = Random.Range(0, 5);
            ObjectPop(CoinPool.PopObject(), respawnPos[Position]);
            time = Random.Range(1, 3);
            yield return new WaitForSeconds(time);
        }
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }
}
