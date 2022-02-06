using UnityEngine;
using System.Collections;

public class LiOBCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(StartFire());
	}

    IEnumerator StartFire()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update () {
	
	}
}
