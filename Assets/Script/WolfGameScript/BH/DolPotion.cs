using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DolPotion : MonoBehaviour {
    public int PotionNum;
    public PandaDie PanDie;
    Text PotionText;

    // Use this for initialization
    void Start()
    {
        PotionText = this.GetComponent<Text>();

        if(PlayerPrefs.GetInt("WolfPotion")>3)
        {
        PotionNum =3;
          }
        else{
            PotionNum = PlayerPrefs.GetInt("WolfPotion");
        }
        PotionText.text = "X" + PotionNum.ToString();
    }

    public void PotionUse()
    {
        if (PotionNum > 0)
        {
            if (PanDie.PanHP < PanDie.PanChongHP)
            {
                if (PanDie.PanHP >= PanDie.PanChongHP - 75)
                    PanDie.PanHP = PanDie.PanChongHP;
                else PanDie.PanHP += 75;

                int k = PlayerPrefs.GetInt("WolfPotion") - 1;
                PlayerPrefs.SetInt("WolfPotion", k);
                PotionNum--;
                PotionText.text = "X" + PotionNum.ToString();
            }
        }
    }

}
