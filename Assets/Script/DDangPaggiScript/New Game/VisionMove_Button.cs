using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VisionMove_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image ButtonImage;
    public static GameObject Player;
    public GameObject visionSprite;
    public GameObject visionEffect1;
    public GameObject visionEffect2;
    public GameObject PandaBasic;
    public GameObject PandaNoShoes;
    public GameObject Panda1;
    public GameObject Panda2;
    public GameObject Panda3;
    public bool press = false;
    bool visioning = false;

    void Awake()
    {
        ButtonImage = this.GetComponent<Image>();
        if (PlayerPrefs.GetInt("SwimShoes1").Equals(2))
            Player = Panda1;
        else if (PlayerPrefs.GetInt("SwimShoes2").Equals(2))
            Player = Panda2;
        else if (PlayerPrefs.GetInt("SwimShoes3").Equals(2))
            Player = Panda3;
        else if (PlayerPrefs.GetInt("SwimUpgrade").Equals(2))
            Player = PandaBasic;
        else
            Player = PandaNoShoes;
        Player.SetActive(true);
        visionSprite = Player.transform.FindChild("VisionSprite").gameObject;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        if (press)
        {
            press = false;
            Vector3 pos = Player.transform.position;
            Player.transform.position = visionSprite.transform.position;
            visionSprite.transform.localPosition = new Vector3(0, 0, 0);
            visionSprite.SetActive(false);
            StartCoroutine(VisionEffect(pos));
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        if (!visioning)
        {
            visionSprite.SetActive(true);
            press = true;
            StartCoroutine(ButtonPress());
        }
    }

    IEnumerator ButtonPress()
    {
        int count = 0;
        while (press)
        {
            if (count < 20)
            {
                visionSprite.transform.Translate(0, -1f, 0);
                count++;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator VisionEffect(Vector3 pos)
    {
        visioning = true;
        visionEffect1.transform.position = pos;
        visionEffect2.transform.position = pos;
        visionEffect1.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        visionEffect1.SetActive(false);
        visionEffect2.SetActive(true);
        Vector3 scale = visionEffect2.transform.localScale;
        for (int i = 0; i < 10; i++)
        {
            visionEffect2.transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
            yield return new WaitForEndOfFrame();
        }
        visionEffect2.SetActive(false);
        visionEffect2.transform.localScale = scale;
        visioning = false;
    }
}