using UnityEngine;
using System.Collections;

public class PandaMove : MonoBehaviour
{

    public GameObject panda;
    public GameObject wolf;
    public GameObject goldWolf;
    private Vector3 wolfPos;
    private Vector3 go;
    private float angle;
    private bool collide;

    private Vector3 PanGo;

    float dX;
    float dY;

    public SoundManager SoundM;

    void Start()
    {
        collide = false;

        StartCoroutine(Move());

    }

    IEnumerator Move()
    {
        while (true)
        {
            if (Time.timeScale > 0)
            {
                if (collide == true)
                {

                    dX += panda.transform.position.x - wolfPos.x;
                    dY += panda.transform.position.z - wolfPos.z;
                    angle = Mathf.Atan2(dX, dY);
                    panda.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);
                    panda.transform.Translate(new Vector3(0, 0, 1) * 0.01f);
                    dX = 0;
                    dY = 0;

                    collide = false;
                }
                else
                {
                    dX = 0;
                    dY = 0;
                }
                yield return new WaitForEndOfFrame();
            }
            else yield return new WaitForSeconds(0.01f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wolf") || other.CompareTag("goldWolf"))
        {
            SoundM.PlayWolf();
            wolfPos = other.transform.position;
            dX += panda.transform.position.x - wolfPos.x;
            dY += panda.transform.position.z - wolfPos.z;

            collide = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("wolf") || other.CompareTag("goldWolf"))
        {
            collide = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wolf") || other.CompareTag("goldWolf"))
        {
            wolfPos = Vector3.zero;
            dX = 0;
            dY = 0;

            collide = false;
        }
    }
}