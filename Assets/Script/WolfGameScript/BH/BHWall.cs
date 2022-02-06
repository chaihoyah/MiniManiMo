using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHWall : MonoBehaviour {
    private int HitCount;
    GameObject WallOne;
    GameObject WallTwo;
    GameObject WallThree;
    public BHBulletControl BHC;

	// Use this for initialization
	void Start() {
        WallOne = this.transform.GetChild(0).gameObject;
        WallTwo = this.transform.GetChild(1).gameObject;
        WallThree = this.transform.GetChild(2).gameObject;
        BHC = GameObject.Find("WolfPool").GetComponent<BHBulletControl>();
    }

    private void OnEnable()
    {
        HitCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("wolf")|| other.tag.Equals("goldWolf"))
        {
            HitCnt();
        }
    }

    void HitCnt()
    {
        if(HitCount==0)
        {
            WallOne.SetActive(false);
            WallTwo.SetActive(true);
            HitCount++;
        }
        else if(HitCount==1)
        {
            WallTwo.SetActive(false);
            WallThree.SetActive(true);
            HitCount++;
        }
        else if(HitCount==2)
        {
            WallThree.SetActive(false);
            WallOne.SetActive(true);
            BHC.WallPool.PushObject(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
