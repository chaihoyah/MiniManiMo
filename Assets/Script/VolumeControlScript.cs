using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeControlScript : MonoBehaviour {

    public static float Volume = 1.0f;
    public Slider VolumeSlider;

    private void Awake()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("sound");
        Volume = PlayerPrefs.GetFloat("sound");
    }

    public void SetVol()
    {
        PlayerPrefs.SetFloat("sound", Volume);
    }
    // Update is called once per frame
    void Update () {
        Volume = VolumeSlider.value;
	}
}
