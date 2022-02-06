using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePotalCamera : MonoBehaviour {

    public GameObject Camera;
    Vector3 CamPos;
    WaitForSeconds delay = new WaitForSeconds(0.1f);

    IEnumerator Start()
    {
        CamPos = Vector3.zero;
        Camera = GameObject.Find("CameraPan");
        yield return new WaitForSeconds(2f);
        StartCoroutine(cameraRotate());
        StartCoroutine(cameraMove());
    }

    private void OnEnable()
    {
        CamPos = Vector3.zero;
        Camera = GameObject.Find("Camera");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            CamPos = Camera.transform.position;

            StartCoroutine(cameraRotate());
            StartCoroutine(cameraMove());
        }
    }

    IEnumerator cameraRotate()
    {
        int i = 0;
        Debug.Log("TT");
        while (i < 20)
        {
            Debug.Log("TT");
            i++;
            Camera.transform.Rotate(-4.5f,0, 0);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator cameraMove()
    {
        Debug.Log("tt");
        int i = 0;
        while (i < 20)
        {
            i++;
            Camera.transform.position += new Vector3(0, 0, 0.5f);
            yield return delay;
        }
    }
}
