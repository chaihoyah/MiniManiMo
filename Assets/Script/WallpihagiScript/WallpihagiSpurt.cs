using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WallpihagiSpurt : MonoBehaviour
{
    
    public static bool isSpurt = false;
    public bool isSpurtReady= false;
    public float FillAmt=0;
    public Image PartyImg;
    public SoundManager SoundM;
    Image img;
    Color PartyOne;
    Color PartyTwo;


    void Start()
    {
        img = this.GetComponent<Image>();
        PartyOne = new Color();
        PartyTwo = new Color();
        PartyOne = PartyImg.color;
        PartyTwo = new Color(PartyImg.color.r, PartyImg.color.g, PartyImg.color.b, (float)60 / 255);
        StartCoroutine(PartyImgFill());
    }

    public void StartSpurt()
    {
        if (FillAmt >= 1)
        {
            StartCoroutine(Spurt());
        }
    }

    IEnumerator Spurt()
    {

            SoundM.PlayStop();
            SoundM.PlayPartyTime();
            PartyImg.gameObject.SetActive(true);
            int i = 0;
            isSpurt = true;
            while (i < 50)
            {
                if (i > 35) PartyImg.color = PartyTwo;
                i++;
                yield return new WaitForSeconds(0.05f);
                PartyImg.color = PartyOne;
                yield return new WaitForSeconds(0.05f);
            }
            FillAmt = 0;
            img.fillAmount = FillAmt;
            PartyImg.gameObject.SetActive(false);
            isSpurt = false;
        SoundM.GetComponent<AudioSource>().Play();
    }


    IEnumerator PartyImgFill()
    {
        while(true)
        {
            FillAmt += 0.03f;
            if (FillAmt <= 1)
            {
                img.fillAmount = FillAmt;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
