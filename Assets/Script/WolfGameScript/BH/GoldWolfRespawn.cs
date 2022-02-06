using UnityEngine;
using System.Collections;

public class GoldWolfRespawn : MonoBehaviour
{
    public GameObject goldWolf;
    public GameObject floor;
    private Vector3 respawn1;
    private Vector3 respawn2;
    private Vector3 respawn3;
    private Vector3 respawn4;
    private Vector3 respawn5;
    private Vector3 respawn6;
    private Vector3 respawn7;

    public ObjectPooling GWObjPool;

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
        goldWolf.transform.localScale = new Vector3(0.108724f, 0.108724f, 0.108724f);
        GWObjPool = new ObjectPooling();
        GWObjPool.InitPool(goldWolf, 8);
        if (!BH_Tuto.isPanTuto)
            StartCoroutine(RespawnPosition());
    }

    IEnumerator RespawnPosition()
    {
        while (true)
        {
            if (ScoreScript.time < 30)
            {
                switch (WolfRespawn.pos)
                {
                    case 36:
                        ObjectPop(GWObjPool.PopObject(), respawn1);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 37:
                        ObjectPop(GWObjPool.PopObject(), respawn2);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 38:
                        ObjectPop(GWObjPool.PopObject(), respawn3);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 39:
                        ObjectPop(GWObjPool.PopObject(), respawn4);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    default:
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                }
            }
            else
            {
                switch (WolfRespawn.pos)
                {
                    case 63:
                        ObjectPop(GWObjPool.PopObject(), respawn1);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 64:
                        ObjectPop(GWObjPool.PopObject(), respawn2);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 65:
                        ObjectPop(GWObjPool.PopObject(), respawn3);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 66:
                        ObjectPop(GWObjPool.PopObject(), respawn4);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 67:
                        ObjectPop(GWObjPool.PopObject(), respawn5);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 68:
                        ObjectPop(GWObjPool.PopObject(), respawn6);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    case 69:
                        ObjectPop(GWObjPool.PopObject(), respawn7);
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                    default:
                        yield return new WaitForSeconds(WolfRespawn.res);
                        break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }
}