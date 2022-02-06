using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterResMangShark : MonoBehaviour
{

    public ObjectPooling ObjP;
    public GameObject Monster1;
    // Use this for initialization
    Vector3[] RespawnPos = new Vector3[100];
    int pos;

    void Awake()
    {
        this.gameObject.AddComponent<ObjectPooling>();
        ObjP = new ObjectPooling();
    }

    void Start()
    {
        ObjP.InitPool(Monster1, 20);
        for (int i = 0; i < 20; i++)
        {
            RespawnPos[i] = new Vector3(-120, 0, -80 + (8 * i));
        }
        for (int i = 20; i < 40; i++)
        {
            RespawnPos[i] = new Vector3(120, 0, 80 - 8 * (i - 20));
        }
        for (int i = 40; i < 70; i++)
        {
            RespawnPos[i] = new Vector3(-120 + 8 * (i - 40), 0, 80);
        }
        for (int i = 70; i < 100; i++)
        {
            RespawnPos[i] = new Vector3(-120 + 8 * (i - 70), 0, -80);
        }
        if (!NewJam_Tuto.isPanTuto)
            StartCoroutine(MonsterRes());
    }

    IEnumerator MonsterRes()
    {
        while (true)
        {
            if (Time.timeScale.Equals(1))
            {
                pos = Random.Range(0, 100);

                ObjectPop(ObjP.PopObject(), RespawnPos[pos]);

                yield return new WaitForSeconds(5f);
            }
            else
                yield return new WaitForSeconds(0.5f);
        }
    }
    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }
}