using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//LoadScene(여기 수정)
public class OpenMenuScript : MonoBehaviour {

    public Button pick;
    public Button game;
    public Button exit;
    public Button settingButton;
    public Button back1;
    public Button back2;
    public Button back3;
    public Button back4;

    public Canvas OpenMenu;
    public Canvas GameSelect;
    public Canvas SettingMenu;
    //게임 들어가기 전
    public Canvas Wallpihagi;
    public Canvas Daligi;
    public Canvas Jamsu;
    public Canvas Wolf;
    public Canvas Maze;
    public SoundManager SoundM;
    bool menu,select,setting,intro;


    void Start()
    {
        if(JudgeScript.gameSelect == true)
        {
            SoundM.PlayButton();
            OpenMenu.enabled = false;
            GameSelect.enabled = true;
            SettingMenu.enabled = false;
            Wallpihagi.enabled = false;
            Daligi.enabled = false;
            Jamsu.enabled = false;
            Wolf.enabled = false;
            Maze.enabled = false;

            menu = false;
            select = true;
            setting = false;
            intro = false;
            JudgeScript.gameSelect = false;

        }
        else
        {
            OpenMenu.enabled = true;
            GameSelect.enabled = false;
            SettingMenu.enabled = false;
            Wallpihagi.enabled = false;
            Daligi.enabled = false;
            Jamsu.enabled = false;
            Wolf.enabled = false;
            Maze.enabled = false;

            menu = true;
            select = false;
            setting = false;
            intro = false;
        }
    }

    public void Pick()
    {
        SoundM.PlayButton();
        JudgeScript.gameSelect = false;
        SceneManager.LoadScene(1);
    }

    public void Game()
    {
        SoundM.PlayButton();
        OpenMenu.enabled = false;
        GameSelect.enabled = true;
        menu = false;
        select = true;
    }

    public void Game1()
    {
        SoundM.PlayButton();
        OpenMenu.enabled = false;
        GameSelect.enabled = false;
    }

    public void Game1Start()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitForSeconds(0.5f));
        menu = false;
        select = false;
        setting = false;
        intro = true;
        Wallpihagi.enabled = true;
    }

    public void GameDaligiStart()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitForSeconds(0.5f));
        menu = false;
        select = false;
        setting = false;
        intro = true;
        Daligi.enabled = true;
    }

    public void GameJamsooStart()
    {
        SoundM.PlayButton();
        JudgeScript.gameSelect = true;
        StartCoroutine(WaitForSeconds(0.5f));
        menu = false;
        select = false;
        setting = false;
        intro = true;
        Jamsu.enabled = true;
    }

    public void MazeStart()
    {
        SoundM.PlayButton();
        JudgeScript.gameSelect = true;
        StartCoroutine(WaitForSeconds(0.5f));
        menu = false;
        select = false;
        setting = false;
        intro = true;
        Maze.enabled = true;
    }

    public void WolfStart()
    {
        SoundM.PlayButton();
        JudgeScript.gameSelect = true;
        StartCoroutine(WaitForSeconds(0.5f));
        menu = false;
        select = false;
        setting = false;
        intro = true;
        Wolf.enabled = true;
    }
    public void Exit()
    {
        SoundM.PlayButton();
        Application.Quit();
    }


    public void Back2()
    {
        SoundM.PlayButton();
        OpenMenu.enabled = true;
        GameSelect.enabled = false;
        menu = true;
        select = false;
    }

    public void Back3()
    {
        SoundM.PlayButton();
        OpenMenu.enabled = false;
        GameSelect.enabled = true;
        SettingMenu.enabled = false;
        Wallpihagi.enabled = false;
        Daligi.enabled = false;
        Jamsu.enabled = false;
        Wolf.enabled = false;
        Maze.enabled = false;

        menu = false;
        select = true;
        setting = false;
        intro = false;
    }


    public void Setting()
    {
        SettingMenu.enabled = true;
        game.enabled = false;
        pick.enabled = false;
        exit.enabled = false;
        settingButton.enabled = false;
        setting = true;
        SoundM.PlayButton();
    }

    public void QuitSetting()
    {
        SettingMenu.enabled = false;
        game.enabled = true;
        pick.enabled = true;
        exit.enabled = true;
        settingButton.enabled = true;
        setting = false;
        SoundM.PlayButton();
    }
    public void GameStartWall()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitForSeconds(0.5f));
        SceneManager.LoadScene(2);
    }

    public void GameStartDal()
    {//수정 부탁(허들 노허들뜨게끔)
        SoundM.PlayButton();
        StartCoroutine(WaitForSeconds(0.5f));
        SceneManager.LoadScene(3);
    }

    public void GameStartJam()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitForSeconds(0.5f));
        SceneManager.LoadScene(4);
    }

    public void GameStartWolf()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitForSeconds(0.5f));
        SceneManager.LoadScene(5);
    }

    public void GameStartMaze()
    {//수정 부탁(스테이지 선택으로 가게끔)
        SoundM.PlayButton();
        StartCoroutine(WaitForSeconds(0.5f));
        SceneManager.LoadScene(6);
    }

    IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void Update()
    {    //뒤로가기 버튼(얘도 추가하셈 boolean 만들어서)
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if(menu == true)
                {
                    SoundM.PlayButton();
                    Application.Quit();
                }
                else if(select == true)
                {
                    SoundM.PlayButton();
                    OpenMenu.enabled = true;
                    GameSelect.enabled = false;
                    menu = true;
                    select = false;
                    setting = false;
                }
                else if(setting == true)
                {
                    SoundM.PlayButton();
                    SettingMenu.enabled = false;
                }
                else if(intro == true)
                {
                    SoundM.PlayButton();
                    OpenMenu.enabled = false;
                    GameSelect.enabled = true;
                    Wallpihagi.enabled = false;
                    Daligi.enabled = false;
                    Jamsu.enabled = false;
                    Wolf.enabled = false;
                    Maze.enabled = false;

                    menu = false;
                    select = true;
                    setting = false;
                    intro = false;
                }
            }
        }
    }
}
