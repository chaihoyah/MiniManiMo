using UnityEngine;
using System.Collections;

public class DDRPet : MonoBehaviour {
    public DDArrowRes DAR;

	// Use this for initialization
	void Start () {
	
	}

    IEnumerator DDRDes()
    {
        while(true)
        {

            yield return new WaitForSeconds(3);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
