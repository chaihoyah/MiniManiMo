using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BHMachineGun : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public Image ButtonImage;//따발

    public BHBulletControl BHC;
    public Animator BirAnim;

    // Use this for initialization
    void Start () {
        ButtonImage = this.GetComponent<Image>();
	}

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(ButtonImage.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {

            BHC.isPress = true;
        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        BirAnim.SetBool("isAttack", false);
        BirAnim.SetBool("isRun", true);
        BHC.isPress = false;
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        BirAnim.SetBool("isAttack", true);
        BirAnim.SetBool("isRun", false);
        OnDrag(ped);
    }

}
