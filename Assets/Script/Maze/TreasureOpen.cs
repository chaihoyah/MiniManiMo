using UnityEngine;
using System.Collections;

public class TreasureOpen : MonoBehaviour {
    public Animator TreasureAnim;

	// Use this for initialization
	void Start () {
        TreasureAnim = this.GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            TreasureAnim.SetBool("TreasureCol", true);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
