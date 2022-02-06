using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItemPPa : MonoBehaviour {

    // Use this for initialization
    public GameObject[] II = new GameObject[200];
    public GameObject List;
    public GameObject scroll;
    public GameObject SP;
    public GameObject panel;

    public Button But1;
    public Button But2;
    public Button But3;
    public Button But4;

    public Text Myname;
    public Text TotalScore;

    void Start () {
        Myname.text = PlayerPrefs.GetString("Username");
        TotalScore.text = PlayerPrefs.GetInt("TotalScore").ToString();
        panel.SetActive(false);
        /**for (int i = 0; i < 200; i++)
        {
            II[i] = Instantiate(List, new Vector3(0, 330 - 20 * i, 0), new Quaternion(0, 0, 0, 0), scroll.transform);
            II[i].transform.localPosition = (new Vector3(0, 4560 - 40 * i, 0));
        }**/

    }

    public void SetList()
    {
        But1.interactable = false;
        But2.interactable = false;
        But3.interactable = false;
        But4.interactable = false;
        panel.SetActive(true);
    }

    public void Back()
    {
        SP.transform.localPosition = new Vector3(0, -4750.17f, 0);
        But1.interactable = true;
        But2.interactable = true;
        But3.interactable = true;
        But4.interactable = true;
        panel.SetActive(false);
    }

}
