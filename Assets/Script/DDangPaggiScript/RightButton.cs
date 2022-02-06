using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RightButton : MonoBehaviour {
    public GameObject Panda;
    public GameObject PandaTwo;
    public GameObject Camera;
    public Animator PandaAnim;

    public Sprite PanButOne;
    public Sprite PanButTwo;
    public JamSoo_Tutorial Tut;
    Image ButtonImg;

    Quaternion rotatOne;
    Quaternion rotatTwo;

    // Use this for initialization
    void Start () {

        rotatTwo = PandaTwo.transform.rotation;
        rotatOne = Panda.transform.rotation;
        ButtonImg = this.GetComponent<Image>();
    }
    public void StartMove()
    {
        if(JamSoo_Tutorial.isPanTuto)
        {
            StartCoroutine(Tuto_RightMove());
        }
        else StartCoroutine(RightMove());
    }
    IEnumerator RightMove()
    {

        Vector3 PlayerPos = Panda.transform.position;
        if (PlayerPos.z >= 1.5f)
        {
            Panda.transform.rotation = rotatOne;

        }
        else
        {
            Panda.transform.rotation = rotatTwo;
            Panda.transform.position += new Vector3(0, 0, 0.2f);

        }
        ButtonImg.sprite = PanButTwo;
        yield return new WaitForSeconds(0.1f);
        ButtonImg.sprite = PanButOne;

        yield return new WaitForEndOfFrame();


    }

    IEnumerator Tuto_RightMove()
    {
        Tut.TutoBool[1] = true;
        Vector3 PlayerPos = Panda.transform.position;
        if (PlayerPos.z >= 1.5f)
        {
            Panda.transform.rotation = rotatOne;

        }
        else
        {
            Panda.transform.rotation = rotatTwo;
            Panda.transform.position += new Vector3(0, 0, 0.2f);

        }
        ButtonImg.sprite = PanButTwo;
        yield return new WaitForSeconds(0.1f);
        ButtonImg.sprite = PanButOne;

        yield return new WaitForEndOfFrame();


    }

}
