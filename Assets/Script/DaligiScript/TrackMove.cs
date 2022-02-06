using UnityEngine;
using System.Collections;

public class TrackMove : MonoBehaviour {
    public GameObject Track;
    Vector3 NowPos= Vector3.zero;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(1f);
        NowPos = Track.transform.position;
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            NowPos = NowPos - new Vector3(817, 0, 0);
            Track.transform.position = NowPos;
        }
    }


}
