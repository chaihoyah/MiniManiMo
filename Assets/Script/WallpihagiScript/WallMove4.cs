using UnityEngine;
using System.Collections;

public class WallMove4 : MonoBehaviour
{

    void Update()
    {
        if (!WallCount.isFinished)
        {
            if (RoundController_DDR.round.Equals(1))
            {
                if (WallCount.Wallcnt.Equals(0))//1
                {
                    this.transform.Translate(0, 0, 0.18f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 20)
                {
                    this.transform.Translate(0, 0, 0.18f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 40)//2
                {
                    this.transform.Translate(0, 0, 0.22f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 70)//3
                {
                    this.transform.Translate(0, 0, 0.27f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 100)//4
                {
                    this.transform.Translate(0, 0, 0.3f * 1.1f);
                }
                else
                {
                    this.transform.Translate(0, 0, 0.33f * 1.1f);
                }
            }
            else if (RoundController_DDR.round.Equals(2))
            {
                if (WallCount.Wallcnt.Equals(0))//1
                {
                    this.transform.Translate(0, 0, 0.18f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 20)
                {
                    this.transform.Translate(0, 0, 0.18f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 40)//2
                {
                    this.transform.Translate(0, 0, 0.22f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 70)//3
                {
                    this.transform.Translate(0, 0, 0.27f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 100)//4
                {
                    this.transform.Translate(0, 0, 0.3f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 130)//5
                {
                    this.transform.Translate(0, 0, 0.33f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 180)//6
                {
                    this.transform.Translate(0, 0, 0.35f * 1.1f);
                }
                else//7
                {
                    this.transform.Translate(0, 0, 0.37f * 1.1f);
                }
            }
            else if (RoundController_DDR.round.Equals(3))
            {
                if (WallCount.Wallcnt <= 20)//3
                {
                    this.transform.Translate(0, 0, 0.27f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 40)//4
                {
                    this.transform.Translate(0, 0, 0.3f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 70)//5
                {
                    this.transform.Translate(0, 0, 0.33f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 100)//6
                {
                    this.transform.Translate(0, 0, 0.35f * 1.1f);
                }
                else if (WallCount.Wallcnt <= 130)//7
                {
                    this.transform.Translate(0, 0, 0.37f * 1.1f);
                }
                else
                {
                    this.transform.Translate(0, 0, 0.4f * 1.1f);
                }
            }
            if (this.transform.position.z >= 2.8)
            {
                PlayerCollids.SoundM.PlayPizzaMove();
                if (this.gameObject.transform.GetComponent<RandomPizzaScore>().isRandom) WallCount.Score += 5 * PlayerCollids.WallPlusScore;
                else WallCount.Score += PlayerCollids.WallPlusScore;
                Wall.objPoolArr[4].PushObject(this.gameObject);
                WallCount.Wallcnt++;
            }

        }
    }
}
