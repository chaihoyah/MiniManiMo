using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton_Clicked : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    Vector3 Scale;
    Button button;

    void Start()
    {
        Scale = transform.localScale;
        button = this.gameObject.transform.GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(button.enabled && button.interactable)
            transform.localScale = 1.2f * Scale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = Scale;
    }
}
