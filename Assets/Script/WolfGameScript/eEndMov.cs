using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class eEndMov : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool isDrag;
    public GameObject BirImg;
    public GameObject BirImg2;//고무줄 오른쪽
    
    private Image REndImg;
    Vector3 inputDirection;
    Vector3 OriginScale;
    Vector3 OriginEndPos;
	// Use this for initialization

	void Start () {
        REndImg = this.GetComponent<Image>();
        OriginScale = BirImg.transform.localScale;
        OriginEndPos = REndImg.transform.position;
        inputDirection = REndImg.transform.position;
        isDrag = false;
	}

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        REndImg.rectTransform.position = inputDirection;
        BirImg.transform.rotation = new Quaternion(0, 0, 0, 0);
        BirImg.transform.localScale = OriginScale;

        BirImg2.transform.rotation = new Quaternion(0, 0, 0, 0);
        BirImg2.transform.localScale = OriginScale;

        isDrag = false;
    }
    // Use this for initialization

    public virtual void OnDrag(PointerEventData ped)
    {

        Vector2 pos = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(REndImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {

            isDrag = true;
            Vector2 MovePos;
            MovePos = ped.position - new Vector2(OriginEndPos.x, OriginEndPos.y);
            if (MovePos.y >= 0) MovePos.y = 0;

            if (MovePos.magnitude>500)
            {
                MovePos = (MovePos / MovePos.magnitude) * 500;
            }
            REndImg.rectTransform.position = new Vector2(OriginEndPos.x, OriginEndPos.y) + MovePos;

        }

    }

    // Update is called once per frame
    void Update () {

	}
}
