using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PickButtonPress : MonoBehaviour
{
    public GameObject bar;
    public GameObject Cube;
    public SoundManager SoundM;
    public static bool buttonPress = false;
    public static bool floorCol = false;
    bool back = false;

    public Button RightPress;
    public Button UpPress;

    bool isRightMove;
    bool isUpMove;


    void Start()
    {
        isRightMove = false;
        isUpMove = false;
        UpPress.enabled = false;
    }

    public void Press()
    {
        SoundM.PlayButton();
        buttonPress = true;
    }

    public void PressRightMove()
    {
        SoundM.PlayButton();
        if (isRightMove)
        {
            isRightMove = false;
            RightPress.enabled = false;
            if (PickGameTutorial.tutorial)
                PickGameTutorial.nice = true;
            else UpPress.enabled = true;
        }
        else isRightMove = true;
    }

    public void PressUpMove()
    {
        SoundM.PlayButton();
        if (isUpMove)
        {
            isUpMove = false;
            UpPress.enabled = false;
            StartCoroutine(GoFrontBack());
        }
        else isUpMove = true;
    }

    IEnumerator GoFrontBack()
    {
        while (bar.transform.position.z < -1)
        {
            bar.transform.position += new Vector3(0, 0, 0.1f);
            yield return new WaitForEndOfFrame();
        }

        while (bar.transform.position.z > -6.2f)
        {
            bar.transform.position -= new Vector3(0, 0, 0.1f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        if (PickGameTutorial.tutorial)
            PickGameTutorial.nice = true;
        RandomItem.panel = true;
    }

    void Update()
    {
        if(isRightMove&& bar.transform.position.x<4)
        {
            bar.transform.position += new Vector3(0.1f, 0, 0);
        }
        else if(isUpMove&& bar.transform.position.y<14)
        {
            bar.transform.position += new Vector3(0, 0.15f, 0);
        }
        if (buttonPress == true)
        {
            bar.transform.position += new Vector3(0, 0, 0.1f);
        }

        if (bar.transform.position.z >= 0)
        {
            buttonPress = false;
            back = true;
        }

        if (back == true)
        {
            bar.transform.position -= new Vector3(0, 0, 0.2f);

            if (bar.transform.position.z >= -10)
            {
                back = false;
            }
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && back==false && buttonPress == false)
            {
                StartCoroutine(WaitSec(2f));
                SceneManager.LoadScene(1);
            }
        }
    }

    IEnumerator WaitSec(float time)
    {
        yield return new WaitForSeconds(time);
    }
}