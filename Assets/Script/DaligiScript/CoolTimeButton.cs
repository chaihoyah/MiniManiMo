using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoolTimeButton : MonoBehaviour {
    public Image img;
    public UnityEngine.UI.Button Attack;
    public float cooltime = 5.0f;
    public bool disableOnStart = false;
    float leftTime = 0.0f;
	// Use this for initialization

	void Start () {
        img = gameObject.GetComponent<Image>();
        Attack = gameObject.GetComponent<UnityEngine.UI.Button>();
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
                if (Attack)
                {
                    
                    Attack.enabled = true;
                    
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
        if (Attack)
            Attack.enabled = false;
    }
}
