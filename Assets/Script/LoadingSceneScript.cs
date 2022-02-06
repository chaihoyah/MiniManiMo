using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour
{

    public GameObject[] loadImage = new GameObject[3];
    public static int sceneNum = 0;
    bool isDoing = false;
    void Start()
    {
        int num = 0;
        StartCoroutine(Before_Loading(num)); 
    }

    IEnumerator Before_Loading(int num)
    {
        for (int i = 0; i < 6; i++)
        {
            Loading_ChangeImage(num);
            if (num < 2) num++;
            else num = 0;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(Load(num));
    }

    IEnumerator Load(int num)
    {
        AsyncOperation async = Application.LoadLevelAsync(sceneNum);
        while (!async.isDone)
        {
            print("loading");
            if(!isDoing) StartCoroutine(Loading(num));
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void Loading_ChangeImage(int num)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i.Equals(num)) loadImage[i].SetActive(true);
            else loadImage[i].SetActive(false);
        }
    }


    IEnumerator Loading(int num)
    {
        isDoing = true;
        print("LN");
        for (int i = 0; i < 3; i++)
        {
            Loading_ChangeImage(num);
            if (num < 2) num++;
            else num = 0;
            print(num);
            yield return new WaitForSeconds(0.3f);
        }
        isDoing = false;
    }
}