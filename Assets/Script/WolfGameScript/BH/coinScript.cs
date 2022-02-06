using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coinScript : MonoBehaviour {

    public Text coinText;
    public Text Gold;
    public static int coin = 0;
    public static int gold = 0;


	void Update () {
        coinText.text = coin.ToString();
        Gold.text = gold.ToString();
    }
}
