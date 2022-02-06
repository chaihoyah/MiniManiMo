using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSharkMove : MonoBehaviour
{
    public GameObject Player;
    GameObject[] PlayerPos = new GameObject[6];
    public Vector3 MoveVector;
    public GameObject Pool1;
    private MonsterResMangShark MR1;
    public GameObject Warning;

    void Awake()
    {
        Pool1 = GameObject.Find("PoolAndCameraController");
        MR1 = Pool1.GetComponent<MonsterResMangShark>();

    }

    void OnEnable()
    {
        Player = VisionMove_Button.Player;
        MoveVector = new Vector3(Player.transform.position.x - this.gameObject.transform.position.x, 0, Player.transform.position.z - this.gameObject.transform.position.z);
        MoveVector.Normalize();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        if (Time.timeScale.Equals(1))
        {
            float dX = Player.transform.position.x - this.transform.position.x;
            float dY = Player.transform.position.z - this.transform.position.z;
            float angle = Mathf.Atan2(dX, dY);
            this.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);
            this.transform.Rotate(0, -90, 0);
            Warning = this.transform.GetChild(0).gameObject;
            Warning.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Warning.SetActive(false);
            while (true)
            {
                this.gameObject.transform.position += (1.5f * MoveVector);

                if (this.gameObject.transform.position.x < -140 || this.gameObject.transform.position.x > 140 || this.gameObject.transform.position.y > 120 || this.gameObject.transform.position.y < -120)
                {
                    yield return new WaitForSeconds(1);
                    MR1.ObjP.PushObject(this.gameObject);
                }
                yield return new WaitForEndOfFrame();
            }
        }

    }
}