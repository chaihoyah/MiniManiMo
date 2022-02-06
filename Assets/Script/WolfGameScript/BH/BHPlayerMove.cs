using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BHPlayerMove : MonoBehaviour
{

    public float moveSpeed;
    public VirtualJoystick MoveJoystick;

    float angle;
    float speed;
    int i;
    Quaternion di;
    Rigidbody Rig;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("WolfSpeed2") == 1)
        {
            speed = 0.365f;
        }
        else if (PlayerPrefs.GetInt("WolfSpeed1") == 1)
        {
            speed = 0.335f;
        }
        else
        {
            speed = 0.3f;
        }
        Rig = this.GetComponent<Rigidbody>();
        StartCoroutine(StartMove());
        StartCoroutine(StartGG());
    }

    // Update is called once per frame
    IEnumerator StartMove()
    {

        while (true)
        {
            if (Time.timeScale.Equals(1))
            {
                angle = MoveJoystick.angle;
                if (angle != 0)//&& camRotate.RotateBackOn.Equals(false))
                {
                    transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI) - 180, 0);
                }
                if (MoveJoystick.isDrag)
                {
                    Vector3 MoveDir = new Vector3(0, 0, speed * WolfScript.Calculation);
                    transform.Translate(MoveDir);
                }
            }
            /** if (MoveJoystick.MovePos != Vector2.zero)
             {
                 Vector3 MoveDir = new Vector3(0, 0, speed);//*MoveJoystick.MovePos.magnitude);

                 transform.Translate(MoveDir);
             }
             angle = MoveJoystick.angle;

                 transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI) - 180, 0);**/

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator StartGG()
    {
        while (true)
        {
            Rig.velocity = Vector3.zero;
            Rig.velocity = Vector3.zero;
            yield return new WaitForSeconds(1f / WolfScript.Calculation);
        }
    }


    float angleChk(float ang)
    {
        if (ang >= -2.625 && ang <= -1.875) return -2.25f;
        else if (ang > -1.875 && ang <= -1.125) return -1.5f;
        else if (ang > -1.125 && ang <= -0.375) return -0.75f;
        else if (ang > -0.375 && ang <= 0.375) return 0;
        else if (ang > 0.375 && ang <= 1.125) return 0.75f;
        else if (ang > 1.125 && ang <= 1.875) return 1.5f;
        else if (ang > 1.875 && ang <= 2.625) return 2.25f;
        else
        {
            return ang = -3f;
        }
    }
}