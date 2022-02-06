using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick_NewGame : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image bgimg;
    private Image joystickimg;

    public Animator SwimAni;
    public Vector3 inputDirection { set; get; }
    public Vector2 MovePos { set; get; }
    public Vector2 rotateDir;
    public GameObject GO;
    public bool isDrag;
    Vector3 OriginEndPos;
    public float angle;
    public NewJam_Tuto Tut;

    private void Start()
    {
        bgimg = GetComponent<Image>();
        joystickimg = transform.GetChild(0).GetComponent<Image>();
        OriginEndPos = GO.transform.position;
        Vector3 ss = joystickimg.transform.position;
        inputDirection = Vector3.zero;
        rotateDir = Vector2.zero;
        angle = 0;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        Tut.TutoBool[0] = true;
        if (Time.timeScale == 1)
        {
            OnDrag(ped);
        }
        else
        {
            isDrag = false;
            MovePos = Vector2.zero;
            inputDirection = Vector3.zero;
            joystickimg.rectTransform.anchoredPosition = Vector3.zero;
        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        isDrag = false;
        MovePos = Vector2.zero;
        inputDirection = Vector3.zero;
        joystickimg.rectTransform.anchoredPosition = Vector3.zero;

    }

    public virtual void OnDrag(PointerEventData ped)
    {
        if (Time.timeScale == 1)
        {
            Vector2 pos = Vector2.zero;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgimg.rectTransform, ped.position, ped.pressEventCamera, out pos))
            {
                isDrag = true;
                pos.x = (pos.x / bgimg.rectTransform.sizeDelta.x);
                pos.y = (pos.y / bgimg.rectTransform.sizeDelta.y);

                float x = (bgimg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
                float y = (bgimg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

                inputDirection = new Vector3(x, 0, y);
                inputDirection = inputDirection.normalized;

                joystickimg.rectTransform.anchoredPosition = new Vector3(inputDirection.x * (bgimg.rectTransform.sizeDelta.x * 0.3f), inputDirection.z * (bgimg.rectTransform.sizeDelta.y * 0.3f));
                float dX = joystickimg.rectTransform.anchoredPosition.x;
                float dY = joystickimg.rectTransform.anchoredPosition.y;
                if (dX != 0 && dY != 0) angle = Mathf.Atan2(-dX, -dY);
                else { angle = 0; }
            }
        }
    }
}
