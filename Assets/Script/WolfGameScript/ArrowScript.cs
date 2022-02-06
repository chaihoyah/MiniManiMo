using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ArrowScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private Button press;
    public GameObject arrowCont;
    public GameObject gaze;
    public static float power;
    bool right = true;
    bool left = false;
    bool gazeup = false;
    bool gazedown = false;
    private float time = 0;
    private Quaternion arrRot;
    float speed;
    float balance;

    Vector3 stoPos;

    void Awake()
    {
        gaze.transform.localScale = new Vector3(1, 0, 1);
    }

    void Start()
    {
        arrRot = arrowCont.transform.rotation;
        stoPos = new Vector3(0, 11, -15);
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        if (Time.timeScale > 0)
        {
            right = false;
            left = false;
            gazeup = true;
            gazedown = false;
        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        if (Time.timeScale > 0)
        {
            power = gaze.transform.localScale.y;
            gaze.transform.localScale = new Vector3(1, 0, 1);
            arrowCont.transform.rotation = arrRot;
            right = true;
            left = false;
            gazeup = false;
            gazedown = false;
        }
    }

    public void Press1()
    {
        time = 0;
        right = false;
        left = false;

    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (ScoreScript.isFinished == false)
            {
                if (right == true || left == true)
                {
                    if (time >= 180)
                    {
                        right = false;
                        left = true;
                        time -= ArrowBalance.speed;
                    }
                    if (time <= 0)
                    {
                        right = true;
                        left = false;
                        time += ArrowBalance.speed;
                    }
                    else
                    {
                        if (right == true)
                        {
                            arrowCont.transform.Rotate(new Vector3(0, 0, -0.5f) * ArrowBalance.speed);
                            time += ArrowBalance.speed;
                        }
                        else if (left == true)
                        {
                            arrowCont.transform.Rotate(new Vector3(0, 0, 0.5f) * ArrowBalance.speed);
                            time -= ArrowBalance.speed;
                        }
                    }
                }
                else
                {
                    time = 0;
                }
                if (gazeup == true && gazedown == false)
                {
                    gaze.transform.localScale += new Vector3(0, 0.1f, 0) * ArrowBalance.speed;
                    if (gaze.transform.localScale.y >= 5)
                    {
                        gazeup = false;
                        gazedown = true;
                    }
                }
                else if (gazeup == false && gazedown == true)
                {
                    gaze.transform.localScale -= new Vector3(0, 0.1f, 0) * ArrowBalance.speed;
                    if (gaze.transform.localScale.y <= 0.1)
                    {
                        gazedown = false;
                        gazeup = true;
                    }
                }
            }
            else
            {
                gaze.transform.localScale = new Vector3(1, 0, 1);
                arrowCont.transform.rotation = arrRot;
                right = false;
                left = false;
                gazeup = false;
                gazedown = false;
            }

        }
    }
}