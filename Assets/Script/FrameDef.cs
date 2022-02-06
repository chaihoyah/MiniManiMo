using UnityEngine;
using System.Collections;

public class FrameDef : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Application.targetFrameRate = 40;
	}
}
