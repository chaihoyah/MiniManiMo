using UnityEngine;
using System.Collections;

public class PizzaColid3 : MonoBehaviour
{

    void OnTriggerEnter(Collider order)
    {
        if (!DDRTutorial.tutorial)
        {
            if (order.CompareTag("Player"))
            {
                if (WallpihagiSpurt.isSpurt)
                {
                    Wall.objPoolArr[3].PushObject(this.transform.parent.gameObject);
                    WallCount.Score += 10;
                    WallCount.Point += 10;
                }

            }
        }
    }
}