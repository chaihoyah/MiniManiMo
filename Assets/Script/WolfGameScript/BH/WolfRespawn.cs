using UnityEngine;
using System.Collections;

public class WolfRespawn : MonoBehaviour
{
    public static int pos;
    public static int res;
    public GameObject wolf;
    public GameObject floor;
    private Vector3 respawn1;
    private Vector3 respawn2;
    private Vector3 respawn3;
    private Vector3 respawn4;
    private Vector3 respawn5;
    private Vector3 respawn6;
    private Vector3 respawn7;

    float x;
    float z;

    public WolfObjectPool WObjPool;

    void Awake()
    {

        respawn1 = new Vector3(49.6f, 2, 65.2f);//오위
        respawn2 = new Vector3(67.2f, 2, 39);//오오
        respawn3 = new Vector3(-49.6f, 2, 65.2f);//왼위
        respawn4 = new Vector3(-67.2f, 2, 39);
        respawn5 = new Vector3(0, 2, -70);//아
        respawn6 = new Vector3(-39.6f, 2, -44.2f);//왼아
        respawn7 = new Vector3(39.6f, 2, -44.2f);//오아
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        wolf.transform.localScale = new Vector3(0.108724f, 0.108724f, 0.108724f);
        res = 6;
        WObjPool = new WolfObjectPool();
        WObjPool.InitPool(wolf, 8);
        if (!BH_Tuto.isPanTuto)
        {
            StartCoroutine(UPDAT());
            StartCoroutine(RespawnPosition());
        }
    }

    IEnumerator RespawnPosition()
    {
        while (true)
        {
            if (ScoreScript.time < 30)
            {
                pos = Random.Range(0, 40);
                if (pos < 9) ObjectPop(WObjPool.PopObject(), respawn1);
                else if (pos < 18) ObjectPop(WObjPool.PopObject(), respawn2);
                else if (pos < 27) ObjectPop(WObjPool.PopObject(), respawn3);
                else if (pos < 36) ObjectPop(WObjPool.PopObject(), respawn4);
            }
            else
            {
                pos = Random.Range(0, 70);
                if (pos < 9) ObjectPop(WObjPool.PopObject(), respawn1);
                else if (pos < 18) ObjectPop(WObjPool.PopObject(), respawn2);
                else if (pos < 27) ObjectPop(WObjPool.PopObject(), respawn3);
                else if (pos < 36) ObjectPop(WObjPool.PopObject(), respawn4);
                else if (pos < 45) ObjectPop(WObjPool.PopObject(), respawn5);
                else if (pos < 54) ObjectPop(WObjPool.PopObject(), respawn6);
                else if (pos < 63) ObjectPop(WObjPool.PopObject(), respawn7);
            }
            yield return new WaitForSeconds(res);
        }
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }

    IEnumerator UPDAT()
    {
        while (true)
        {
            yield return new WaitForSeconds(55);
            if (res > 1)
            {
                res -= 1;
            }
        }
    }
}