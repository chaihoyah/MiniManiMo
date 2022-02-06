using UnityEngine;
using System.Collections;

public class DDangAir : MonoBehaviour
{
    public MonsterRes MonRes;
    public AirScript Air;
    public SoundManager SoundM;
    Vector3 Go;

    // Use this for initialization
    void Start()
    {
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
        Air = GameObject.Find("AirBar").GetComponent<AirScript>();
        MonRes = GameObject.Find("MonsRes").GetComponent<MonsterRes>();
        Go = new Vector3(0, 0.02f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("DDangPetOne"))
        {
            SoundM.PlayDDR();
            if(Air.AirState<0.840f)
            Air.AirState += 0.1f;
            MonRes.AirPool.PushObject(this.gameObject);
        }
    }

    void Update()
    {
        if (!DDangGlo.isFinished)
        {
            this.transform.position += Go;
        }
        if (this.transform.position.y > 0.1)
        {
            MonRes.AirPool.PushObject(this.gameObject);
        }
    }

}
