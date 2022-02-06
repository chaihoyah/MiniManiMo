using UnityEngine;
using System.Collections;

public class DDangSpeedMonMove : MonoBehaviour {

    private DDangSpeedMon Mon;

    Vector3 Go;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PandaDown.isSpurtOn)
            {
                Mon.SpeedMon.PushObject(this.gameObject);
                DDangGlo.Gold += 2;
                DDangGlo.Point += 30;
            }
        }

    }


    IEnumerator Right()
    {
        while (true)
        {

            if (this.transform.position.y >= 0f)
            {
                Mon.SpeedMon.PushObject(this.gameObject);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        if (!DDangGlo.isFinished)
        {
            this.transform.position += Go;
        }
    }

    // Use this for initialization
    void Start()
    {
        Go = new Vector3(0, 0.06f, 0);
        Mon = GameObject.Find("MonsRes").GetComponent<DDangSpeedMon>();

        StartCoroutine(Right());
    }
}
