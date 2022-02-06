using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeamProjectScript : MonoBehaviour {

    public Button Swim_Before;
    public Image Swim_After;
    public Image Swim_After2;
    public Button DDR_Before;
    public Image DDR_After;
    public Image DDR_After2;
    public Button Wolf_Before;
    public Image Wolf_After;
    public Image Wolf_After2;

    public GameObject Mini;
    public GameObject Mani;
    public GameObject Mo;

    public GameObject SwimBeam;
    public GameObject DDRBeam;
    public GameObject WolfBeam;


    public Animator ManiAni;

    public Image SwimBack;
    public Image DDRBack;
    public Image BHBack;

    bool swim = false, ddr = false, wolf = false;
    bool rig = true, lef = false;
    bool rig_swim = true, lef_swim = false;
    Vector3 Mipo, Mapo, Mopo;
    Quaternion MiniRot;
    void Start()
    {
        Mipo = Mini.transform.position;
        Mapo = Mani.transform.position;
        Mopo = Mo.transform.position;
        DDRChoose();
    }
	public void SwimChoose()
    {
        SwimBack.enabled = true;
        DDRBack.enabled = false;
        BHBack.enabled = false;
        Mini.SetActive(true);
        Mani.SetActive(false);
        Mo.SetActive(false);
        Mani.transform.position = Mapo;
        Mo.transform.position = Mopo;
        ddr = false;
        wolf = false;
        swim = true;
        Swim_Before.gameObject.SetActive(false);
        DDR_After.gameObject.SetActive(false);
        DDR_After2.gameObject.SetActive(false);
        DDR_Before.gameObject.SetActive(true);
        Wolf_After.gameObject.SetActive(false);
        Wolf_After2.gameObject.SetActive(false);
        Wolf_Before.gameObject.SetActive(true);
        StartCoroutine(ImageChange_Swim());
        StartCoroutine(Move_Mini());
        SwimBeam.SetActive(true);
        DDRBeam.SetActive(false);
        WolfBeam.SetActive(false);
    
    }
    
    public void DDRChoose()
    {
        SwimBack.enabled = false;
        DDRBack.enabled = true;
        BHBack.enabled = false;
        Mini.SetActive(false);
        Mani.SetActive(true);
        Mo.SetActive(false);
        Mini.transform.position = Mipo;
        Mo.transform.position = Mopo;
        swim = false;
        wolf = false;
        ddr = true;
        Swim_After.gameObject.SetActive(false);
        Swim_After2.gameObject.SetActive(false);
        Swim_Before.gameObject.SetActive(true);
        DDR_Before.gameObject.SetActive(false);
        Wolf_After.gameObject.SetActive(false);
        Wolf_After2.gameObject.SetActive(false);
        Wolf_Before.gameObject.SetActive(true);
        StartCoroutine(ImageChange_DDR());
        StartCoroutine(Move_Mani());
        SwimBeam.SetActive(false);
        DDRBeam.SetActive(true);
        WolfBeam.SetActive(false);

    }

    public void WolfChoose()
    {
        SwimBack.enabled = false;
        DDRBack.enabled = false;
        BHBack.enabled = true;
        Mini.SetActive(false);
        Mani.SetActive(false);
        Mo.SetActive(true);
        Mini.transform.position = Mipo;
        Mani.transform.position = Mapo;
        swim = false;
        ddr = false;
        wolf = true;
        Swim_After.gameObject.SetActive(false);
        Swim_After2.gameObject.SetActive(false);
        Swim_Before.gameObject.SetActive(true);
        DDR_After.gameObject.SetActive(false);
        DDR_After2.gameObject.SetActive(false);
        DDR_Before.gameObject.SetActive(true);
        Wolf_Before.gameObject.SetActive(false);
        StartCoroutine(ImageChange_Wolf());
        StartCoroutine(Move_Mo());
        SwimBeam.SetActive(false);
        DDRBeam.SetActive(false);
        WolfBeam.SetActive(true);

    }

    IEnumerator ImageChange_Swim()
    {
        while (swim)
        {
            Swim_After.gameObject.SetActive(true);
            Swim_After2.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (swim == false) break;
            Swim_After2.gameObject.SetActive(true);
            Swim_After.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ImageChange_DDR()
    {
        while(ddr)
        {
            DDR_After.gameObject.SetActive(true);
            DDR_After2.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (ddr == false) break;
            DDR_After2.gameObject.SetActive(true);
            DDR_After.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ImageChange_Wolf()
    {
        while (wolf)
        {
            Wolf_After.gameObject.SetActive(true);
            Wolf_After2.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (wolf == false) break;
            Wolf_After2.gameObject.SetActive(true);
            Wolf_After.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Move_Mini()
    {
        while (swim)
        {
            while (rig_swim && swim)
            {
                Mini.transform.position += new Vector3(0.05f, 0, 0);
                if (Mini.transform.position.x > 1.5)
                {
                    rig_swim = false;
                    lef_swim = true;
                    Mini.transform.Rotate(0, 0, 90);
                    break;
                }
                yield return new WaitForSeconds(0.01f);
            }
            while (lef_swim && swim)
            {
                Mini.transform.position += new Vector3(-0.05f, 0, 0);
                if (Mini.transform.position.x < -1.3)
                {
                    lef_swim = false;
                    rig_swim = true;
                    Mini.transform.Rotate(0, 0, -90);
                    break;
                }
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Move_Mani()
    {
        while(ddr)
        {
            yield return new WaitForSeconds(0.5f);
            if (ddr.Equals(false))
            {
                ManiAni.SetBool("fall", true);
                break;
            }
            ManiAni.SetBool("fall", false);
            ManiAni.SetBool("rightUp",true);
            yield return new WaitForSeconds(0.25f);
            if(ddr.Equals(false))
            {
                ManiAni.SetBool("fall", true);
                ManiAni.SetBool("rightUp", false);
                break;
            }
            ManiAni.SetBool("rightUp", false);
            ManiAni.SetBool("fall", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {
                break;
            }
            ManiAni.SetBool("fall", false);
            ManiAni.SetBool("leftUp", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {
                ManiAni.SetBool("fall", true);
                ManiAni.SetBool("leftUp", false);
                break;
            }
            ManiAni.SetBool("leftUp", false);
            ManiAni.SetBool("fall", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {
                break;
            }
            ManiAni.SetBool("fall", false);
            ManiAni.SetBool("rightDown", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {
                ManiAni.SetBool("fall", true);
                ManiAni.SetBool("rightDown", false);
                break;
            }
            ManiAni.SetBool("rightDown", false);
            ManiAni.SetBool("fall", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {
                ManiAni.SetBool("fall", true);
                break;
            }
            ManiAni.SetBool("fall", false);
            ManiAni.SetBool("center", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {
                ManiAni.SetBool("fall", true);
                ManiAni.SetBool("center", false);
                break;
            }
            ManiAni.SetBool("center", false);
            ManiAni.SetBool("fall", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {               
                break;
            }
            ManiAni.SetBool("fall", false);
            ManiAni.SetBool("leftDown", true);
            yield return new WaitForSeconds(0.25f);
            if (ddr.Equals(false))
            {
                ManiAni.SetBool("fall", true);
                ManiAni.SetBool("leftDown", false);
                break;
            }
            ManiAni.SetBool("leftDown", false);
            ManiAni.SetBool("fall", true);
        }
    }

    IEnumerator Move_Mo()
    {
       while(wolf)
        {
            while (rig && wolf)
            {
                Mo.transform.position += new Vector3(0.1f, 0, 0);
                if (Mo.transform.position.x > 1)
                {
                    rig = false;
                    lef = true;
                    Mo.transform.Rotate(0, 180, 0);
                    break;
                }
                yield return new WaitForSeconds(0.01f);
            }
            while (lef && wolf)
            {
                Mo.transform.position += new Vector3(-0.1f, 0, 0);
                if (Mo.transform.position.x < -1)
                {
                    lef = false;
                    rig = true;
                    Mo.transform.Rotate(0, 180, 0); break;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
