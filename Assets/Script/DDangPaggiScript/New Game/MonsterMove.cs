using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{

    public GameObject Player;
    public GameObject[] PlayerPos = new GameObject[6];
    public int count = 0;
    int num;
    public Vector3 MoveVector;
    public GameObject PoolController;
    private MonsterRespawn_2 MR2;
    public float dX, dY;

    void Awake()
    {
        PoolController = GameObject.Find("PoolAndCameraController");

        MR2 = PoolController.GetComponent<MonsterRespawn_2>();
    }

    void OnEnable()
    {
        Player = VisionMove_Button.Player;
        num = Random.Range(0, 6);
        count = 0;
        for (int i = 0; i < 6; i++) PlayerPos[i] = Player.transform.GetChild(i).gameObject;
        MoveVector = new Vector3(PlayerPos[num].transform.position.x - this.gameObject.transform.position.x, 0, PlayerPos[num].transform.position.z - this.gameObject.transform.position.z);
        MoveVector.Normalize();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {

            dX = PlayerPos[num].transform.position.x - this.transform.position.x;
            dY = PlayerPos[num].transform.position.z - this.transform.position.z;
            float angle = Mathf.Atan2(dX, dY);
            this.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);
            while (true)
            {
                if (Time.timeScale.Equals(1))
                {
                    this.gameObject.transform.Translate(0, 0, 0.5f);
                    if (this.gameObject.transform.position.x < -180 || this.gameObject.transform.position.x > 180 || this.gameObject.transform.position.z > 150 || this.gameObject.transform.position.z < -150)
                    {
                        yield return new WaitForSeconds(1);
                        MR2.ObjP.PushObject(this.gameObject);
                    }
                }
                yield return new WaitForSeconds(0.01f);
            }
    }
}