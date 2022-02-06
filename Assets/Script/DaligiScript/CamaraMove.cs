using UnityEngine;
using System.Collections;

public class CamaraMove : MonoBehaviour {
    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        StartCoroutine(MoveCam());

	}
	
	// Update is called once per frame
    IEnumerator MoveCam()
    {
        while(true)
        {

            transform.position = player.transform.position + offset;


            yield return new WaitForEndOfFrame();
        }
    }

}
