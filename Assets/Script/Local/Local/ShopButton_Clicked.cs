using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButton_Clicked : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

    Vector3 Scale;
    Item ItemScript;
    public GameObject ItemContainer;

    void Start()
    {
        ItemContainer = GameObject.Find("BuyCanvas");
        ItemScript = ItemContainer.transform.GetComponent<Item>();
        Scale = transform.localScale;
    }

	public void OnPointerDown(PointerEventData eventData)
    {
        for(int i = 0; i < 12; i++)
        {
            if (ItemScript.ShopUIBut[i].gameObject.Equals(this.gameObject)) break;
            else
            {
                if (i.Equals(11)) ItemScript.card = this.gameObject;
            }
        }
        if(this.gameObject.transform.GetComponent<Button>().enabled) transform.localScale = 1.2f * Scale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = Scale;
    }
}
