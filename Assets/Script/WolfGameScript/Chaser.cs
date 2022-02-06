using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {
    public GameObject arrowTip;
    public GameObject chaser;
	
	void Update () {
        chaser.transform.position = arrowTip.transform.position;
	
	}
}
