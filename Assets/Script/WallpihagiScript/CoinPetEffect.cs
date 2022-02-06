using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPetEffect : MonoBehaviour
{

    public Animator animation;
    bool isCollide = false;

    void Start()
    {
        animation = this.transform.GetChild(1).transform.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            if (!isCollide)
            {
                print("h");
                isCollide = true;
                animation.SetBool("isDo", true);
                StartCoroutine(RotateStop());
            }
        }
    }

    IEnumerator RotateStop()
    {
        yield return new WaitForSeconds(0.58f);
        animation.SetBool("isDo", false);
        isCollide = false;
    }
}