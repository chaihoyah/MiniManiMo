using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BHCoinEffect : MonoBehaviour {

    public GameObject PlusImage;
    public ObjectPooling ObjPool;
    public ObjectPooling ObjGoldPool;
    public bool[] isFull = new bool[10];
    public GameObject[] isGameObjectIn = new GameObject[20];
    public GameObject[] isGameObjectInGold = new GameObject[20];
    Vector3 FirstPos;
    Vector3 FirstPosGold;
    public int FullNum;
    public int FullNumGold;
    public GameObject Canvas;
    public Sprite Five_Silver;
    public Sprite Six_Silver;
    public GameObject PlusGold;

    // Use this for initialization
    void Start()
    {
        if (RoundController_Snow.round.Equals(2))
        {
            PlusImage.GetComponent<Image>().sprite = Six_Silver;
        }
        else
        {
            PlusImage.GetComponent<Image>().sprite = Five_Silver;
        }
        ObjPool = this.gameObject.AddComponent<ObjectPooling>();
        ObjGoldPool = this.gameObject.AddComponent<ObjectPooling>();
        FirstPosGold= new Vector3(40, 275, 0);
        FirstPos = new Vector3(0, 230, 0);
        ObjPool.InitPool(PlusImage, 15);
        ObjGoldPool.InitPool(PlusGold, 5);
        FullNumGold = 0;
        FullNum = 0;
    }

    public void FullChk()
    {
        FullNum++;
        Vector3 Pos = FirstPos - new Vector3(0, 50 * FullNum, 0);
        isGameObjectIn[FullNum] = ObjectPop(ObjPool.PopObject(), Pos);
        isFull[FullNum] = true;

    }

    public void FullChkGold()
    {
        print(FullNumGold);
        FullNumGold++;
        Vector3 Pos = FirstPosGold - new Vector3(0, 50 * FullNumGold, 0);
        isGameObjectInGold[FullNumGold] = ObjectPop(ObjGoldPool.PopObject(), Pos);

    }

    private GameObject ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.SetParent(Canvas.transform, false);
        obj.transform.localPosition = position;

        obj.SetActive(true);
        return obj;
    }
}
