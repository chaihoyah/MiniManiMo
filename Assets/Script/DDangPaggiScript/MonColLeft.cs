using UnityEngine;
using System.Collections;

public class MonColLeft : MonoBehaviour {
    public GameObject LeftMon;
    private MonsterRes Mon;
    public JamsuCoinEffect JCE;

    Vector3 Go;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PandaDown.isSpurtOn)
            {
                Mon.MonPool[1].PushObject(this.gameObject);
                JCE.FullChkGold();
                DDangGlo.Gold += 1;
                DDangGlo.Point += 30;
            }
        }

    }


    IEnumerator Right()
    {
        while (true)
        {

            if (LeftMon.transform.position.y >= 0f)
            {
                Mon.MonPool[1].PushObject(LeftMon.gameObject);
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
            else if(MonsterRes.levelIdx < 9)
            {
                Go = new Vector3(0, 0.033f, 0);
            }
            else if(MonsterRes.levelIdx <12)
            {
                Go = new Vector3(0, 0.037f, 0);
            }
            else
            {
                Go = new Vector3(0, 0.042f, 0);
            }
            LeftMon.transform.position += Go;
        }
    }

    // Use this for initialization

    private void Awake()
    {
        JCE = GameObject.Find("Plane").GetComponent<JamsuCoinEffect>();
    }
    void Start()
    {
        Go = new Vector3(0, 0.03f, 0);
        Mon = GameObject.Find("MonsRes").GetComponent<MonsterRes>();
        
        StartCoroutine(Right());
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }
}
