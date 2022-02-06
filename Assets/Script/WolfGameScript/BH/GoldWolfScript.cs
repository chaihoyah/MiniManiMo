using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GoldWolfScript : MonoBehaviour
{
    GameObject player;
    public int GolWolfHP;
    public float GolWolfSpeed;
    public PandaDie PanDie;
    public GoldWolfRespawn GWR;
    public BHBulletControl BHC;
    public GameObject IceWolf;
    Vector3 playerPos;
    Vector3 wolfPos;
    bool isColPl;
    bool isColWl;
    bool isFirst;
    bool isWallFirst;
    bool isIceFirst;
    bool isColMap; //
    float angle;
    Rigidbody thisRig;
    Transform WolfTr;
    Transform PlTr;
    public GameObject Camera;
    Animator GolWolfAnim;
    public Animator BirAnim;
    public SoundManager SoundM;
    float NextTime;
    float speed = 1;
    int a, b;
    bool RotChg;

    public GameObject FiredWolf;

    public BHCoinEffect BHCE;
    private void Awake()
    {
        FiredWolf = GameObject.Find("FiredWolf");
        BHCE = GameObject.Find("WolfPool").GetComponent<BHCoinEffect>();
        isFirst = true;
    }
    private void Start()
    {
        GolWolfSpeed = 0.21f;
        NextTime = 40;
        wolfPos = this.transform.position;
        BHC = GameObject.Find("WolfPool").GetComponent<BHBulletControl>();
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
        BirAnim = player.GetComponent<Animator>();
        GolWolfAnim = this.GetComponent<Animator>();
        Camera = GameObject.Find("Main Camera");
        thisRig = this.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GolWolfHP = 130;
        if (isFirst)
        {
            player = GameObject.Find("player");
            PlTr = player.transform;
            WolfTr = this.transform;
            PanDie = GameObject.Find("player").GetComponent<PandaDie>();
            GWR = GameObject.Find("WolfPool").GetComponent<GoldWolfRespawn>();
            IceWolf = this.transform.FindChild("Ice").gameObject;
            GolWolfAnim = this.GetComponent<Animator>();
            StartCoroutine(AttackAI());
            StartCoroutine(Destroy_Time());
            isFirst = false;
        }
        else
        {
            StartCoroutine(AttackAI());
            StartCoroutine(Destroy_Time());
        }
        IceWolf.SetActive(false);
        isColPl = false;
        isColWl = false;
        isColMap = false; //
        isWallFirst = false;
        isIceFirst = false;
    }

    private void OnDisable()
    {
        isColPl = false; isColWl = false;
        if (isColMap) isColMap = false; //
        GolWolfAnim.SetBool("isExhaust", false);
        GolWolfAnim.SetBool("isAttack", false);
        GolWolfAnim.SetBool("isCrush", false);
        this.transform.FindChild("Mad").gameObject.SetActive(false);
        speed = 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isColPl = true;
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("FireRegion"))
        {
            SoundM.PlayBHMonsterHit();
            BHCE.FullChkGold();
            coinScript.gold += 1;
            GameObject FW = Instantiate(FiredWolf, new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, this.transform.position.z), this.transform.rotation) as GameObject;
            FW.AddComponent<FireWolfDelete>();
            GWR.GWObjPool.PushObject(this.gameObject);
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("LightRegion"))
        {
            SoundM.PlayBHMonsterHit();
            BHCE.FullChkGold();
            coinScript.gold += 1;
            GameObject FW = Instantiate(FiredWolf, new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, this.transform.position.z), this.transform.rotation) as GameObject;
            FW.AddComponent<FireWolfDelete>();
            GWR.GWObjPool.PushObject(this.gameObject);
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("BHBullet"))
        {
            SoundM.PlayBHMonsterHit();
            StartCoroutine(BackMove());
            GolWolfHP -= 35;
            if (GolWolfHP < 0)
            {
                BHCE.FullChkGold();
                coinScript.gold += 1;
                GWR.GWObjPool.PushObject(this.gameObject);
            }
            BHC.BullPool.PushObject(other.gameObject);
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("BHBackBullet"))
        {
            SoundM.PlayBHMonsterHit();
            StartCoroutine(BackMove());
            GolWolfHP -= 35;
            if (GolWolfHP < 0)
            {
                BHCE.FullChk();
                coinScript.gold += 1;

                GWR.GWObjPool.PushObject(this.gameObject);
            }
            BHC.BBPool.PushObject(other.gameObject);
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("Ice"))
        {
            if (!isIceFirst)
            {
                isIceFirst = true;
                StartCoroutine(StopForMoment());
            }
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("Wall"))
        {
            if (!isWallFirst)
            {
                isWallFirst = true;
                StartCoroutine(BackMove());
            }
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("Map"))//
        {
            isColMap = true;
            a = Random.Range(0, 2);
        }
        else if (other.tag.Equals("Bomb"))
        {
            if (!isIceFirst)
            {
                SoundM.PlayBHMonsterHit();
                isIceFirst = true;
                StartCoroutine(BombCol(other.transform.position));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isColPl = false;
        }
    }

    IEnumerator AttackAI()
    {
        while (true)
        {
            if (!ScoreScript.isFinished)
            {
                if (isColPl)
                {
                    yield return new WaitForSeconds(1.3f / WolfScript.Calculation);
                    GolWolfAnim.SetBool("isAttack", true);
                    BirAnim.SetBool("isAttack", false);
                    BirAnim.SetBool("isRun", false);
                    BirAnim.SetBool("isCrushed", true);
                    SoundM.PlayPlayerHit();
                    //때리는애님
                    Camera.transform.position += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.1f / WolfScript.Calculation);
                    Camera.transform.position -= new Vector3(0, 2, 0);
                    yield return new WaitForSeconds(0.1f / WolfScript.Calculation);
                    Camera.transform.position += new Vector3(0, 2, 0);
                    yield return new WaitForSeconds(0.1f / WolfScript.Calculation);
                    Camera.transform.position -= new Vector3(0, 2, 0);
                    yield return new WaitForSeconds(0.1f / WolfScript.Calculation);
                    Camera.transform.position += new Vector3(0, 1, 0);
                    PanDie.PanHP -= 70;
                    yield return new WaitForSeconds(0.3f / WolfScript.Calculation);
                    GolWolfAnim.SetBool("isAttack", false);
                    BirAnim.SetBool("isCrushed", false);
                    BirAnim.SetBool("isRun", true);
                }
            }
            yield return new WaitForSeconds(0.5f / WolfScript.Calculation);
        }
    }

    IEnumerator Destroy_Time()
    {
        yield return new WaitForSeconds(10);
        this.transform.FindChild("Mad").gameObject.SetActive(true);
        speed = 1.5f;
        yield return new WaitForSeconds(5);
        this.transform.FindChild("Mad").gameObject.SetActive(false);
        speed = 0;
        GolWolfAnim.SetBool("isExhaust", true);
        yield return new WaitForSeconds(2);
        GWR.GWObjPool.PushObject(this.gameObject);
    }

    IEnumerator StopForMoment()
    {
        isColWl = true;
        this.GetComponent<Animator>().enabled = false;
        IceWolf.SetActive(true);
        GolWolfHP -= 70;
        yield return new WaitForSeconds(3f / WolfScript.Calculation);
        IceWolf.SetActive(false);
        if (GolWolfHP < 0)
        {
            BHCE.FullChkGold();
            coinScript.gold += 1;
            GWR.GWObjPool.PushObject(this.gameObject);
        }
        this.GetComponent<Animator>().enabled = true;
        isColWl = false;
        isIceFirst = false;
    }

    IEnumerator BackMove()
    {
        GolWolfAnim.SetBool("isCrushed", true);
        //넉백애니메이션
        yield return new WaitForSeconds(0.1f / WolfScript.Calculation);
        isColWl = true;

        WolfTr.Translate(0, 0, -2.5f);
        yield return new WaitForSeconds(0.3f / WolfScript.Calculation);
        GolWolfAnim.SetBool("isCrushed", false);
        isColWl = false;
        isWallFirst = false;
    }

    IEnumerator BombCol(Vector3 BombPos)
    {
        SoundM.PlayBHMonsterHit();
        GolWolfAnim.SetBool("isCrushed", true);
        isColWl = true;
        Vector3 MoveVec = BombPos - this.transform.position;
        MoveVec = MoveVec.normalized;
        MoveVec -= new Vector3(0, MoveVec.y, 0);
        GolWolfHP -= 60;
        int i = 0;
        while (i < 9)
        {
            i++;
            this.transform.position += (-MoveVec);
            yield return new WaitForEndOfFrame();
        }
        if (GolWolfHP < 0)
        {
            BHCE.FullChkGold();
            coinScript.gold += 1;
            GWR.GWObjPool.PushObject(this.gameObject);
        }
        isIceFirst = false;
        isColWl = false;
        GolWolfAnim.SetBool("isCrushed", false);
        yield return new WaitForEndOfFrame();
    }

    void Update()
    {
        thisRig.velocity = Vector3.zero;
        thisRig.angularVelocity = Vector3.zero;
        if (Time.timeScale > 0)
        {
            if (!isColPl && !isColWl)
            {
                playerPos = PlTr.position;
                float dX = playerPos.x - wolfPos.x;
                float dY = playerPos.z - wolfPos.z;
                if (ScoreScript.isFinished == false)
                {
                    if (Time.time >= NextTime)
                    {
                        NextTime = Time.time + 50;
                        GolWolfSpeed += 0.02f * WolfScript.Calculation;
                    }
                    if (!isColMap)
                    {
                        wolfPos = WolfTr.position;
                        angle = Mathf.Atan2(dX, dY);
                        WolfTr.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);

                        WolfTr.Translate(new Vector3(0, 0, 1) * GolWolfSpeed * speed * WolfScript.Calculation);
                    }
                    else//
                    {
                        if (!RotChg)
                        {
                            if (a.Equals(0))
                            {
                                WolfTr.Rotate(0, 50, 0);
                            }
                            else
                            {
                                WolfTr.Rotate(0, -50, 0);
                            }
                            RotChg = true;
                        }
                        else
                        {
                            WolfTr.Translate(new Vector3(0, 0, 1) * GolWolfSpeed * speed * WolfScript.Calculation);
                        }
                        b++;
                        if (b >= 65 / WolfScript.Calculation)
                        {
                            RotChg = false;
                            b = 0;
                            isColMap = false;
                        }
                    }
                }
            }
        }
    }
}