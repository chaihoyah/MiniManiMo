using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWolfDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    private void OnEnable()
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2.5f);
        this.transform.position = new Vector3(-1, -22, -23);
        Destroy(this.gameObject);
    }
}
