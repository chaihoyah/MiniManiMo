using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BHTreaOpen : MonoBehaviour {

  /**  public static bool isOne= false;
    public static bool isTwo= false;
    public static bool isThree= false;
    public static bool isFour= false;
    public static bool isFive= false;
    public static bool isSix= false;
    public static bool isTrigger = false;
    public static bool isHealth = false;
    public Animator TreasureAnim;
    public BHTreasureRes Treasure;
    public PandaDie PanDie;
    bool OneTimeChk;
    int[] RanArray = new int[6];
    int[] RanThree = new int[3];

    void Start () {
        for(int i=0;i<6;i++)
        {
            RanArray[i] = i;
        }
        RanThree[0] = 3;
        RanThree[1] = 4;
        RanThree[2] = 5;
        RandomArray();
        RandomThree();
        OneTimeChk = false;
        TreasureAnim = this.GetComponent<Animator>();
        Treasure = GameObject.Find("WolfPool").GetComponent<BHTreasureRes>();
        PanDie = GameObject.Find("player").GetComponent<PandaDie>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!OneTimeChk)
            {
                OneTimeChk = true;
                isTrigger = true;
                StartCoroutine(TreasureItemRes());
            }

        }
    }

    IEnumerator TreasureItemRes()
    {
        TreasureAnim.SetBool("TreasureCol", true);
        yield return new WaitForSeconds(0.5f);
        TreasureAnim.SetBool("TreasureCol", false);
        HealthRandom();



        Treasure.TreasurePool.PushObject(this.gameObject);
        OneTimeChk = false;
    }

    void HealthRandom()
    {
        if (PanDie.PanHP < 150)
        {
            int k = Random.Range(0, 3);//0 or 1 or 2
            if (k.Equals(0) || k.Equals(1))
            {
                PanDie.PanHP += 100;
                isHealth = true;
                Invoke("TextHealth", 0.2f);
                //체력회복문구
            }
            else RandomItem();
        }
        else RandomItem();
    }

    void RandomItem()
    {
        if (ScoreScript.time < 100)
        {
            ItemThree();
        }
        else
            {
            int Ran =Random.Range(0, 3);
            if (Ran == 2)
            {
                if (BHTreasureRes.ItemNum < 4)
                {
                    Item();
                }
                else
                {
                    RandomArray();
                    BHTreasureRes.ItemNum = 0;
                    Item();
                }
            }
            else
            {
                ItemThree();
            }
        }
        
        }
   

    void ItemThree()
    {
        int RanNum = Random.Range(3,6);

        if (RanNum.Equals(3))
        {
            Treasure.AttackCnt[1] += 20;
            isOne = true;
            Invoke("TextNoFour", 0.2f);
        }
        else if (RanNum.Equals(4))
        {
            Treasure.AttackCnt[2] += 7;
            isTwo = true;
            Invoke("TextNoFi", 0.2f);
        }
        else
        {
            Treasure.AttackCnt[3] += 5;
            isThree = true;
            Invoke("TextNoSix", 0.2f);
        }
    }
    void Item()
    {
        int RanNum = RanArray[BHTreasureRes.ItemNum++];
        if (RanNum.Equals(0))
        {
            Treasure.IceNum++;
            isFour = true;
            Invoke("TextNoOne", 0.2f);

        }
        else if (RanNum.Equals(1))
        {
            Treasure.FireNum++;
            isFive = true;
            Invoke("TextNoTwo", 0.2f);
        }
        else if (RanNum.Equals(2))
        {
            Treasure.LightningNum++;
            isSix = true;
            Invoke("TextNoThree", 0.2f);
        }
        else if (RanNum.Equals(3))
        {
            Treasure.AttackCnt[1] += 20;
            isOne = true;
            Invoke("TextNoFour", 0.2f);
        }
        else if (RanNum.Equals(4))
        {
            Treasure.AttackCnt[2] += 7;
            isTwo = true;
            Invoke("TextNoFi", 0.2f);
        }
        else
        {
            Treasure.AttackCnt[3] += 5;
            isThree = true;
            Invoke("TextNoSix", 0.2f);
        }
    }

    void TextHealth()
    {
        isTrigger = false;
        isHealth = false;
    }
    void TextNoOne()
    {
        isTrigger = false;
        isFour = false;
    }

    void TextNoTwo()
    {
        isTrigger = false;
        isFive = false;
    }
    void TextNoThree()
    {
        isTrigger = false;
        isSix = false;
    }
    void TextNoFour()
    {
        isTrigger = false;
        isOne = false;
    }
    void TextNoFi()
    {
        isTrigger = false;
        isTwo = false;
    }
    void TextNoSix()
    {
        isTrigger = false;
        isThree = false;
    }

    public void RandomArray()
    {
        for (int i = 0; i < 5; i++)
        {
            int RanNum = Random.Range(i, 6);

            int tmp = RanArray[RanNum];
            RanArray[RanNum] = RanArray[i];
            RanArray[i] = tmp;
        }
    }

    public void RandomThree()
    {
        for (int i = 0; i < 2; i++)
        {
            int RanNum = Random.Range(i, 3);

            int tmp = RanThree[RanNum];
            RanThree[RanNum] = RanThree[i];
            RanThree[i] = tmp;
        }
    }**/


}
