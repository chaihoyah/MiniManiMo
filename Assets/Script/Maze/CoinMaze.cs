using UnityEngine;
using System.Collections;

public class CoinMaze : MonoBehaviour {
    public static int coin=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(TreasureBox.item==1){
        coin +=100;
		TreasureBox.item = 0;
	}
	}

}
