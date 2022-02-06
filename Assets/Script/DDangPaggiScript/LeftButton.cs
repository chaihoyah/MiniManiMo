using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeftButton : MonoBehaviour {
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
            StartCoroutine(Tuto_LeftMove());
        }
        else StartCoroutine(LeftMove());
    }
    IEnumerator LeftMove()
    {
        Vector3 PlayerPos = Panda.transform.position;
        if (PlayerPos.z <= -1.5f)
        {
            Panda.transform.rotation = rotatOne;

        }
        else
        {
            Panda.transform.rotation = rotatTwo;
            Panda.transform.position += new Vector3(0, 0, -0.2f);

            yield return null;
        }
        ButtonImg.sprite = PanButTwo;
        yield return new WaitForSeconds(0.1f);
        ButtonImg.sprite = PanButOne;
        
        yield return new WaitForEndOfFrame();

    }

    IEnumerator Tuto_LeftMove()
    {
        Tut.TutoBool[0] = true;
        Vector3 PlayerPos = Panda.transform.position;
        if (PlayerPos.z <= -1.5f)
        {
            Panda.transform.rotation = rotatOne;

        }
        else
        {
            Panda.transform.rotation = rotatTwo;
            Panda.transform.position += new Vector3(0, 0, -0.2f);

            yield return null;
        }
        ButtonImg.sprite = PanButTwo;
        yield return new WaitForSeconds(0.1f);
        ButtonImg.sprite = PanButOne;

        yield return new WaitForEndOfFrame();

    }

}
