using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
    public GameObject StartImg;

	// Use this for initialization
	IEnumerator Start () {
        StartImg.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        StartImg.SetActive(false);
	}
}
