using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinEffect : MonoBehaviour {
    public GameObject PlusImage;
    public ObjectPooling ObjPool;
    public bool[] isFull= new bool[10];
    public GameObject[] isGameObjectIn = new GameObject[20];
    Vector3 FirstPos;
    public int FullNum;
    public GameObject Canvas;
    public Sprite Five_Silver;
    public Sprite Six_Silver;

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.GetInt("Pizza2").Equals(2))
        {
            PlusImage.GetComponent<Image>().sprite = Six_Silver;
        }
        else
        {
            PlusImage.GetComponent<Image>().sprite = Five_Silver;
        }
        ObjPool = this.gameObject.AddComponent<ObjectPooling>();
        FirstPos = new Vector3(212, 385, 0);
        ObjPool.InitPool(PlusImage, 15);
	}

    public void FullChk()
    {
        /**for(int i=0;i<10;i++)
        {
            if (isFull[i]) continue;
            else
            {
                FullNum = i;
                break;
            }
        }**/
        FullNum++;
        Vector3 Pos = FirstPos - new Vector3(0, 50 * FullNum, 0);
        isGameObjectIn[FullNum] = ObjectPop(ObjPool.PopObject(), Pos);
        isFull[FullNum] = true;

    }

    private GameObject ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.SetParent(Canvas.transform, false);
        obj.transform.localPosition = position;

        obj.SetActive(true);
        return obj;
    }
}
