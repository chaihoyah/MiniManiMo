using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackKeyScript : MonoBehaviour {

    public Canvas OpenMenu;
    public Canvas Setting;
    public Canvas ShopChoose;
    public Canvas Shop_DDR;
    public Canvas Shop_Swim;
    public Canvas Shop_Wolf;
    public Canvas Inventory_DDR;
    public Canvas Inventory_Swim;
    public Canvas Inventory_Wolf;
    public Canvas MazeChoose;
    public Canvas DDRNotEnoughMoney;
    public Canvas WolfNotEnoughMoney;

    public SoundManager SoundM;

    public Button[] button = new Button[13];


    IEnumerator WaitSec(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (Inventory_Swim.enabled || Inventory_DDR.enabled || Inventory_Wolf.enabled)//인벤
                {
                    SoundM.PlayButton();
                    OpenMenu.enabled = true;
                    Inventory_DDR.enabled = false;
                    Inventory_Swim.enabled = false;
                    Inventory_Wolf.enabled = false;
                    for (int i = 0; i < 13; i++) button[i].interactable = true;
                }
                else if (Setting.enabled)//세팅
                {
                    SoundM.PlayButton();
                    Setting.enabled = false;
                    for (int i = 0; i < 13; i++) button[i].interactable = true;
                }
                else if (OpenMenu.enabled)//메뉴
                {
                    if (DDRNotEnoughMoney.enabled || WolfNotEnoughMoney.enabled)
                    {
                        SoundM.PlayButton();
                        DDRNotEnoughMoney.enabled = false;
                        WolfNotEnoughMoney.enabled = false;
                    }
                    else
                    {
                        SoundM.PlayButton();
                        Application.Quit();
                    }
                }
                else if (MazeChoose.enabled || ShopChoose.enabled)//샵선택,미로
                {
                    SoundM.PlayButton();
                    OpenMenu.enabled = true;
                    MazeChoose.enabled = false;
                    ShopChoose.enabled = false;
                }                
                else if (Shop_DDR.enabled || Shop_Swim.enabled || Shop_Wolf.enabled)//샵 -> 제거?
                {
                    SoundM.PlayButton();
                    ShopChoose.enabled = true;
                    Shop_DDR.enabled = false;
                    Shop_Swim.enabled = false;
                    Shop_Wolf.enabled = false;
                }
                StartCoroutine(WaitSec(2f));
                Input.GetKey(null);
            }
        }
    }
}
