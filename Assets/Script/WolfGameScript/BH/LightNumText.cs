using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightNumText : MonoBehaviour {
    public BHTreasureRes Treasure;
    public Text tt;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        tt.text = "X " + Treasure.LightningNum.ToString();
    }
}
