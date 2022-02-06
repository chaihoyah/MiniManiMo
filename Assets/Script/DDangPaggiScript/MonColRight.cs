using UnityEngine;
using System.Collections;

public class MonColRight : MonoBehaviour {
    public GameObject RightMon;
    private MonsterRes Mon;
    public JamsuCoinEffect JCE;

    Vector3 Go;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (PandaDown.isSpurtOn)
            {
                Mon.MonPool[0].PushObject(this.gameObject);
                JCE.FullChkGold();
                DDangGlo.Gold += 1;
                DDangGlo.Point += 30;
            }
        }
    }
    IEnumerator JellyGoUp()
    {
        while(true)
        {
            if (RightMon.transform.position.y >= 0f)
            {
                Mon.MonPool[0].PushObject(RightMon.gameObject);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        if (!DDangGlo.isFinished)
        {
            if (MonsterRes.levelIdx < 5)
            {
                Go = new Vector3(0, 0.03f, 0);
            }
            else if (MonsterRes.levelIdx < 9)
            {
                Go = new Vector3(0, 0.033f, 0);
            }
            else if (MonsterRes.levelIdx < 12)
            {
                Go = new Vector3(0, 0.037f, 0);
            }
            else
            {
                Go = new Vector3(0, 0.042f, 0);
            }
            RightMon.transform.position += Go;
        }
    }

    // Use this for initialization
    private void Awake()
    {
        JCE = GameObject.Find("Plane").GetComponent<JamsuCoinEffect>();
    }

    void Start () {
        Mon = GameObject.Find("MonsRes").GetComponent<MonsterRes>();
        Go = new Vector3(0, 0.03f,0);
        StartCoroutine(JellyGoUp());
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }
}
