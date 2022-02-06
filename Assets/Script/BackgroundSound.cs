using UnityEngine;
using System.Collections;

public class BackgroundSound : MonoBehaviour {

    public AudioSource myAudio;

	// Update is called once per frame
	void Update () {
        myAudio.volume = VolumeControlScript.Volume;
	}
}
