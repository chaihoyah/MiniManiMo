using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJamsuPetOne : MonoBehaviour
{

    public GameObject Panda;
    public static bool PetOneDie = true;
    Vector3 MoveVec;
    // Use this for initialization
    void Start()
    {
        Panda = VisionMove_Button.Player;
        PetOneDie = false;
        MoveVec = Vector3.zero;
        StartCoroutine(PetMove());
    }

    IEnumerator PetMove()
    {
        while (true)
        {
            if (Vector3.Distance(Panda.transform.position, this.transform.position) > 15)
            {
                float dX = Panda.transform.position.x - this.transform.position.x;
                float dY = Panda.transform.position.z - this.transform.position.z;
                float angle = Mathf.Atan2(dX, dY);
                this.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);
                this.transform.Translate(0, 0, 0.26f);
            }
            if (PetOneDie) Destroy(this.gameObject);
            yield return new WaitForEndOfFrame();
        }
    }
}