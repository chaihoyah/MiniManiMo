using UnityEngine;
using System.Collections;

public class PizzaColid2 : MonoBehaviour
{

    void OnTriggerEnter(Collider order)
    {
        if (!DDRTutorial.tutorial)
        {
            if (order.CompareTag("Player"))
            {
                if (WallpihagiSpurt.isSpurt)
                {
                    Wall.objPoolArr[2].PushObject(this.transform.parent.gameObject);
                    WallCount.Score += 10;
                    WallCount.Point += 10;
                }

            }
        }
    }
}