using UnityEngine;
using System.Collections;

public class FireBallScript : MonoBehaviour {

    private GameObject stone;
    public GameObject FireRegion;

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        stone = this.gameObject;
        Vector3 firePos;

            if(other.gameObject.CompareTag("floor"))
            {
                firePos = new Vector3(stone.transform.position.x,0.4f,stone.transform.position.z);
                FireRegion.transform.position = firePos;
                Instantiate(FireRegion, firePos, new Quaternion(0, 0, 0, 0));
                Destroy(this,3);
                
            }

            else if(other.gameObject.CompareTag("wolf"))
            {
                firePos = new Vector3(stone.transform.position.x, 2, stone.transform.position.z);
                FireRegion.transform.position = firePos;
                Instantiate(FireRegion,firePos, new Quaternion(0,0,0,0));
                Destroy(this,3);
            }
        
    }

}
