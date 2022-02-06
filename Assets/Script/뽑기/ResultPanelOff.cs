using UnityEngine;
using System.Collections;

public class ResultPanelOff : MonoBehaviour {
    public GameObject Panel;

    public void Click()
    {
        Panel.gameObject.SetActive(false);
    }
}
