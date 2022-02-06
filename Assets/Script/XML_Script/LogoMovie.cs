using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoMovie : MonoBehaviour {

	public Image[] movie = new Image[50];
	void Start () {
        StartCoroutine(Movie());
	}
	IEnumerator Movie()
    {
        for(int i = 0;i<50;i++)
        {
            movie[i].enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
    }
	
}
