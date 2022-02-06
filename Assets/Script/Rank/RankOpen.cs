using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankOpen : MonoBehaviour {


    public Button But1;
    public Button But2;
    public Button But3;
    public Button But4;

	// Use this for initialization
	void Start () {
		
	}
	
	public void RankCheck()
    {
        But1.interactable = false;
        But2.interactable = false;
        But3.interactable = false;
        But4.interactable = false;
    }
}
