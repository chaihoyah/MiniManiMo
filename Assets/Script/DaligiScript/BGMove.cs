using UnityEngine;
using System.Collections;

public class BGMove : MonoBehaviour {
    Vector3 NowPos;

    private void Awake()
    {
        NowPos = this.transform.position;
    }
    // Use this for initialization
    IEnumerator Start () {
        yield return new WaitForSeconds(0.8f);
	}
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            NowPos = NowPos - new Vector3(600, 0, 0);
            this.transform.position = NowPos;
 
        }
    }
}
