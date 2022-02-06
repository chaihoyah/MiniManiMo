using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WolfGetReady : MonoBehaviour {

    public Rigidbody PlayerRig;
    public GameObject[] Maps = new GameObject[3];
    private void Awake()
    {
        if(RoundController_Snow.Snow_map.Equals(1) || PlayerPrefs.GetInt("isWolfTuto").Equals(0))
        {
            Instantiate(Maps[0]);
        }
        else if(RoundController_Snow.Snow_map.Equals(2))
        {
            Instantiate(Maps[1]);
        }
        else
        {
            Instantiate(Maps[2]);
        }
    }
    private void Start()
    {
        StartCoroutine(FFF());
    }

    IEnumerator FFF()
    {
        PlayerRig.velocity = Vector3.zero;
        PlayerRig.angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
    }
}
