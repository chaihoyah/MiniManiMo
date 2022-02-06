using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SightLeftMoving : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image ButtonImage;
    public GameObject Panda;
    private bool isPressed;

    // Use this for initialization
    void Start () {
        ButtonImage = this.GetComponent<Image>();
        isPressed = false;
    }


    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(ButtonImage.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            isPressed = true;
        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        isPressed = false;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    { 
        OnDrag(ped);
    }

    // Update is called once per frame
    void Update () {
        if (isPressed) Panda.transform.Rotate(0, 0, -3f, Space.Self);
    }
}
