using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetReady : MonoBehaviour
{
    public GameObject Player;

    public Button RightClick;
    public Button LeftClick;
    Vector3 ZeroVec;

    public GameObject StartImg;

    public SoundManager SoundM;
    // Use this for initialization


    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        ZeroVec = Vector3.zero;
            //카메라
            SoundM.PlatStartingSound();
            yield return new WaitForSeconds(2.9f);

            RightClick.gameObject.SetActive(true);
            LeftClick.gameObject.SetActive(true);
            StartImg.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            StartImg.SetActive(false);

    }

}
