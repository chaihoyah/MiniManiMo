using UnityEngine;
using System.Collections;

public class ObjectNumber : MonoBehaviour
{

    public static int ObjNum;
    public static bool wallpop;
    public static bool coinpop;
    public static int randomCoin;

    void Start()
    {
        ObjNum = Random.Range(1, 3);
        randomCoin = Random.Range(1, 3);
        wallpop = true;
        coinpop = true;



    }
}