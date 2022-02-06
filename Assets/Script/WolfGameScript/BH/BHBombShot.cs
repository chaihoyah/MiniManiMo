using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHBombShot : MonoBehaviour {

    public GameObject bombcol;

    private void OnEnable()
    {
        StartCoroutine(MoveBul());
    }

    IEnumerator MoveBul()
    {
        int i = 0;
        while (i < 43)
        {
            i++;
            this.transform.Translate(0, 1.1f - 0.06f * i, 0.7f);
            if (i == 35)
            {
                bombcol.transform.position = this.transform.position;
                bombcol.SetActive(true);
            }
            yield return new WaitForEndOfFrame();
        }
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Wall")|| collision.CompareTag("wolf")|| collision.CompareTag("goldWolf"))
        {
            bombcol.transform.position = this.transform.position;
            bombcol.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }

}
