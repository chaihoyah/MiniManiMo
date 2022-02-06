using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BirdGun : MonoBehaviour {
    public GameObject LeftEnd;
    public GameObject CenterDol;
    public GameObject LeftOb;

    public GameObject RightEnd;
    public GameObject RightOb;

    public eEndMov Mov;
    public float Dolangle;
    public float ThrowPower;
    Vector2 OriginCenterPos;
    float Dis;
    float Dis2;
    float OriginDis;
    float OriginDis2;
	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(0.3f);
        OriginCenterPos = CenterDol.transform.position;
        OriginDis = Vector2.Distance(LeftEnd.transform.position, CenterDol.transform.position);
        OriginDis2 = Vector2.Distance(RightEnd.transform.position, CenterDol.transform.position);
        StartCoroutine(ScaleSel());
    }

    IEnumerator ScaleSel()
    {
        while(true)
        {
            if (Mov.isDrag)
            {
                float dX = LeftEnd.transform.position.x - CenterDol.transform.position.x;
                float dY = LeftEnd.transform.position.y - CenterDol.transform.position.y;

                float TX = RightEnd.transform.position.x - CenterDol.transform.position.x;
                float TY = RightEnd.transform.position.y - CenterDol.transform.position.y;

                float FX = OriginCenterPos.x - CenterDol.transform.position.x;
                float FY = OriginCenterPos.y - CenterDol.transform.position.y;

                float angleTwo;
                float angle;

                ThrowPower = Vector2.Distance(OriginCenterPos, CenterDol.transform.position);
                angle = Mathf.Atan2(-dY, -dX);

                angleTwo = Mathf.Atan2(-TY, TX);


                LeftOb.transform.rotation = Quaternion.Euler(0, 0, angle * (180 / Mathf.PI));
                Dolangle = Mathf.Atan2(-FY, -FX) * (180 / Mathf.PI);

                RightOb.transform.rotation = Quaternion.Euler(0, 0, -angleTwo * (180 / Mathf.PI));
                Dis = Vector2.Distance(LeftEnd.transform.position, CenterDol.transform.position);
                Dis2 = Vector2.Distance(RightEnd.transform.position, CenterDol.transform.position);


                LeftOb.transform.localScale = new Vector3((float)(1.13823 / OriginDis) * Dis, LeftOb.transform.localScale.y, LeftOb.transform.localScale.z);
                RightOb.transform.localScale = new Vector3((float)(1.13823 / OriginDis2) * Dis2, RightOb.transform.localScale.y, RightOb.transform.localScale.z);
            }

            yield return new WaitForEndOfFrame();
        }
    }
	

}
