using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrollScript : MonoBehaviour {

    public GameObject ScrollView;

    public Image swim;
    public Image ddr;
    public Image wolf;

    public void SwimShop()
    {
        swim.enabled = true;
        ddr.enabled = false;
        wolf.enabled = false;
        ScrollView.transform.localPosition = new Vector3(0, -675, 0);
    }

    public void DDRShop()
    {
        swim.enabled = false;
        ddr.enabled = true;
        wolf.enabled = false;
        ScrollView.transform.localPosition = new Vector3(0, 25, 0);
    }

    public void WolfShop()
    {
        swim.enabled = false;
        ddr.enabled = false;
        wolf.enabled = true;
        ScrollView.transform.localPosition = new Vector3(0, 675, 0);
    }

    void Update()
    {
        if(ScrollView.transform.localPosition.y < -200)
        {
            swim.enabled = true;
            ddr.enabled = false;
            wolf.enabled = false;
        }
        else if(ScrollView.transform.localPosition.y < 500)
        {
            swim.enabled = false;
            ddr.enabled = true;
            wolf.enabled = false;
        }
        else
        {
            swim.enabled = false;
            ddr.enabled = false;
            wolf.enabled = true;
        }
    }
}
