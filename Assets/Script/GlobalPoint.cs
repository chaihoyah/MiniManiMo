using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalPoint : MonoBehaviour
{

    public static int ChongPoint;
    public static int GoldPoint;
    public Text GloPo;
    public Text GolPo;

    void Awake()
    {
        PlayerPrefs.SetInt("silver", 100000);
        GlobalPoint.ChongPoint = PlayerPrefs.GetInt("silver");
        PlayerPrefs.SetInt("gold", 10000);
        GlobalPoint.GoldPoint = PlayerPrefs.GetInt("gold");
    }

    // Update is called once per frame
    void Update()
    {
        GloPo.text = ChongPoint.ToString();
        GolPo.text = GoldPoint.ToString();
        //
    }
}