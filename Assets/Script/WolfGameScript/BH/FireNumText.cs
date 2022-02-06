using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireNumText : MonoBehaviour {
    public BHTreasureRes Treasure;
    public Text tt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        tt.text = "X " + Treasure.FireNum.ToString();
	}
}
