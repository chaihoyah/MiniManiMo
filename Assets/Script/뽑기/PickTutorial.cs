using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickTutorial : MonoBehaviour {
    public GameObject TT;
    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    public GameObject A5;
    public GameObject T1;
    public GameObject T2;
    public GameObject T3;
    public GameObject T4;
    public GameObject T5;
    public GameObject Stick;
    public Button But1;
    public Button But2;
    public Button But3;
    Vector3 StickPos;

    public Text Tut;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetInt("PickFirst") == 0)
        {
            StickPos = Stick.transform.position;
            But1.interactable = false;
            But2.interactable = false;
            But3.interactable = false;
            StartCoroutine(PickTu());
        }
    }


    IEnumerator PickTu()
    {
        Time.timeScale = 0.9f;

        TT.gameObject.SetActive(true);

        TT.SetActive(true);
        while (Input.touchCount == 0)
        {
            yield return new WaitForSeconds(0.5f);
        }
        TT.SetActive(false);
        yield return new WaitForSeconds(1f);
        T1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        A1.SetActive(true);
        yield return new WaitForSeconds(1f);
        A1.SetActive(false);
        yield return new WaitForSeconds(1f);
        A1.SetActive(true);
        yield return new WaitForSeconds(1f);
        A1.SetActive(false);
        while (Input.touchCount == 0)
        {
            yield return new WaitForSeconds(0.5f);
        }
        T1.SetActive(false);
        T2.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        A2.SetActive(true);
        yield return new WaitForSeconds(1f);
        A2.SetActive(false);
        yield return new WaitForSeconds(1f);
        A2.SetActive(true);
        yield return new WaitForSeconds(1f);
        A2.SetActive(false);
        yield return new WaitForSeconds(1f);
        int i = 0;
        while(i<22)
        {
            Stick.transform.position += new Vector3(0.4f, 0, 0);
            i++;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f);
        T2.SetActive(false);
        T3.SetActive(true);
        yield return new WaitForSeconds(1f);
        A3.SetActive(true);
        yield return new WaitForSeconds(1f);
        A3.SetActive(false);
        yield return new WaitForSeconds(1f);
        A3.SetActive(true);
        yield return new WaitForSeconds(1f);
        A3.SetActive(false);
        yield return new WaitForSeconds(1f);
        A4.SetActive(true);
        yield return new WaitForSeconds(1f);
        A4.SetActive(false);
        yield return new WaitForSeconds(1f);
        A4.SetActive(true);
        yield return new WaitForSeconds(1f);
        A4.SetActive(false);
        i = 0;
        while(i<10)
        {
            Stick.transform.position += new Vector3(0, 0.4f, 0);
            i++;
            yield return new WaitForEndOfFrame();
        }
        T3.SetActive(false);
        T4.SetActive(true);
        yield return new WaitForSeconds(2f);
        T4.SetActive(false);
        T5.SetActive(true);
        A5.SetActive(true);
        yield return new WaitForSeconds(1f);
        A5.SetActive(true);
        yield return new WaitForSeconds(1f);
        A5.SetActive(false);
        yield return new WaitForSeconds(1f);
        A5.SetActive(true);
        yield return new WaitForSeconds(1f);
        A5.SetActive(false);
        T5.SetActive(true);
        yield return new WaitForSeconds(2f);
        But1.interactable = true;
        But2.interactable = true;
        But3.interactable = true;
        Stick.transform.position = StickPos;
        PlayerPrefs.SetInt("PickFirst", 1);
    }
}
