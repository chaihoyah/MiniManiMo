using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JamsuCoinEffect : MonoBehaviour
{

    public GameObject PlusImage;
    public ObjectPooling ObjPool;
    public ObjectPooling ObjGoldPool;
    public bool[] isFull = new bool[10];
    public GameObject[] isGameObjectIn = new GameObject[20];
    Vector3 FirstPos;
    public int FullNum;
    public GameObject Canvas;
    public GameObject PlusGold;

    void Start()
    {
        ObjPool = this.gameObject.AddComponent<ObjectPooling>();
        ObjGoldPool = this.gameObject.AddComponent<ObjectPooling>();
        FirstPos = new Vector3(-145, 260, 0);
        ObjPool.InitPool(PlusImage, 15);
        ObjGoldPool.InitPool(PlusGold, 5);
        FullNum = 0;
    }

    public void FullChk()
    {
        Vector3 Pos = FirstPos - new Vector3(0, 50 * (FullNum + 1), 0);
        isGameObjectIn[FullNum] = ObjectPop(ObjPool.PopObject(), Pos);
        isFull[FullNum] = true;
        FullNum++;
    }

    public void FullChkGold()
    {
        Vector3 Pos = FirstPos - new Vector3(0, 50 * (FullNum + 1), 0);
        isGameObjectIn[FullNum] = ObjectPop(ObjGoldPool.PopObject(), Pos);
        isFull[FullNum] = true;
        FullNum++;
    }

    private GameObject ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.SetParent(Canvas.transform, false);
        obj.transform.localPosition = position;

        obj.SetActive(true);
        return obj;
    }

    public void EraseObj()
    {
        if (FullNum > 1)
        {
            FullNum--;
            for (int i = 0; i < FullNum; i++)
            {
                isGameObjectIn[i] = isGameObjectIn[i + 1];
                isFull[i] = isFull[i + 1];
            }
            isGameObjectIn[FullNum] = null;
            isFull[FullNum] = false;
        }
        else
        {
            FullNum = 0;
            isGameObjectIn[0] = null;
            isFull[0] = false;
        }
    }
}