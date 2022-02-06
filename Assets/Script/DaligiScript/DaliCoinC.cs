using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaliCoinC : MonoBehaviour
{

    WaitForSeconds delay = new WaitForSeconds(0.01f);
    public GameObject CoinCo;
    Vector3 CoRo;

    private void OnEnable()
    {
        this.transform.localPosition = new Vector3(0, 17.5f, 0);
        Invoke("Off", 1.5f);
    }

    void Off()
    {
        this.gameObject.SetActive(false);
    }

    void Start()
    {
    }

    IEnumerator coin()
    {

        while (true)
        {
            this.transform.position += new Vector3(0, -0.1f, 0);

            CoRo += new Vector3(0, 20f, 0);
            CoinCo.transform.rotation = Quaternion.Euler(CoRo.x, CoRo.y, CoRo.z);
            this.transform.localScale += new Vector3(-0.013f, -0.013f, -0.013f);

            yield return delay;
        }
    }

    void Update()
    {
        this.transform.Rotate(4, 0, 0);
        this.transform.localPosition -= new Vector3(0, 0.1f, 0);
    }
}