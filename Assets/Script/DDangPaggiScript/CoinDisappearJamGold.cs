using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisappearJamGold : MonoBehaviour
{

    public JamsuCoinEffect CE;

    // Use this for initialization

    private void Awake()
    {
        CE = GameObject.Find("Plane").GetComponent<JamsuCoinEffect>();
    }

    private void OnEnable()
    {
        Image Img = this.GetComponent<Image>();
        Img.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Image Img = this.GetComponent<Image>();

        int i = 0;
        while (i < 10)
        {
            Img.color -= new Color(0, 0, 0, 0.1f);
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        CE.EraseObj();
        //CE.FullNum--;
        CE.ObjGoldPool.PushObject(this.gameObject);
        //CE.isFull[CE.FullNum] = false;

    }
}