using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public GameObject Pet;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            AttackPetScript.attack = false;
            this.gameObject.SetActive(false);
            this.transform.position = Pet.transform.position;
        }
    }

    private void Update()
    {
        if (this.transform.localPosition.x >= 73.5f)
        {
            this.transform.position = Pet.transform.position;
            this.gameObject.SetActive(false);
        }
    }
}
