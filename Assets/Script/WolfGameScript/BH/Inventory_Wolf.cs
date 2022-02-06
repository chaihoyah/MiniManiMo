using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory_Wolf : MonoBehaviour
{

    public GameObject WolfPanel;

    public Image[] NotHave = new Image[3];
    public Image BirdGun;
    public Image Ice;
    public Image Fire;
    public Image Thunder;
    public Image Potion;

    public Text HpText;
    public Text PotionText;

    void Awake()
    {
        BirdGun.enabled = false;
        Ice.enabled = false;
        Fire.enabled = false;
        Thunder.enabled = false;
        for (int i = 0; i < 4; i++) NotHave[i].enabled = false;
    }

    void Start()
    {
        NotHave[0].transform.position = BirdGun.transform.position;
        NotHave[1].transform.position = Ice.transform.position;
        NotHave[2].transform.position = Fire.transform.position;
        NotHave[3].transform.position = Thunder.transform.position;

        if (PlayerPrefs.GetInt("WolfBirdGun") == 1) BirdGun.enabled = true;
        else NotHave[0].enabled = true;
        if (PlayerPrefs.GetInt("WolfIce") == 1) Ice.enabled = true;
        else NotHave[1].enabled = true;
        if (PlayerPrefs.GetInt("WolfFire") == 1) Fire.enabled = true;
        else NotHave[2].enabled = true;
        if (PlayerPrefs.GetInt("WolfThunder") == 1) Thunder.enabled = true;
        else NotHave[3].enabled = true;

        PotionText.text = "X  " + PlayerPrefs.GetInt("WolfPotion").ToString();
        Potion.enabled = true;
        

        if (PlayerPrefs.GetInt("WolfHp3Upgrade") == 1) HpText.text = "HP + 300";
        else if (PlayerPrefs.GetInt("WolfHp2Upgrade") == 1) HpText.text = "HP + 200";
        else if (PlayerPrefs.GetInt("WolfHp1Upgrade") == 1) HpText.text = "HP + 100";
        else HpText.text = "HP + 0";
    }

    void Setting()
    {
        if (PlayerPrefs.GetInt("WolfBirdGun") == 1)
        {
            BirdGun.enabled = true;
            NotHave[0].enabled = false;
        }
        else NotHave[0].enabled = true;
        if (PlayerPrefs.GetInt("WolfIce") == 1)
        {
            Ice.enabled = true;
            NotHave[1].enabled = false;
        }
        else NotHave[1].enabled = true;
        if (PlayerPrefs.GetInt("WolfFire") == 1)
        {
            Fire.enabled = true;
            NotHave[2].enabled = false;
        }
        else NotHave[2].enabled = true;
        if (PlayerPrefs.GetInt("WolfThunder") == 1)
        {
            Thunder.enabled = true;
            NotHave[3].enabled = false;
        }
        else NotHave[3].enabled = true;

            PotionText.text = "X  " + PlayerPrefs.GetInt("WolfPotion").ToString();
            Potion.enabled = true;
        

        if (PlayerPrefs.GetInt("WolfHp3Upgrade") == 1) HpText.text = "HP + 300";
        else if (PlayerPrefs.GetInt("WolfHp2Upgrade") == 1) HpText.text = "HP + 200";
        else if (PlayerPrefs.GetInt("WolfHp1Upgrade") == 1) HpText.text = "HP + 100";
        else HpText.text = "HP + 0";
    }

    public void Inventory()
    {
        Setting();
    }

}