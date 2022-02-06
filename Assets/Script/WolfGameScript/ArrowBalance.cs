using UnityEngine;
using System.Collections;

public class ArrowBalance : MonoBehaviour
{

    public static float speed;



    void Update()
    {

        switch (WolfGameRound.round)
        {
            case 1: speed = 1; break;
            case 2: speed = 1.4f; break;
            case 3: speed = 1.8f; break;
            case 4: speed = 2; break;
        }
    }
}
