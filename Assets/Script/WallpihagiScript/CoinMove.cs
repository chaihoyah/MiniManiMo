using UnityEngine;
using System.Collections;

public class CoinMove : MonoBehaviour
{

    public GameObject coinCont;
    public CoinRotate CoRo;


    void Update()
    {
        if (!WallCount.isFinished)
        {
            if (!CoRo.CoinMove)
            {
                if (WallCount.Wallcnt.Equals(0))
                {
                    coinCont.transform.Translate(0, 0, 0.2f);
                }
                else if (WallCount.Wallcnt <= 10)
                {
                    coinCont.transform.Translate(0, 0, 0.2f);
                }
                else if (WallCount.Wallcnt <= 20)
                {
                    coinCont.transform.Translate(0, 0, 0.23f);
                }
                else if (WallCount.Wallcnt <= 30)
                {
                    coinCont.transform.Translate(0, 0, 0.25f);
                }
                else if (WallCount.Wallcnt <= 40)
                {
                    coinCont.transform.Translate(0, 0, 0.27f);
                }
                else
                {
                    coinCont.transform.Translate(0, 0, 0.3f);
                }
                if (coinCont.transform.position.z >= 2.8)
                {
                    CoinRespawn.CoinPool.PushObject(this.gameObject);
                }
            }
        }
    }
}
