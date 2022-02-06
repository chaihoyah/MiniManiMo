using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SightRightMoving : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image ButtonImage;
    public GameObject Panda;
    Rigidbody PanRig;

    private bool isPressed;

    // Use this for initialization
    void Start () {
        isPressed = false;
        ButtonImage = this.GetComponent<Image>();
        PanRig = Panda.GetComponent<Rigidbody>();
        StartCoroutine(Upd());
	}
    IEnumerator Upd()
    {
        while (true)
        {
            PanRig.velocity = Vector3.zero;
            PanRig.angularVelocity = Vector3.zero;
            yield return new WaitForSeconds(0.3f);
        }
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
	    if(isPressed) Panda.transform.Rotate(0, 0, 3f, Space.Self);
    }
}
