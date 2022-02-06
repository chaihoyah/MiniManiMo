using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeFloorText : MonoBehaviour {

    public Image floor;
    public GameObject pos;
    public GameObject pos2;

    IEnumerator flo()
    {
        while (floor.transform.position.x < pos.transform.position.x)
        {
            floor.transform.position += new Vector3(5.0f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1.0f);

        while (floor.transform.position.x < pos2.transform.position.x)
        {
            floor.transform.position += new Vector3(5.0f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        floor.gameObject.SetActive(false);
    }

    void Start()
    {
        StartCoroutine("flo");
    }
}
