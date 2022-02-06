using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class RightUpButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public Button right;
    public GameObject collide;
    public Animator foxAnim;
    private Vector3 pos;
    public DDArrowRes Ares;
    public SoundManager SoundM;

    void Start()
    {
        pos = collide.transform.position;
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        if (!WallCount.isPressed)
        {
            if (Ares.ArrowArr[0].Equals(2))
            {
                if (Ares.ArrowArr[0].Equals(Ares.RanDDR)) WallCount.Score += 50;
                else WallCount.Score += 10;
                Destroy(Ares.ObjArr[0]);
                SoundM.PlayDDR();
                Ares.Combo++;
                if (!DDRTutorial.tutorial)
                {
                    Ares.isNextGo = true;

                }
                else
                {
                    DDRTutorial.nice = true;
                }
            }
            else Ares.Combo = 0;

            collide.transform.position = new Vector3(-1, 1, 1.5f);
            foxAnim.SetBool("rightUp", true);
            foxAnim.SetBool("fall", false);
            WallCount.isPressed = true;
        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        WallCount.isPressed = false;
        collide.transform.position = pos;
        foxAnim.SetBool("rightUp", false);
        foxAnim.SetBool("fall", true);
    }


}