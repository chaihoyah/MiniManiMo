using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionOfFunction_Shop : MonoBehaviour
{

    public GameObject ItemContainer;
    Item ItemScript;
    Button button;
    // Use this for initialization
    void Start()
    {
        ItemContainer = GameObject.Find("BuyCanvas");
        ItemScript = ItemContainer.transform.GetComponent<Item>();
        button = this.gameObject.transform.GetComponent<Button>();
        AddFunction();
    }

    private void AddFunction()
    {
        int num = 0;
        for (int i = 0; i < 17; i++)
        {
            if (ItemScript.Buttons[i] != null)
            {
                if (button.gameObject.name.Equals(ItemScript.Buttons[i].name + "(Clone)"))
                {
                    num = i;
                    ItemScript.Buttons[i] = button;
                    break;
                }
            }
        }
        switch (num)
        {
            case 0: button.onClick.AddListener(() => ItemScript.Buy_Pizza1()); break;
            case 1: button.onClick.AddListener(() => ItemScript.Buy_Pizza2()); break;
            case 2: button.onClick.AddListener(ItemScript.Buy_Pizza3); break;
            case 3: button.onClick.AddListener(ItemScript.Buy_DDRPet2); break;
            case 5: button.onClick.AddListener(ItemScript.Buy_DDRPet3); break;
            case 6: button.onClick.AddListener(ItemScript.Buy_SwimUpgrade); break;
            case 7: button.onClick.AddListener(() => ItemScript.Buy_SwimShoes1()); break;
            case 8: button.onClick.AddListener(ItemScript.Buy_SwimShoes2); break;
            case 9: button.onClick.AddListener(ItemScript.Buy_SwimShoes3); break;
            case 10: button.onClick.AddListener(ItemScript.Buy_SwimPet1); break;
            case 11: button.onClick.AddListener(ItemScript.Buy_SwimPet2); break;
            case 12: button.onClick.AddListener(ItemScript.Buy_WolfSpeed1); break;
            case 13: button.onClick.AddListener(ItemScript.Buy_WolfSpeed2); break;
            case 14: button.onClick.AddListener(ItemScript.Buy_WolfHp1Upgrade); break;
            case 15: button.onClick.AddListener(ItemScript.Buy_WolfHp2Upgrade); break;
            case 16: button.onClick.AddListener(ItemScript.Buy_WolfHp3Upgrade); break;

        }
    }
}