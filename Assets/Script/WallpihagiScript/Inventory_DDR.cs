using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory_DDR : MonoBehaviour
{

    //표시할 아이템: Pizza0,Pizza1,Pizza2,Pizza3,Pet1,Pet2,Pet3

    public GameObject DDRPanel;

    private Vector3[] HavePizzaPos = new Vector3[4];

    private Vector3 UsingPet;
    private Vector3[] HavePetPos = new Vector3[4];

    public Image[] Pizza = new Image[4];
    public Image[] Pet = new Image[2];

    int[] PizzaNum = new int[4];
    int[] PetNum = new int[2];

    public Button GameSelectBack;

    Vector3 MovePos, StartScale, MoveScale;
    bool isBig;

    void Awake()
    {
        for (int i = 0; i < 4; i++) Pizza[i].gameObject.SetActive(false);
        for (int i = 0; i < 2; i++) Pet[i].gameObject.SetActive(false);

        HavePizzaPos[0] = new Vector3(63, 124, 0);
        HavePizzaPos[1] = new Vector3(143, 124, 0);
        HavePizzaPos[2] = new Vector3(223, 124, 0);
        HavePizzaPos[3] = new Vector3(303, 124, 0);

        HavePetPos[0] = new Vector3(193, -123, 0);
        HavePetPos[1] = new Vector3(277, -123, 0);
        HavePetPos[2] = new Vector3(277, -123, 0);

        PizzaNum[0] = PlayerPrefs.GetInt("Pizza0");
        PizzaNum[1] = PlayerPrefs.GetInt("Pizza1");
        PizzaNum[2] = PlayerPrefs.GetInt("Pizza2");
        PizzaNum[3] = PlayerPrefs.GetInt("Pizza3");

        PetNum[0] = PlayerPrefs.GetInt("DdrPet2");//Coin
        PetNum[1] = PlayerPrefs.GetInt("DdrPet3");//DDR
        MovePos = new Vector3(96.1f, -21, 0);
        MoveScale = new Vector3(4.78f, 13.7f, 4.78f);
        isBig = false;
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (PizzaNum[i] == 2) Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(true);
            else
            {
                Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (PetNum[i] == 2) Pet[i].transform.FindChild("UseImage").gameObject.SetActive(true);
            else
            {
                Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
            }
        }
        int k = 0, count = 0;

        while (k < 4)
        {
            if (PizzaNum[k] == 1 || PizzaNum[k] == 2)
            {
                Pizza[k].gameObject.SetActive(true);
                Pizza[k].transform.localPosition = HavePizzaPos[count];
                count++;
            }
            k++;
        }

        for (int i = 0; i < 2; i++)
        {
            if (PetNum[i] == 2) Pet[i].transform.localPosition = UsingPet;

        }

        k = 0; count = 0;
        while (k < 2)
        {
            if (PetNum[k] == 1 || PetNum[k] == 2)
            {
                Pet[k].gameObject.SetActive(true);
                Pet[k].transform.localPosition = HavePetPos[count];
                count++;
            }
            k++;
        }
    }
    
    public void PosCheck()
    {
        int k = 0, count = 0;

        while (k < 4)
        {
            if (PizzaNum[k] == 1 || PizzaNum[k] == 2)
            {
                Pizza[k].gameObject.SetActive(true);
                Pizza[k].transform.localPosition = HavePizzaPos[count];
                count++;
            }
            k++;
        }
    }

    public void UsePizza0()
    {
        for (int i = 0; i < 4; i++)
        {
            Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
        }
        PizzaNum[0] = 2;
        for (int i = 0; i < 4; i++)
        {
            if (i != 0)
            {
                if (PizzaNum[i].Equals(2)) PizzaNum[i] = 1;
            }
        }
        PlayerPrefs.SetInt("Pizza0", PizzaNum[0]);
        PlayerPrefs.SetInt("Pizza1", PizzaNum[1]);
        PlayerPrefs.SetInt("Pizza2", PizzaNum[2]);
        PlayerPrefs.SetInt("Pizza3", PizzaNum[3]);

        if (!isBig)
        {
            StartScale = Pizza[0].transform.localScale;
            Pizza[0].transform.SetAsLastSibling();
            Pizza[0].transform.parent.transform.SetAsLastSibling();
            Pizza[0].transform.localScale = MoveScale;
            Pizza[0].transform.localPosition = MovePos;
            isBig = true;
        }
        else
        {
            Pizza[0].transform.localScale = StartScale;
            PosCheck();
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) PizzaNum[i] = 1;
            }
            PizzaNum[0] = 2;
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(true);
                else
                {
                    Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
                }
            }
            isBig = false;
        }
    }

    public void UsePizza1()
    {
        for (int i = 0; i < 4; i++)
        {
            Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
        }
        PizzaNum[1] = 2;
        for (int i = 0; i < 4; i++)
        {
            if (i != 1)
            {
                if (PizzaNum[i].Equals(2)) PizzaNum[i] = 1;
            }
        }
        PlayerPrefs.SetInt("Pizza0", PizzaNum[0]);
        PlayerPrefs.SetInt("Pizza1", PizzaNum[1]);
        PlayerPrefs.SetInt("Pizza2", PizzaNum[2]);
        PlayerPrefs.SetInt("Pizza3", PizzaNum[3]);

        if (!isBig)
        {
            StartScale = Pizza[1].transform.localScale;
            Pizza[1].transform.SetAsLastSibling();
            Pizza[1].transform.parent.transform.SetAsLastSibling();
            Pizza[1].transform.localScale = MoveScale;
            Pizza[1].transform.localPosition = MovePos;
            Pizza[1].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            Pizza[1].transform.localScale = StartScale;
            PosCheck();
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) PizzaNum[i] = 1;
            }
            PizzaNum[1] = 2;
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(true);
                else
                {
                    Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
                }
            }
            Pizza[1].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }

    public void UsePizza2()
    {
        for (int i = 0; i < 4; i++)
        {
            Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
        }
        PizzaNum[2] = 2;
        for (int i = 0; i < 4; i++)
        {
            if (i != 2)
            {
                if (PizzaNum[i].Equals(2)) PizzaNum[i] = 1;
            }
        }
        PlayerPrefs.SetInt("Pizza0", PizzaNum[0]);
        PlayerPrefs.SetInt("Pizza1", PizzaNum[1]);
        PlayerPrefs.SetInt("Pizza2", PizzaNum[2]);
        PlayerPrefs.SetInt("Pizza3", PizzaNum[3]);

        if (!isBig)
        {
            StartScale = Pizza[2].transform.localScale;
            Pizza[2].transform.SetAsLastSibling();
            Pizza[2].transform.parent.transform.SetAsLastSibling();
            Pizza[2].transform.localScale = MoveScale;
            Pizza[2].transform.localPosition = MovePos;
            Pizza[2].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            Pizza[2].transform.localScale = StartScale;
            PosCheck();
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) PizzaNum[i] = 1;
            }
            PizzaNum[2] = 2;
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(true);
                else
                {
                    Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
                }
            }
            Pizza[2].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }

    public void UsePizza3()
    {
        for (int i = 0; i < 4; i++)
        {
            Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
        }
        PizzaNum[3] = 2;
        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
            {
                if (PizzaNum[i].Equals(2)) PizzaNum[i] = 1;
            }
        }
        PlayerPrefs.SetInt("Pizza0", PizzaNum[0]);
        PlayerPrefs.SetInt("Pizza1", PizzaNum[1]);
        PlayerPrefs.SetInt("Pizza2", PizzaNum[2]);
        PlayerPrefs.SetInt("Pizza3", PizzaNum[3]);

        if (!isBig)
        {
            StartScale = Pizza[3].transform.localScale;
            Pizza[3].transform.SetAsLastSibling();
            Pizza[3].transform.parent.transform.SetAsLastSibling();
            Pizza[3].transform.localScale = MoveScale;
            Pizza[3].transform.localPosition = MovePos;
            Pizza[3].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            Pizza[3].transform.localScale = StartScale;
            PosCheck();
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) PizzaNum[i] = 1;
            }
            PizzaNum[3] = 2;
            for (int i = 0; i < 4; i++)
            {
                if (PizzaNum[i] == 2) Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(true);
                else
                {
                    Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
                }
            }
            Pizza[3].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }


    public void UsePet1()
    {

        for (int i = 0; i < 2; i++)
        {
            Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
        }
        PetNum[0] = 2;
        if (PetNum[1].Equals(2)) PetNum[1] = 1;
        PlayerPrefs.SetInt("DdrPet2", PetNum[0]);
        PlayerPrefs.SetInt("DdrPet3", PetNum[1]);

        if (!isBig)
        {
            StartScale = Pet[0].transform.localScale;
            Pet[0].transform.SetAsLastSibling();
            Pet[0].transform.parent.transform.SetAsLastSibling();
            Pet[0].transform.localScale = MoveScale;
            Pet[0].transform.localPosition = MovePos;
            Pet[0].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            Pet[0].transform.localScale = StartScale;
            Pet[0].transform.localPosition = HavePetPos[0];
            for (int i = 0; i < 2; i++)
            {
                if (PetNum[i] == 2) PetNum[i] = 1;
            }
            PetNum[0] = 2;
            for (int i = 0; i < 2; i++)
            {
                if (PetNum[i] == 2) Pet[i].transform.FindChild("UseImage").gameObject.SetActive(true);
                else
                {
                    Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
                }
            }
            Pet[0].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }
    public void UsePet2()
    {
        for (int i = 0; i < 2; i++)
        {
            Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
        }
        PetNum[0] = 2;
        if (PetNum[1].Equals(2)) PetNum[1] = 1;
        PlayerPrefs.SetInt("DdrPet2", PetNum[0]);
        PlayerPrefs.SetInt("DdrPet3", PetNum[1]);

        if (!isBig)
        {
            StartScale = Pet[0].transform.localScale;
            Pet[0].transform.SetAsLastSibling();
            Pet[0].transform.parent.transform.SetAsLastSibling();
            Pet[0].transform.localScale = MoveScale;
            Pet[0].transform.localPosition = MovePos;
            Pet[0].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            Pet[0].transform.localScale = StartScale;
            Pet[0].transform.localPosition = HavePetPos[0];
            for (int i = 0; i < 2; i++)
            {
                if (PetNum[i] == 2) PetNum[i] = 1;
            }
            PetNum[0] = 2;
            for (int i = 0; i < 2; i++)
            {
                if (PetNum[i] == 2) Pet[i].transform.FindChild("UseImage").gameObject.SetActive(true);
                else
                {
                    Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
                }
            }
            Pet[0].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }

    public void UsePet3()
    {
        for (int i = 0; i < 2; i++)
        {
            Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
        }
        PetNum[1] = 2;
        if (PetNum[0].Equals(2)) PetNum[0] = 1;
        PlayerPrefs.SetInt("DdrPet2", PetNum[0]);
        PlayerPrefs.SetInt("DdrPet3", PetNum[1]);

        if (!isBig)
        {
            StartScale = Pet[1].transform.localScale;
            Pet[1].transform.SetAsLastSibling();
            Pet[1].transform.parent.transform.SetAsLastSibling();
            Pet[1].transform.localScale = MoveScale;
            Pet[1].transform.localPosition = MovePos;
            Pet[1].transform.FindChild("Text").gameObject.SetActive(true);
            isBig = true;
        }
        else
        {
            Pet[1].transform.localScale = StartScale;
            Pet[1].transform.localPosition = HavePetPos[1];
            for (int i = 0; i < 2; i++)
            {
                if (PetNum[i] == 2) PetNum[i] = 1;
            }
            PetNum[1] = 2;
            for (int i = 0; i < 2; i++)
            {
                if (PetNum[i] == 2) Pet[i].transform.FindChild("UseImage").gameObject.SetActive(true);
                else
                {
                    Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
                }
            }
            Pet[1].transform.FindChild("Text").gameObject.SetActive(false);
            isBig = false;
        }
    }

    void Setting()
    {
        PizzaNum[0] = PlayerPrefs.GetInt("Pizza0");
        PizzaNum[1] = PlayerPrefs.GetInt("Pizza1");
        PizzaNum[2] = PlayerPrefs.GetInt("Pizza2");
        PizzaNum[3] = PlayerPrefs.GetInt("Pizza3");

        PetNum[0] = PlayerPrefs.GetInt("DdrPet2");
        PetNum[1] = PlayerPrefs.GetInt("DdrPet3");

        for (int i = 0; i < 4; i++)
        {
            if (PizzaNum[i] == 2) Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(true);
            else
            {
                Pizza[i].transform.FindChild("UseImage").gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (PetNum[i] == 2) Pet[i].transform.FindChild("UseImage").gameObject.SetActive(true);
            else
            {
                Pet[i].transform.FindChild("UseImage").gameObject.SetActive(false);
            }
        }
        int k = 0, count = 0;

        while (k < 4)
        {
            if (PizzaNum[k] == 1 || PizzaNum[k] == 2)
            {
                Pizza[k].gameObject.SetActive(true);
                Pizza[k].transform.localPosition = HavePizzaPos[count];
                count++;
            }
            k++;
        }

        for (int i = 0; i < 2; i++)
        {
            if (PetNum[i] == 2) Pet[i].transform.localPosition = UsingPet;

        }

        k = 0; count = 0;
        while (k < 2)
        {
            if (PetNum[k] == 1 || PetNum[k] == 2)
            {
                Pet[k].gameObject.SetActive(true);
                Pet[k].transform.localPosition = HavePetPos[count];
                count++;
            }
            k++;
        }
    }

    public void Inventory()
    {
        Setting();
    }
}