using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoolTimeButton1 : MonoBehaviour {
    public Image img;
    public UnityEngine.UI.Button Point;
    public float cooltime = 5.0f;
    public bool disableOnStart = false;
    float leftTime = 0.0f;
   // Use this for initialization

   void Start () {
        img = gameObject.GetComponent<Image>();
        Point = gameObject.GetComponent<UnityEngine.UI.Button>();
        if (disableOnStart)
            ResetCooltime();
        else img.fillAmount = 1;
   }
   
   // Update is called once per frame
   void Update () {
        if (leftTime > 0)
        {
            leftTime -= Time.deltaTime;
            if(leftTime < 0)
            {
                leftTime = 0;
                if (Point)
                {
                    
                    Point.enabled = true;
                    
                }
            }
            float ratio = 1.0f - (leftTime / cooltime);
            if (img)
                img.fillAmount = ratio;
        
        }
       
   }

    public bool CheckCooltime()
    {
        if (leftTime > 0) return false;
        else return true;
    }
    public void ResetCooltime()
    {
        leftTime = cooltime;
        if (Point)
            Point.enabled = false;
    }
}