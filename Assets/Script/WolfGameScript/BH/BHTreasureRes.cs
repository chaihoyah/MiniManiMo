using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BHTreasureRes : MonoBehaviour
{
    //public ObjectPooling TreasurePool;
    //public GameObject TreasureBox;

    public GameObject FireRegion;
    public GameObject LightRegion;
    public GameObject IceRegion;
    public GameObject Player;
    public static int ItemNum;
    public int IceNum;
    public int FireNum;
    public int LightningNum;
    public Button[] Attack = new Button[6];
    public int[] AttackCnt = new int[6];//0그냥 1 따발 2 미포궁 3 그그그그
    public int WhatisNow;

    public Text MachineText;
    public Text MissText;
    public Text WallText;

    public GameObject TOne;
    public GameObject TTwo;
    public GameObject TThree;
    public GameObject TFour;
    public GameObject TFive;
    public GameObject TSix;
    public GameObject THealth;

    public GameObject TBackShot;
    public GameObject TBombShot;

    public Text BackText;
    public Text BombText;
    public SoundManager SoundM;

    //
    /**public static bool isOne = false;
    public static bool isTwo = false;
    public static bool isThree = false;
    public static bool isFour = false;
    public static bool isFive = false;
    public static bool isSix = false;
    public static bool isTrigger = false;
    public static bool isHealth = false;**/
    public PandaDie PanDie;
    int[] RanArray ;
    int[] RanThree = new int[3];

    public GameObject IceIce;
    public GameObject LightLight;
    public GameObject FireFire;

    // Use this for initialization
    void Start()
    {
        //TreasurePool = new ObjectPooling();
        //TreasurePool.InitPool(TreasureBox, 4);
        IceNum = 3;
        FireNum = 3;
        LightningNum = 3;
        ItemNum = 0;
        WhatisNow = 0;
        AttackCnt[0] = 0;
        for (int i = 1; i < 6; i++)
        {
            AttackCnt[i] = 0;
        }
        MachineText.text = "X " + AttackCnt[1].ToString();
        MissText.text = "X " + AttackCnt[2].ToString();
        WallText.text = "X " + AttackCnt[3].ToString();
        //
            RanArray = new int[8];
            for (int i = 0; i < 8; i++)
            {
                RanArray[i] = i;
            }
     

        RanThree[0] = 3;
        RanThree[1] = 4;
        RanThree[2] = 5;
        RandomArray();
        RandomThree();
        PanDie = GameObject.Find("player").GetComponent<PandaDie>();
        if (!BH_Tuto.isPanTuto)
            StartCoroutine(TreasureRes());
        //StartCoroutine(TreaText());
    }

    IEnumerator TreasureRes()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            TreasureItemRes();
        }
    }

    Vector3 RandomPos()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);

        return new Vector3(x, 4, y);
    }

    private void ObjectPop(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;

        obj.SetActive(true);
    }

    public void IceSkill()
    {
        if (IceNum > 0)
        {
            IceIce.SetActive(true);
            IceNum--;
            Instantiate(IceRegion, Player.transform.position, new Quaternion(0, 0, 0, 0));
            Invoke("IceOff", 0.7f);
        }
    }

    void IceOff()
    {
        IceIce.SetActive(false);
    }


    public void FireSkill()
    {
        if (FireNum > 0)
        {
            SoundM.PlayBHFire();
            FireNum--;
            FireFire.SetActive(true);
            Invoke("FireOff", 1.5f);
        }
    }

    void FireOff()
    {
        FireFire.SetActive(false);
    }

    public void LightningSkill()
    {
        if (LightningNum > 0)
        {
            LightLight.SetActive(true);
            SoundM.PlayBHLightning();
            LightningNum--;
            Invoke("LightOff", 0.7f);
        }
    }

    void LightOff()
    {
        LightLight.SetActive(false);
    }

    public void GoNext()
    {
        SoundM.PlayBHWeaponChange();
        int Num = CheckAttackType(WhatisNow);
        Attack[WhatisNow].gameObject.SetActive(false);
        Attack[Num].gameObject.SetActive(true);
        WhatisNow = Num;

    }

    int CheckAttackType(int Now)
    {
        int k = 0;
        if (Now != 5)
        {
            while (Now < 5)
            {
                if (AttackCnt[Now + 1] != 0)
                {
                    k = Now + 1;
                    break;
                }
                Now++;
            }
        }
        return k;
    }

    /**IEnumerator TreaText()
    {
        yield return new WaitForSeconds(0.5f);
            if (isTrigger)
            {
                if (isOne)
                {
                    TOne.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    TOne.SetActive(false);
                }
                else if (isTwo)
                {
                    TTwo.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    TTwo.SetActive(false);
                }
                else if (isThree)
                {
                    TThree.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    TThree.SetActive(false);
                }
                else if (isFour)
                {
                    TFour.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    TFour.SetActive(false);
                }
                else if (isFive)
                {
                    TFive.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    TFive.SetActive(false);
                }
                else if (isSix)
                {
                    TSix.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    TSix.SetActive(false);
                }
                else if(BHTreaOpen.isHealth)
                {
                    THealth.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    THealth.SetActive(false);
                }

        }

    }**/

    private void Update()
    {
        MachineText.text = "X " + AttackCnt[1].ToString();
        MissText.text = "X " + AttackCnt[2].ToString();
        WallText.text = "X " + AttackCnt[3].ToString();
        BackText.text = "X " + AttackCnt[4].ToString();
        BombText.text = "X " + AttackCnt[5].ToString();
    }

    //

    public void TreasureItemRes()
    {
        HealthRandom();
    }

    void HealthRandom()
    {
        if (PanDie.PanHP < 150)
        {
            int k = Random.Range(0, 3);//0 or 1 or 2
            if (k.Equals(0) || k.Equals(1))
            {
                PanDie.PanHP += 100;
                THealth.SetActive(true);
                //isHealth = true;
                Invoke("TextHealth", 1f);
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
            int Ran = Random.Range(0, 3);
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
        int RanNum = 0;
        RanNum = Random.Range(3, 8);


        if (RanNum.Equals(3))
        {
            AttackCnt[1] += 20;
            TOne.SetActive(true);
            Invoke("TextNoFour", 1f / WolfScript.Calculation);
        }
        else if (RanNum.Equals(4))
        {
            AttackCnt[2] += 7;
            TTwo.SetActive(true);
            Invoke("TextNoFi", 1f / WolfScript.Calculation);
        }
        else if(RanNum.Equals(5))
        {
            TThree.SetActive(true);
            AttackCnt[3] += 5;
            Invoke("TextNoSix", 1f / WolfScript.Calculation);
        }
        else if (RanNum.Equals(6))
        {
            TBackShot.SetActive(true);
            AttackCnt[4] += 20;
            Invoke("TextBackShot", 1f / WolfScript.Calculation);
        }
        else if (RanNum.Equals(7))
        {
            TBombShot.SetActive(true);
            AttackCnt[5] += 5;
            Invoke("TextBombShot", 1f / WolfScript.Calculation);
        }
    }
    void Item()
    {
        int RanNum = RanArray[BHTreasureRes.ItemNum++];
        if (RanNum.Equals(0))
        {
            TFour.SetActive(true);
            IceNum++;
            Invoke("TextNoOne", 1f / WolfScript.Calculation);

        }
        else if (RanNum.Equals(1))
        {
            TFive.SetActive(true);
            FireNum++;
            Invoke("TextNoTwo", 1f / WolfScript.Calculation);
        }
        else if (RanNum.Equals(2))
        {
            TSix.SetActive(true);
            LightningNum++;
            Invoke("TextNoThree", 1f / WolfScript.Calculation);
        }
        else if (RanNum.Equals(3))
        {
            TOne.SetActive(true);
            AttackCnt[1] += 20;
            Invoke("TextNoFour", 1f / WolfScript.Calculation);
        }
        else if (RanNum.Equals(4))
        {
            TTwo.SetActive(true);
            AttackCnt[2] += 7;
            Invoke("TextNoFi", 1f / WolfScript.Calculation);
        }
        else if(RanNum.Equals(5))
        {
            TThree.SetActive(true);
            AttackCnt[3] += 5;
            Invoke("TextNoSix", 1f / WolfScript.Calculation);
        }

        else if (RanNum.Equals(6))
        {
            TBackShot.SetActive(true);
            AttackCnt[4] += 20;
            Invoke("TextBackShot", 1f / WolfScript.Calculation);
        }
        else if (RanNum.Equals(7))
        {
            TBombShot.SetActive(true);
            AttackCnt[5] += 5;
            Invoke("TextBombShot", 1f / WolfScript.Calculation);
        }
    }

    void TextHealth()
    {
        THealth.SetActive(false);
    }
    void TextNoOne()
    {
        TFour.SetActive(false);
    }

    void TextNoTwo()
    {
        TFive.SetActive(false);
    }
    void TextNoThree()
    {
        TSix.SetActive(false);
    }
    void TextNoFour()
    {
        TOne.SetActive(false);
    }
    void TextNoFi()
    {
        TTwo.SetActive(false);
    }
    void TextNoSix()
    {
        TThree.SetActive(false);
    }

    void TextBackShot()
    {
        TBackShot.SetActive(false);
    }

    void TextBombShot()
    {
        TBombShot.SetActive(false);
    }

    public void RandomArray()
    {
        for (int i = 0; i < RanArray.Length; i++)
        {
            int RanNum = Random.Range(i, RanArray.Length);

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
    }
}
