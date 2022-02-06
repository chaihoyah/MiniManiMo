using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class CenterButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public Button center;
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
            if (Ares.ArrowArr[0].Equals(5))
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

            WallCount.isPressed = true;
            collide.transform.position = new Vector3(0, 0, 0);
            foxAnim.SetBool("center", true);
            foxAnim.SetBool("fall", false);

        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        WallCount.isPressed = false;
        collide.transform.position = pos;
        foxAnim.SetBool("center", false);
        foxAnim.SetBool("fall", true);
    }
}