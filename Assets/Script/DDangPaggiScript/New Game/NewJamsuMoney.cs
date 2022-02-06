using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJamsuMoney : MonoBehaviour {

    public GameObject PlusImage;
    public ObjectPooling ObjPool;
    public static int Num = 0;
    GameObject Player;

    void Start()
    {
        if (!PlayerPrefs.GetInt("isNewJamTuto").Equals(0))
        {
            Num = 0;
            Player = VisionMove_Button.Player;
            ObjPool = this.gameObject.AddComponent<ObjectPooling>();
            ObjPool.InitPool(PlusImage, 15);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("wolf")||other.CompareTag("stone")||other.CompareTag("Mon"))
        {
            TimeText.Money += 5;
            Num += 1;
            ObjectPop(ObjPool.PopObject(), new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z + 10 + Num * 8));
            ObjPool.PopObject().transform.GetComponent<MoneyImagePosition>().Pos = 8 * Num;
        }
    }

    private GameObject ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.position = position;

        obj.SetActive(true);
        return obj;
    }

    private void Update()
    {
        //this.transform.position = Player.transform.position;
    }
}
