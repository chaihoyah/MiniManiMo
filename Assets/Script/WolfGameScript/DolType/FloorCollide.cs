using UnityEngine;
using System.Collections;

public class FloorCollide : MonoBehaviour {
    public GameObject FireRegion;
    public GameObject Lightning;


	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stone"))
        {

        }
        if (other.CompareTag("fire"))
        {

            Vector3 firePos;
            firePos = new Vector3(other.transform.position.x, 0.4f, other.transform.position.z);
            FireRegion.transform.position = firePos;
            Instantiate(FireRegion, firePos, new Quaternion(0, 0, 0, 0));

        }

        else if(other.CompareTag("Lightning"))
        {
            Vector3 firePos;
            firePos = new Vector3(other.transform.position.x, 0, other.transform.position.z);
            Lightning.transform.position = firePos;
            Instantiate(Lightning, firePos, new Quaternion(0, 0, 0, 0));

        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
