using UnityEngine;
using System.Collections;

public class DDangSpeedMon : MonoBehaviour {
    public ObjectPooling SpeedMon;
    public GameObject SpeedShark;
    public GameObject Warning;

    public SoundManager SoundM;
    public GameObject Panda;
    float[] RanArray = new float[8];
    // Use this for initialization
    IEnumerator Start () {
        yield return new WaitForSeconds(0.5f);
        SpeedMon = new ObjectPooling();
        SpeedMon.InitPool(SpeedShark, 3);

        RanArray[0] = -1.51f;
        RanArray[1] = -1.025f;
        RanArray[2] = -0.582f;
        RanArray[3] = -0.145f;
        RanArray[4] = 0.346f;
        RanArray[5] = 0.744f;
        RanArray[6] = 1.148f;
        RanArray[7] = 1.464f;


        if (PlayerPrefs.GetInt("SwimShoes1").Equals(2))
        {
            Panda = GameObject.Find("GanziPan");
        }

        else if (PlayerPrefs.GetInt("SwimShoes2").Equals(2))
        {
            Panda = GameObject.Find("Speed1Pan");
        }
        else if (PlayerPrefs.GetInt("SwimShoes3").Equals(2))
        {
            Panda = GameObject.Find("Speed2Pan");

        }
        else if (PlayerPrefs.GetInt("SwimUpgrade").Equals(1))
        {
            Panda = GameObject.Find("DDongPan");

        }
        else
        {
            Panda = GameObject.Find("Panda");
        }

        if(!JamSoo_Tutorial.isPanTuto)
        StartCoroutine(MonRes());
    }

    IEnumerator MonRes()
    {
        Vector3 MonPos = Vector3.zero;
        yield return new WaitForSeconds(5f);
        while(true)
        {
            //나온다는 표시 넣기
            RandomArray();
            MonPos = new Vector3(Panda.transform.position.x, -2f, Panda.transform.position.z);
            Warning.transform.position = MonPos + new Vector3(0, 0.2f, 0);
            Warning.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(false);
            SoundM.PlayJamsuMonster();

            ObjectPop(SpeedMon.PopObject(), MonPos);
            SoundM.PlayJamsuSpeedStart();

            if (DDangGlo.Level.Equals(1))
            {
                yield return new WaitForSeconds(9f);
            }
            else if (DDangGlo.Level.Equals(2))
            {
                yield return new WaitForSeconds(8f);
            }
            else if (DDangGlo.Level.Equals(3))
            {
                yield return new WaitForSeconds(6f);
            }
            else
            {
                yield return new WaitForSeconds(5f);
            }
        }
    }



    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }


    void RandomArray()
    {
        for (int i = 0; i < 8; i++)
        {
            int RanNum = Random.Range(i, 8);

            float tmp = RanArray[RanNum];
            RanArray[RanNum] = RanArray[i];
            RanArray[i] = tmp;
        }
    }
}
