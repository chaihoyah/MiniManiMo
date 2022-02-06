using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WolfScript : MonoBehaviour
{
    public static float Calculation = 1.5f;
    public static int Calculation1= 1;
    float speed;
    GameObject player;
    public int WolfHP;
    public float WolfSpeed;
    public PandaDie PanDie;
    public WolfRespawn WR;
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
    Animator WolfAnim;
    public Animator BirAnim;
    public SoundManager SoundM;
    float NextTime;
    int Strength;
    int b;//
    int a;//
    bool RotChg;
    public BHCoinEffect BHCE;

    public GameObject FiredWolf;
    private void Awake()
    {
        FiredWolf = GameObject.Find("FiredWolf");
        BHCE = GameObject.Find("WolfPool").GetComponent<BHCoinEffect>();
        isFirst = true;
        if (RoundController_Snow.round.Equals(2) && !PlayerPrefs.GetInt("isWolfTuto").Equals(0))
        {
            Calculation = 2;
            Calculation1 = 2;
        }

        else
        {
            Calculation = 1.5f;
            Calculation1 = 1;
        }
        if (BH_Tuto.isPanTuto) Strength = 10;
        else Strength = 70;
    }
    private void Start()
    {
        WolfSpeed = 0.2f;
        NextTime = 40;
        wolfPos = this.transform.position;
        BHC = GameObject.Find("WolfPool").GetComponent<BHBulletControl>();
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
        BirAnim = player.GetComponent<Animator>();
        WolfAnim = this.GetComponent<Animator>();
        Camera = GameObject.Find("Main Camera");
        thisRig = this.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        WolfHP = 100;
        if (isFirst)
        {
            player = GameObject.Find("player");
            PlTr = player.transform;
            WolfTr = this.transform;
            PanDie = GameObject.Find("player").GetComponent<PandaDie>();
            WR = GameObject.Find("WolfPool").GetComponent<WolfRespawn>();
            IceWolf = this.transform.FindChild("Ice").gameObject;
            WolfAnim = this.GetComponent<Animator>();
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
        if (isColPl) isColPl = false;
        if (isColWl) isColWl = false;
        if (isColMap) isColMap = false; //
        WolfAnim.SetBool("isExhaust", false);
        WolfAnim.SetBool("isAttack", false);
        WolfAnim.SetBool("isCrush", false);
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
            BHCE.FullChk();
            coinScript.coin += 20*Calculation1;

            GameObject FW = Instantiate(FiredWolf, new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, this.transform.position.z), this.transform.rotation) as GameObject;
            FW.AddComponent<FireWolfDelete>();

            WR.WObjPool.PushObject(this.gameObject);
            if (other.tag.Equals("Map"))//
            {
                isColMap = true;
                a = Random.Range(0, 2);
            }
        }
        else if (other.tag.Equals("LightRegion"))
        {
            SoundM.PlayBHMonsterHit();
            BHCE.FullChk();
            coinScript.coin += 20 * Calculation1;

            GameObject FW = Instantiate(FiredWolf, new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, this.transform.position.z), this.transform.rotation) as GameObject;
            FW.AddComponent<FireWolfDelete>();
            WR.WObjPool.PushObject(this.gameObject);
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
            WolfHP -= 35;
            if (WolfHP < 0)
            {
                BHCE.FullChk();
                coinScript.coin += 20 * Calculation1;

                WR.WObjPool.PushObject(this.gameObject);
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
            WolfHP -= 35;
            if (WolfHP < 0)
            {
                BHCE.FullChk();
                coinScript.coin += 20 * Calculation1;

                WR.WObjPool.PushObject(this.gameObject);
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
                SoundM.PlayBHMonsterHit();
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
                if (isColPl && !isColWl)
                {
                    WolfAnim.SetBool("isAttack", true);
                    BirAnim.SetBool("isRun", false);
                    BirAnim.SetBool("isAttack", false);
                    BirAnim.SetBool("isCrushed", true);

                    PanDie.PanHP -= Strength;
                    SoundM.PlayPlayerHit();
                    //때리는애님
                    Camera.transform.position += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.1f / Calculation);
                    Camera.transform.position -= new Vector3(0, 2, 0);
                    yield return new WaitForSeconds(0.1f / Calculation);
                    Camera.transform.position += new Vector3(0, 2, 0);
                    yield return new WaitForSeconds(0.1f / Calculation);
                    Camera.transform.position -= new Vector3(0, 2, 0);
                    yield return new WaitForSeconds(0.1f / Calculation);
                    Camera.transform.position += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.3f / Calculation);
                    WolfAnim.SetBool("isAttack", false);
                    BirAnim.SetBool("isCrushed", false);
                    BirAnim.SetBool("isRun", true);
                    yield return new WaitForSeconds(1.3f / Calculation);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator StopForMoment()
    {
        isColWl = true;
        this.GetComponent<Animator>().enabled = false;
        IceWolf.SetActive(true);
        WolfHP -= 70;
        yield return new WaitForSeconds(3f / Calculation);
        IceWolf.SetActive(false);
        if (WolfHP < 0)
        {
            BHCE.FullChk();
            coinScript.coin += 20 * Calculation1;

            WR.WObjPool.PushObject(this.gameObject);
        }
        this.GetComponent<Animator>().enabled = true;
        isColWl = false;
        isIceFirst = false;
    }

    IEnumerator BombCol(Vector3 BombPos)
    {
        SoundM.PlayBHMonsterHit();
        WolfAnim.SetBool("isCrushed", true);
        isColWl = true;
        Vector3 MoveVec = BombPos - this.transform.position;
        MoveVec = MoveVec.normalized;
        MoveVec -= new Vector3(0, MoveVec.y, 0);
        WolfHP -= 60;
        int i = 0;
        while (i < 9)
        {
            i++;
            this.transform.position += (-MoveVec);
            yield return new WaitForEndOfFrame();
        }
        if (WolfHP < 0)
        {
            BHCE.FullChk();
            coinScript.coin += 20 * Calculation1;

            WR.WObjPool.PushObject(this.gameObject);
        }
        isIceFirst = false;
        isColWl = false;
        WolfAnim.SetBool("isCrushed", false);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator BackMove()
    {
        WolfAnim.SetBool("isCrushed", true);
        //넉백애니메이션
        yield return new WaitForSeconds(0.1f / Calculation);
        isColWl = true;

        WolfTr.Translate(0, 0, -2.5f);
        yield return new WaitForSeconds(0.3f / Calculation);
        WolfAnim.SetBool("isCrushed", false);
        isColWl = false;
        isWallFirst = false;
    }



    IEnumerator Destroy_Time()
    {
        yield return new WaitForSeconds(10);
        this.transform.FindChild("Mad").gameObject.SetActive(true);
        speed = 1.5f;
        yield return new WaitForSeconds(5);
        this.transform.FindChild("Mad").gameObject.SetActive(false);
        speed = 0;
        WolfAnim.SetBool("isExhaust", true);
        yield return new WaitForSeconds(2);
        WR.WObjPool.PushObject(this.gameObject);
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
                        WolfSpeed += 0.02f * Calculation;
                    }
                    if (!isColMap)
                    {
                        wolfPos = WolfTr.position;
                        angle = Mathf.Atan2(dX, dY);
                        WolfTr.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);

                        WolfTr.Translate(new Vector3(0, 0, 1) * WolfSpeed * speed * Calculation);
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
                            WolfTr.Translate(new Vector3(0, 0, 1) * WolfSpeed * speed * Calculation);
                        }
                        b++;
                        if (b >= 65 / Calculation)
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