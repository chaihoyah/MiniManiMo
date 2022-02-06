using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class BHBulletControl : MonoBehaviour
{
    public Image ButtonImage;//따발
    public Button NorAttack;
    public Button BackAttack;
    public ObjectPooling BullPool;
    public ObjectPooling WallPool;
    public ObjectPooling BBPool;
    public GameObject Bullet;
    public GameObject BackBullet;
    public GameObject Bomb;
    public GameObject Player;
    public GameObject Wall;
    public BHTreasureRes Treasure;
    public Animator BirAnim;
    public bool isPress;
    public SoundManager SoundM;
    public BH_Tuto Tut;
    public GameObject BombCol;
    // Use this for initialization
    void Start()
    {
        NorAttack.enabled = true;
        isPress = false;
        WallPool = this.gameObject.AddComponent<ObjectPooling>();
        WallPool.InitPool(Wall, 5);
        BullPool = this.gameObject.AddComponent<ObjectPooling>();
        BullPool.InitPool(Bullet, 15);

        BBPool = this.gameObject.AddComponent<ObjectPooling>();
        BBPool.InitPool(BackBullet, 15);

        StartCoroutine(DDabbal());
    }

    private void ObjectPop(GameObject obj, Vector3 position, Quaternion Angle)
    {
        obj.transform.localPosition = position;
        obj.transform.rotation = Angle;
        obj.SetActive(true);
    }
    private void ObjectPopOne(GameObject obj, Vector3 position, Quaternion Angle)
    {
        obj.transform.localPosition = position;
        obj.transform.rotation = Angle;
        obj.transform.Rotate(0, 15, 0);
        obj.SetActive(true);
    }
    private void ObjectPopTwo(GameObject obj, Vector3 position, Quaternion Angle)
    {
        obj.transform.localPosition = position;
        obj.transform.rotation = Angle;
        obj.transform.Rotate(0, -15, 0);
        obj.SetActive(true);
    }

    public void NormalBulletShot()
    {
        Tut.TutoBool[1] = true;
        SoundM.PlayBHShot();
        NorAttack.enabled = false;
        BirAnim.SetBool("isAttack", true);
        BirAnim.SetBool("isRun", false);
        Vector3 BulPos = new Vector3(Player.transform.position.x, 5.4f, Player.transform.position.z);
        ObjectPop(BullPool.PopObject(), BulPos, Player.transform.rotation);
        StartCoroutine(NBS());
    }

    public void NormalBackShot()
    {
        if (Treasure.AttackCnt[4] > 0)
        {
            Treasure.AttackCnt[4]--;
            Tut.TutoBool[1] = true;
            SoundM.PlayBHShot();
            BackAttack.enabled = false;
            BirAnim.SetBool("isBack", true);
            BirAnim.SetBool("isRun", false);
            Vector3 BulPos = new Vector3(Player.transform.position.x, 5.4f, Player.transform.position.z - 3);
            ObjectPop(BBPool.PopObject(), BulPos, Player.transform.rotation);
            StartCoroutine(NBS());
        }
    }

    IEnumerator NBS()
    {
        yield return new WaitForSeconds(0.25f / WolfScript.Calculation);
        BirAnim.SetBool("isAttack", false);
        BirAnim.SetBool("isBack", false);
        BirAnim.SetBool("isRun", true);
        yield return new WaitForSeconds(0.2f / WolfScript.Calculation);
        NorAttack.enabled = true;
        BackAttack.enabled = true;

    }


    public void BombShot()
    {
        if (Treasure.AttackCnt[5] > 0)
        {
            BirAnim.SetBool("isBomb", true);
            BirAnim.SetBool("isRun", false);
            SoundM.PlayBHShot();
            Treasure.AttackCnt[5]--;
            Bomb.transform.position = new Vector3(Player.transform.position.x, 6.4f, Player.transform.position.z);
            Bomb.transform.rotation = Player.transform.rotation;
            Bomb.SetActive(true);
            StartCoroutine(BSS());
        }
    }
    IEnumerator BSS()
    {
        yield return new WaitForSeconds(1f);
        BirAnim.SetBool("isBomb", false);
        BirAnim.SetBool("isRun", true);
        
    }

    public void MissFortShot()
    {
        if (Treasure.AttackCnt[2] > 0)
        {
            SoundM.PlayBHShot();
            BirAnim.SetBool("isAttack", true);
            BirAnim.SetBool("isRun", false);
            Treasure.AttackCnt[2]--;
            Vector3 BulPos = new Vector3(Player.transform.position.x, 5.4f, Player.transform.position.z);
            Vector3 BulPos1 = new Vector3(Player.transform.position.x + 0.5f, 5.4f, Player.transform.position.z);
            Vector3 BulPos2 = new Vector3(Player.transform.position.x + 0.5f, 5.4f, Player.transform.position.z);

            ObjectPop(BullPool.PopObject(), BulPos, Player.transform.rotation);
            ObjectPopOne(BullPool.PopObject(), BulPos1, Player.transform.rotation);
            ObjectPopTwo(BullPool.PopObject(), BulPos2, Player.transform.rotation);
            StartCoroutine(MFS());
        }
    }

    IEnumerator MFS()
    {
        yield return new WaitForSeconds(0.5f);
        BirAnim.SetBool("isAttack", false);
        BirAnim.SetBool("isRun", true);
    }

    public void WallShot()
    {
        if (Treasure.AttackCnt[3] > 0)
        {
            SoundM.PlayBHWall();
            Treasure.AttackCnt[3]--;
            Vector3 WallPos = new Vector3(0, 4.23f, 2.5f);
            GameObject Wall = WallPool.PopObject();
            Wall.SetActive(true);
            Wall.transform.SetParent(Player.transform, true);
            Wall.transform.localPosition = WallPos;
            Wall.transform.rotation = Player.transform.rotation;
            Wall.transform.SetParent(transform);
        }
    }

    IEnumerator DDabbal()
    {
        while (true)
        {
            if (isPress)
            {
                if (Treasure.AttackCnt[1] > 0)
                {
                    SoundM.PlayBHShot();
                    Vector3 BulPos = new Vector3(Player.transform.position.x, 5.4f, Player.transform.position.z);
                    ObjectPop(BullPool.PopObject(), BulPos, Player.transform.rotation);
                    Treasure.AttackCnt[1]--;
                }
            }
            yield return new WaitForSeconds(0.2f / WolfScript.Calculation);
        }
    }
}