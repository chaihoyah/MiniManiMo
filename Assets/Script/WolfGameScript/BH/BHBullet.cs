using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHBullet : MonoBehaviour
{

    public BHBulletControl BHC;

    private void Start()
    {
        BHC = GameObject.Find("WolfPool").GetComponent<BHBulletControl>();
    }

    private void OnEnable()
    {
        StartCoroutine(MoveBul());
    }

    IEnumerator MoveBul()
    {
        int i = 0;
        while (i < 40 / WolfScript.Calculation)
        {
            i++;
            this.transform.Translate(0, 0, 0.7f * WolfScript.Calculation);
            yield return new WaitForEndOfFrame();
        }
        BHC.BullPool.PushObject(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Wall"))
        {
            BHC.BullPool.PushObject(this.gameObject);
        }

    }



}