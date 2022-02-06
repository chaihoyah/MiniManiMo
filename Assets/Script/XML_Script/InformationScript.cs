using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationScript : MonoBehaviour
{

    public Canvas OpenMenu;
    public Canvas Inform_swim;
    public Canvas Inform_ddr;
    public Canvas Inform_wolf;

    bool exit = false;

    public void Inform_Swim()
    {
        OpenMenu.enabled = false;
        Inform_swim.enabled = true;
        exit = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine(Touch_Inform());
    }

    public void Inform_DDR()
    {
        OpenMenu.enabled = false;
        Inform_ddr.enabled = true;
        exit = true;
        StartCoroutine(Touch_Inform());
    }

    public void Inform_Wolf()
    {
        OpenMenu.enabled = false;
        Inform_wolf.enabled = true;
        exit = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine(Touch_Inform());
    }

    IEnumerator Touch_Inform()
    {
        yield return new WaitForSeconds(1);
        while (exit)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.touchCount > 0)
                {
                    Screen.orientation = ScreenOrientation.Portrait;
                    exit = false;
                        OpenMenu.enabled = true;
                        Inform_swim.enabled = false;
                        Inform_ddr.enabled = false;
                        Inform_wolf.enabled = false;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForEndOfFrame();
    }
}