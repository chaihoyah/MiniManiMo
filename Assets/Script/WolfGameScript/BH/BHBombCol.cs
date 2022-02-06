using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHBombCol : MonoBehaviour {
    void OnEnable()
    {
        StartCoroutine(TurnOff());
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(0.4f);
        this.gameObject.SetActive(false);
    }
}
