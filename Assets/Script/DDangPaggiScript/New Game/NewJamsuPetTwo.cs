using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJamsuPetTwo : MonoBehaviour
{

    public GameObject Panda;
    public static bool PetTwoDie = true;
    Vector3 MoveVec;
    // Use this for initialization
    void Start()
    {
        Panda = VisionMove_Button.Player;
        PetTwoDie = false;
        MoveVec = Vector3.zero;
        StartCoroutine(PetMove());
    }

    IEnumerator PetMove()
    {
        while (true)
        {
            if (Vector3.Distance(Panda.transform.position, this.transform.position) > 25)
            {
                float dX = Panda.transform.position.x - this.transform.position.x;
                float dY = Panda.transform.position.z - this.transform.position.z;
                float angle = Mathf.Atan2(dX, dY);
                this.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);
                this.transform.Translate(0, 0, 0.23f);
            }
            if (PetTwoDie) Destroy(this.gameObject);
            yield return new WaitForEndOfFrame();
        }
    }
}