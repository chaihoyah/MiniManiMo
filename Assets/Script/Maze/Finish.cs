using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	public static int roundclear =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
        roundclear ++;
		//캔버스 점수 표시 등
	}
}
}