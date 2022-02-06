using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOAnimYo : MonoBehaviour {
    public GameObject PP;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(2f);
        PP.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
