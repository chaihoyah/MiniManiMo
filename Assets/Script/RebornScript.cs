using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RebornScript : MonoBehaviour
{

    public static int rebornItem;//부활 아이템 갯수
    public static int game;//게임 종류(벽피하기-1,잠수하기-2,돌던지기-3)

    public static bool reborn = false;

    public AirScript Air;

    public Button RebornButton;

    int round;

    void Awake()
    {
        rebornItem = PlayerPrefs.GetInt("Reborn");
    }

    public void Reborn()//부활버튼
    {
        if (rebornItem > 0)
        {
            rebornItem -= 1;
            PlayerPrefs.SetInt("Reborn", rebornItem);
            round = Wall.round;
            switch (game)
            {
                case 1: round = Wall.round; reborn = true; WallCount.isFinished = false; SceneManager.LoadScene(2); Wall.round = round; break;
                case 2: SceneManager.LoadScene(3); reborn = true; DDangGlo.isFinished = false; Air.AirState = 0.8467f; Air.AirBar.transform.localScale = new Vector3(0.737f, 0.8467f, 1); break;
                case 3: round = WolfGameRound.round; reborn = true; ScoreScript.isFinished = false; SceneManager.LoadScene(6); WolfGameRound.round = round; break;
            }
        }

    }

}