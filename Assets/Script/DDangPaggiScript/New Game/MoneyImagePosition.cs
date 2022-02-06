using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyImagePosition : MonoBehaviour {
    //위치와 이펙트
    GameObject Player;
    public NewJamsuMoney NJM;
    public int Pos;

    private void Start()
    {
        Player = VisionMove_Button.Player;
    }

    private void Awake()
    {
        NJM = GameObject.Find("PoolAndCameraController").GetComponent<NewJamsuMoney>();
    }

    private void OnEnable()
    {
        Renderer rend = this.transform.GetComponent<Renderer>();
        rend.material.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Renderer rend = this.transform.GetComponent<Renderer>(); 

        int i = 0;
        while (i < 10)
        {
            rend.material.color -= new Color(0, 0, 0, 0.1f);
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        NewJamsuMoney.Num = 0;
        NJM.ObjPool.PushObject(this.gameObject);
    }

    void Update ()
    {
        this.gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+10, Player.transform.position.z + 10 + Pos);
	}
}
