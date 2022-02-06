using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

//LoadScene(여기 수정)
public class OpenMenuScript : MonoBehaviour
{
    public Button pick;
    public Button Swimgame_Button;// before
    public Button DDRgame_Button;
    public Button Wolfgame_Button;
    public Button[] Inventory = new Button[3];//screen
    public Button exit;
    public Button settingButton;
    public Button Mir;
    public Button ShopBu;
    public Button Daligi_Button;
    public Button Rank;
    public Button jebby;

    public Canvas OpenMenu;
    public Canvas SettingMenu;
    public Canvas ShopChoose;
    //게임 들어가기 전
    public Canvas Wallpihagi;
    public Canvas Daligi;
    public Canvas Jamsu;
    public Canvas Wolf;
    public Canvas Maze;
    public SoundManager SoundM;
    //인벤토리
    public Canvas DDRInventory;
    public Canvas SwimInventory;
    public Canvas WolfInventory;
    //달리기 버튼,켄버스
    public Canvas MazeChoose;
    public GameObject ScrollPanel;
    public Text TotalSc;
    //상점(Escape용)
    public Canvas[] ShopCanvas = new Canvas[3];

    Vector3 ScPos;
    //******************
    public GameObject obj_one;
    public GameObject obj_two;
    public GameObject obj_three;
    void Start()
    {
        ScPos = ScrollPanel.transform.localPosition;
        Screen.orientation = ScreenOrientation.Portrait;
        int Total = (PlayerPrefs.GetInt("Wallhigh") + PlayerPrefs.GetInt("WallhighEasy") + PlayerPrefs.GetInt("WallhighHard")) + PlayerPrefs.GetInt("NewSwimhigh") + PlayerPrefs.GetInt("Swimhigh") + PlayerPrefs.GetInt("Wolfhigh") * 10;
        TotalSc.text = Total.ToString();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1;
        if (JudgeScript.shop != true)
        {
            SoundM.PlayButton();
            OpenMenu.enabled = true;
            ShopChoose.enabled = false;
        }
        else
        {
            SoundM.PlayButton();
            OpenMenu.enabled = false;
            ShopChoose.enabled = true;
        }
    }

    public void Jebby()
    {
        SoundM.PlayButton();
        SceneManager.LoadScene(8);
    }

    public void Pick()
    {
        SoundM.PlayButton();
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(2);
    }

    public void Shop()
    {
        OpenMenu.enabled = false;
        ShopChoose.enabled = true;
    }

    public void Game1Start()
    {
        SoundM.PlayButton();
        LoadingSceneScript.sceneNum = 3;
        SceneManager.LoadScene(10);
    }

    public void GameDaligiStart()
    {
        SoundM.PlayButton();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine(WaitSec(0.5f));
        Daligi.enabled = true;
    }

    public void GameJamsooStart()
    {
        SoundM.PlayButton();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (RoundController_Jamsu.round.Equals(1)) LoadingSceneScript.sceneNum = 4;//SceneManager.LoadScene(4);
        else LoadingSceneScript.sceneNum = 9;
        SceneManager.LoadScene(10);
    }

    public void MazeStart()
    {
        SoundM.PlayButton();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        MazeWait();
    }

    void MazeWait()
    {
        OpenMenu.enabled = false;
        Maze.enabled = false;
        MazeChoose.enabled = true;
    }

    public void WolfStart()
    {
        SoundM.PlayButton();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        LoadingSceneScript.sceneNum = 7;
        SceneManager.LoadScene(10);
    }

    public void Exit()
    {

        // 로그인이 되어 있으면
        if (Social.localUser.authenticated)
        {
            ((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
        }
        SoundM.PlayButton();
        Application.Quit();
#if !UNITY_EDITOR
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
    }

    public void Back_ShopChoose()
    {
        ScrollPanel.transform.localPosition = ScPos;
        OpenMenu.enabled = true;
        ShopChoose.enabled = false;
        JudgeScript.shop = false;
    }

    public void Back_MazeChoose()
    {
        SoundM.PlayButton();
        Screen.orientation = ScreenOrientation.Portrait;
        OpenMenu.enabled = true;
        MazeChoose.enabled = false;
    }

    public void Setting()
    {
        SettingMenu.enabled = true;
        Swimgame_Button.interactable = false;
        DDRgame_Button.interactable = false;
        Wolfgame_Button.interactable = false;
        pick.interactable = false;
        exit.interactable = false;
        settingButton.interactable = false;
        Mir.interactable = false;
        ShopBu.interactable = false;
        Daligi_Button.interactable = false;
        Rank.interactable = false;
        jebby.interactable = false;
        for (int i = 0; i < 3; i++) Inventory[i].interactable = false;
        SoundM.PlayButton();
    }

    public void QuitSetting()
    {
        SettingMenu.enabled = false;
        Swimgame_Button.interactable = true;
        DDRgame_Button.interactable = true;
        Wolfgame_Button.interactable = true;
        pick.interactable = true;
        exit.interactable = true;
        settingButton.interactable = true;
        Mir.interactable = true;
        ShopBu.interactable = true;
        Daligi_Button.interactable = true;
        Rank.interactable = true;
        jebby.interactable = true;
        for (int i = 0; i < 3; i++) Inventory[i].interactable = true;
        SoundM.PlayButton();
    }
    public void GameStartWall()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitSec(0.5f));
        SceneManager.LoadScene(3);
    }

    public void GameStartDal()
    {
        SoundM.PlayButton();
        SceneManager.LoadScene(5);
    }

    public void GameStartWolf()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitSec(0.5f));
        SceneManager.LoadScene(7);
    }

    public void GameStartMaze()
    {
        SoundM.PlayButton();
        StartCoroutine(WaitSec(0.5f));
        OpenMenu.enabled = false;
        MazeChoose.enabled = true;
    }

    //Inventory

    public void Inventory_DDR()
    {
        DDRInventory.enabled = true;
        Swimgame_Button.interactable = false;
        DDRgame_Button.interactable = false;
        Wolfgame_Button.interactable = false;
        pick.interactable = false;
        exit.interactable = false;
        settingButton.interactable = false;
        Mir.interactable = false;
        ShopBu.interactable = false;
        Daligi_Button.interactable = false;
        Rank.interactable = false;
        jebby.interactable = false;
        StartCoroutine(Moveaside(obj_one));
        for (int i = 0; i < 3; i++) Inventory[i].interactable = false;
        //for (int i = 0; i < 3; i++) Inform[i].interactable = false;
        SoundM.PlayButton();
    }

    public void Inventory_Close()
    {
        StartCoroutine(MoveBack(obj_one, DDRInventory));
        StartCoroutine(MoveBack(obj_two, SwimInventory));
        StartCoroutine(MoveBack(obj_three, WolfInventory));
        //DDRInventory.enabled = false;
        SwimInventory.enabled = false;
        WolfInventory.enabled = false;

        Swimgame_Button.interactable = true;
        DDRgame_Button.interactable = true;
        Wolfgame_Button.interactable = true;
        pick.interactable = true;
        exit.interactable = true;
        settingButton.interactable = true;
        Mir.interactable = true;
        ShopBu.interactable = true;
        Daligi_Button.interactable = true;
        Rank.interactable = true;
        jebby.interactable = true;
        for (int i = 0; i < 3; i++) Inventory[i].interactable = true;
        //for (int i = 0; i < 3; i++) Inform[i].interactable = true;
        SoundM.PlayButton();
    }

    public void Inventory_Swim()
    {
        SwimInventory.enabled = true;
        Swimgame_Button.interactable = false;
        DDRgame_Button.interactable = false;
        Wolfgame_Button.interactable = false;
        pick.interactable = false;
        exit.interactable = false;
        settingButton.interactable = false;
        Mir.interactable = false;
        ShopBu.interactable = false;
        Daligi_Button.interactable = false;
        Rank.interactable = false;
        jebby.interactable = false;
        StartCoroutine(Moveaside(obj_two));
        for (int i = 0; i < 3; i++) Inventory[i].interactable = false;
      //  for (int i = 0; i < 3; i++) Inform[i].interactable = false;
        SoundM.PlayButton();
    }

    public void Inventory_Wolf()
    {
        WolfInventory.enabled = true;
        Swimgame_Button.interactable = false;
        DDRgame_Button.interactable = false;
        Wolfgame_Button.interactable = false;
        pick.interactable = false;
        exit.interactable = false;
        settingButton.interactable = false;
        Mir.interactable = false;
        ShopBu.interactable = false;
        Daligi_Button.interactable = false;
        Rank.interactable = false;
        jebby.interactable = false;
        StartCoroutine(Moveaside(obj_three));
        for (int i = 0; i < 3; i++) Inventory[i].interactable = false;
        //for (int i = 0; i < 3; i++) Inform[i].interactable = false;
        SoundM.PlayButton();
    }

    IEnumerator WaitSec(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (ShopChoose.enabled)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (ShopCanvas[i].enabled.Equals(false))
                        {
                            if (i.Equals(2)) Back_ShopChoose();
                        }
                        else break;
                    }
                }
                else if (MazeChoose.enabled) Back_MazeChoose();
                else if (SettingMenu.enabled) QuitSetting();
                else if (DDRInventory.enabled || SwimInventory.enabled || WolfInventory.enabled) Inventory_Close();
                else if (OpenMenu.enabled) Exit();
            }
        }
    }
    IEnumerator FadeOut(Canvas Fade, Canvas FadeIn)
    {
        Image CanvasImg = Fade.GetComponent<Image>();
        int i = 0;
        while(i<20)
        {
            CanvasImg.color -= new Color(0, 0, 0, 0.05f);
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        FadeIn.enabled = true;
    }

    IEnumerator Moveaside(GameObject obj)
    {
        obj.SetActive(true);
        int i = 0;
        obj.transform.localPosition = new Vector3(-500, 0, 0);
        while(i<5)
        {
            obj.transform.localPosition += new Vector3(100, 0, 0);
            i++;
            yield return new WaitForSeconds(0.05f);
        }

    }

    IEnumerator MoveBack(GameObject obj, Canvas Can)
    {
        int i = 0;
        while (i < 5)
        {
            obj.transform.localPosition -= new Vector3(100, 0, 0);
            i++;
            yield return new WaitForSeconds(0.05f);
        }
        Can.enabled = false;
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.SetActive(false);
    }
}