using UnityEngine;
using System.Collections;

public class SpurtMove : MonoBehaviour {
    public GameObject LeftMon;
    Vector3 Go;

    IEnumerator Right()
    {
        while (true)
        {

            if (LeftMon.transform.position.y >= 0f)
            {
                LeftMon.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        if (!DDangGlo.isFinished)
        {
                Go = new Vector3(0, 0.03f, 0);
      
            LeftMon.transform.position += Go;
        }
    }

    // Use this for initialization
    void Start()
    {
        Go = new Vector3(0, 0.03f, 0);

        StartCoroutine(Right());
    }

}
