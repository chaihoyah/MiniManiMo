using UnityEngine;
using System.Collections;

public class CoinRotate : MonoBehaviour
{
    Quaternion rotat;
    public SoundManager SoundM;
    public Vector3 CoinPetPos;
    int RotatChk;
    public bool CoinMove;
    Vector3 MovPos;
    Vector3 OriginPos;
    Quaternion OriginRot;
    public Wall Wl;
    int Point;
    public CoinEffect CE;
    public Animator RabAnim;
    bool isRotating;
    // Use this for initialization

    void Start()
    {
        if (PlayerPrefs.GetInt("DdrPet2").Equals(2))
            RabAnim = GameObject.Find("Coinpet").transform.GetChild(1).GetComponent<Animator>();
        Point = 5;
        OriginPos = new Vector3(0, 0, 0);
        OriginRot = new Quaternion(90, 0, 0, 0);
        CoinMove = false;
        rotat = new Quaternion();
        rotat = Quaternion.Euler(0, 10, 0);
        CoinPetPos = new Vector3(-0.869f, -0.235f, 2.1f);
        Wl = GameObject.Find("WallPool").GetComponent<Wall>();
        SoundM = GameObject.Find("soundmanager").GetComponent<SoundManager>();
        CE = GameObject.Find("CoinPool").GetComponent<CoinEffect>();
        Invoke("PizzaChk", 1.5f);
    }

    void PizzaChk()
    {
        if (Wl.isPota) Point = 6;
    }


    void OnTriggerEnter(Collider order)
    {
        if (order.CompareTag("Player"))
        {
            CE.FullChk();
            SoundM.PlayCoin();
            WallCount.Point += Point;
            CoinRespawn.CoinPool.PushObject(this.transform.parent.gameObject);
        }
        else if (order.CompareTag("CoinPet"))
        {
            CoinMove = true;
        }
        else if (order.CompareTag("CoinPetPa"))
        {
            CE.FullChk();
            CoinMove = false;
            WallCount.Point += Point;
            SoundM.PlayCoin();
            /**   if (!CoinRotate.isRotating)
                  {
                      RabAnim.SetBool("isDo", true);
                      StartCoroutine(RotateStop());
                  }**/
            CoinRespawn.CoinPool.PushObject(this.transform.parent.gameObject);
        }
    }

    /**   IEnumerator RotateStop()
       {
         CoinRotate.isRotating = true;
           yield return new WaitForSeconds(1f);
           RabAnim.SetBool("isDo", false);
         CoinRotate.isRotating = false;

       }**/

    void Update()
    {
        rotat = Quaternion.Euler(90, RotatChk * 10, 90);
        this.transform.rotation = rotat;


        RotatChk++;

        if (RotatChk.Equals(360)) RotatChk = 0;
        if (CoinMove)
        {
            MovPos = CoinPetPos - this.transform.parent.position;
            MovPos.Normalize();
            this.transform.parent.position = this.transform.parent.position + (MovPos * 0.3f);
        }

    }
}