using UnityEngine;
using System.Collections;

public class DDangCoin : MonoBehaviour {
    public MonsterRes MonRes;
    public SoundManager SoundM;
    Vector3 Go;
    public JamsuCoinEffect JCE;

    // Use this for initialization

    void Start () {
        JCE = GameObject.Find("Plane").GetComponent<JamsuCoinEffect>();
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
        MonRes = GameObject.Find("MonsRes").GetComponent<MonsterRes>();
        Go = new Vector3(0, 0.02f, 0);
    }
    private void OnEnable()
    {
        JCE = GameObject.Find("Plane").GetComponent<JamsuCoinEffect>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("DDangPetOne"))
        {
            SoundM.PlayCoin();
            JCE.FullChk();
            DDangGlo.Money += 10;
            MonRes.CoinPool.PushObject(this.gameObject);
        }
    }

    void Update()
    {
        if (!DDangGlo.isFinished)
        {
            this.transform.position += Go;
        }
        if(this.transform.position.y>0.1)
        {
            MonRes.CoinPool.PushObject(this.gameObject);
        }
    }

}
