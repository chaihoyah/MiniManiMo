using UnityEngine;
using System.Collections;

public class EnptyCollider : MonoBehaviour
{

    public GameObject empty;
    public GameObject StartImg;
    public SoundManager SoundM;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.9f);
        SoundM.PlayStart();
        StartImg.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartImg.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallCollider"))
        {
            ObjNumChoose(Wall.round);
            ObjectNumber.randomCoin = Random.Range(1, 3);
            ObjectNumber.wallpop = true;
            ObjectNumber.coinpop = true;
        }
    }

    void ObjNumChoose(int round)
    {
        switch (round)
        {
            case 1: ObjectNumber.ObjNum = Random.Range(1, 3); break;
            case 2: ObjectNumber.ObjNum = Random.Range(1, 5); break;
            case 3: ObjectNumber.ObjNum = Random.Range(1, 6); break;
        }
    }
}