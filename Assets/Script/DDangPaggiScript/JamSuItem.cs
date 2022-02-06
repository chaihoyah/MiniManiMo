using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JamSuItem : MonoBehaviour
{

    public int[] ShoesArr = new int[3];//0 없 1있
    public int[] PetArr = new int[2];
    public Image[] ItemImg = new Image[5];//shoes 012 pet 34
    public Vector2[] ItemPos = new Vector2[5];
    public Image[] ItemChkImg = new Image[3];
    public int isShoeUp;
    int ShoeCnt;
    Vector3 MovePos, StartScale, MoveScale;
    bool isBig;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            ItemImg[i].gameObject.SetActive(false);
            ItemPos[i] = Vector3.zero;
            ItemChkImg[i].gameObject.SetActive(false);
            ShoesArr[i] = 0;
        }
        for (int i = 0; i < 2; i++)
        {
            ItemImg[i + 3].gameObject.SetActive(false);
            ItemPos[i + 3] = Vector3.zero;
            PetArr[i] = 0;
        }
        MoveScale = new Vector3(6, 10.6f, 6);
        MovePos = new Vector3(221.24f, -69, 0);
        isShoeUp = PlayerPrefs.GetInt("SwimUpgrade");

        ShoeCnt = 0;
        ItemCheck();
    }

    public void ItemCheck()
    {
        ShoeCnt = 0;
        ShoesArr[0] = PlayerPrefs.GetInt("SwimShoes1");
        ShoesArr[1] = PlayerPrefs.GetInt("SwimShoes2");
        ShoesArr[2] = PlayerPrefs.GetInt("SwimShoes3");
        PetArr[0] = PlayerPrefs.GetInt("SwimPet1");
        PetArr[1] = PlayerPrefs.GetInt("SwimPet2");

        ItemPos[0] = new Vector3(220, 61, 0);
        ItemPos[1] = new Vector3(350, 61, 0);
        ItemPos[2] = new Vector3(480, 61, 0);
        ItemPos[3] = new Vector3(288, 0, 0);
        ItemPos[4] = new Vector3(420, 0, 0);

        ImageUp();
    }

    void ImageUp()
    {
        for (int i = 0; i < 3; i++)
        {
            if (ShoesArr[i].Equals(1))
            {
                ItemImg[i].gameObject.SetActive(true);
                ItemChkImg[i].gameObject.SetActive(false);
                ItemImg[i].transform.localPosition = ItemPos[ShoeCnt++];
            }
            if (ShoesArr[i].Equals(2))
            {
                ItemImg[i].gameObject.SetActive(true);
                ItemChkImg[i].gameObject.SetActive(true);
                ItemImg[i].transform.localPosition = ItemPos[ShoeCnt++];
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (PetArr[i].Equals(1))
            {
                ItemImg[i + 3].gameObject.SetActive(true);
                ItemImg[i + 3].transform.localPosition = ItemPos[i + 3];
            }
        }
    }

    public void But1()
    {
        ItemChkImg[0].gameObject.SetActive(false);
        ItemChkImg[1].gameObject.SetActive(false);
        ItemChkImg[2].gameObject.SetActive(false);
        ShoesArr[0] = 2;
        PlayerPrefs.SetInt("SwimShoes1", 2);
        if (ShoesArr[1].Equals(2))
        {
            PlayerPrefs.SetInt("SwimShoes2", 1);
            ShoesArr[1] = 1;
        }
        if (ShoesArr[2].Equals(2))
        {
            ShoesArr[2] = 1;
            PlayerPrefs.SetInt("SwimShoes3", 1);
        }
        if (!isBig)
        {
            StartScale = ItemImg[0].transform.localScale;
            ItemImg[0].transform.SetAsLastSibling();
            ItemImg[0].transform.parent.transform.SetAsLastSibling();
            ItemImg[0].transform.localScale = MoveScale;
            ItemImg[0].transform.localPosition = MovePos;
            ItemImg[0].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            ItemImg[0].transform.localScale = StartScale;
            ItemImg[0].transform.localPosition = ItemPos[0];
            isBig = false;
            ItemChkImg[0].gameObject.SetActive(true);
            ItemChkImg[1].gameObject.SetActive(false);
            ItemChkImg[2].gameObject.SetActive(false);
            ItemImg[0].transform.FindChild("Text").gameObject.SetActive(true);
        }
        PlayerPrefs.Save();
    }

    public void But2()
    {
        ItemChkImg[0].gameObject.SetActive(false);
        ItemChkImg[1].gameObject.SetActive(false);
        ItemChkImg[2].gameObject.SetActive(false);
        ShoesArr[1] = 2;
        PlayerPrefs.SetInt("SwimShoes2", 2);
        if (ShoesArr[0].Equals(2))
        {
            PlayerPrefs.SetInt("SwimShoes1", 1);
            ShoesArr[0] = 1;
        }
        if (ShoesArr[2].Equals(2))
        {
            ShoesArr[2] = 1;
            PlayerPrefs.SetInt("SwimShoes3", 1);
        }

        if (!isBig)
        {
            StartScale = ItemImg[1].transform.localScale;
            ItemImg[1].transform.SetAsLastSibling();
            ItemImg[1].transform.parent.transform.SetAsLastSibling();
            ItemImg[1].transform.localScale = MoveScale;
            ItemImg[1].transform.localPosition = MovePos;
            ItemImg[1].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            ItemImg[1].transform.localScale = StartScale;
            ItemImg[1].transform.localPosition = ItemPos[1];
            isBig = false;
            ItemChkImg[0].gameObject.SetActive(false);
            ItemChkImg[1].gameObject.SetActive(true);
            ItemChkImg[2].gameObject.SetActive(false);
            ItemImg[1].transform.FindChild("Text").gameObject.SetActive(false);
        }
        PlayerPrefs.Save();
    }

    public void But3()
    {
        ItemChkImg[0].gameObject.SetActive(false);
        ItemChkImg[1].gameObject.SetActive(false);
        ItemChkImg[2].gameObject.SetActive(false);
        ShoesArr[2] = 2;
        PlayerPrefs.SetInt("SwimShoes3", 2);
        if (ShoesArr[0].Equals(2))
        {
            PlayerPrefs.SetInt("SwimShoes1", 1);
            ShoesArr[0] = 1;
        }
        if (ShoesArr[1].Equals(2))
        {
            ShoesArr[1] = 1;
            PlayerPrefs.SetInt("SwimShoes2", 1);
        }

        if (!isBig)
        {
            StartScale = ItemImg[2].transform.localScale;
            ItemImg[2].transform.SetAsLastSibling();
            ItemImg[2].transform.parent.transform.SetAsLastSibling();
            ItemImg[2].transform.localScale = MoveScale;
            ItemImg[2].transform.localPosition = MovePos;
            ItemImg[2].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            ItemImg[2].transform.localScale = StartScale;
            ItemImg[2].transform.localPosition = ItemPos[2];
            isBig = false;
            ItemChkImg[0].gameObject.SetActive(false);
            ItemChkImg[1].gameObject.SetActive(false);
            ItemChkImg[2].gameObject.SetActive(true);
            ItemImg[2].transform.FindChild("Text").gameObject.SetActive(false);
        }
        PlayerPrefs.Save();
    }

    public void But4()
    {
        if (!isBig)
        {
            StartScale = ItemImg[3].transform.localScale;
            ItemImg[3].transform.SetAsLastSibling();
            ItemImg[3].transform.parent.transform.SetAsLastSibling();
            ItemImg[3].transform.localScale = MoveScale;
            ItemImg[3].transform.localPosition = new Vector3(MovePos.x, 88f, MovePos.z);
            ItemImg[3].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            ItemImg[3].transform.localScale = StartScale;
            ItemImg[3].transform.localPosition = ItemPos[3];
            ItemImg[3].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }

    public void But5()
    {
        if (!isBig)
        {
            StartScale = ItemImg[4].transform.localScale;
            ItemImg[4].transform.SetAsLastSibling();
            ItemImg[4].transform.parent.transform.SetAsLastSibling();
            ItemImg[4].transform.localScale = MoveScale;
            ItemImg[4].transform.localPosition = new Vector3(MovePos.x, 88f, MovePos.z);
            ItemImg[4].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            ItemImg[4].transform.localScale = StartScale;
            ItemImg[4].transform.localPosition = ItemPos[4];
            ItemImg[4].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }
}
