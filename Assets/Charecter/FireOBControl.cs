using UnityEngine;
using System.Collections;

public class FireOBControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(StartFire());
	}

    IEnumerator StartFire()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

}
