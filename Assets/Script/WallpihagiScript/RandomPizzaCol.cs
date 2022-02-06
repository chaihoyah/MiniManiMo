using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPizzaCol : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Wall"))
        {
            other.transform.parent.transform.FindChild("FullPizza").gameObject.SetActive(false);
        }
    }
}
