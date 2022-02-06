using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class backScript : MonoBehaviour {

    // Use this for initialization

    public Button back;

	public void Back()
    {
        JudgeScript.shop = false;
        SceneManager.LoadScene(1);
    }
}
