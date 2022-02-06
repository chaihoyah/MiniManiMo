using UnityEngine;
using System.Collections;

public class IceDol : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartFire());
    }

    IEnumerator StartFire()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
