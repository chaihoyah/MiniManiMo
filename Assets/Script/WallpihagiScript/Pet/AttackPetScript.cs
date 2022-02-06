using UnityEngine;
using System.Collections;

public class AttackPetScript : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject Pet;

    public static bool attack;

    void Start()
    {
        if (PlayerPrefs.GetInt("DdrPet1") == 2) StartCoroutine(Attack());
        else
        {
            Pet.SetActive(false);
            Bullet.SetActive(false);
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (WallCount.isFinished != true)
            {
                attack = true;
                Bullet.SetActive(true);
                StartCoroutine(BulletMove());
            }
        }
    }

    IEnumerator BulletMove()
    {
        while (attack)
        {
            Bullet.transform.Translate(0, -0.2f, 0);
            yield return new WaitForEndOfFrame();
        }
    }

}