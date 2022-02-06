using UnityEngine;
using System.Collections;

public class DDangPetTwo : MonoBehaviour {
    public GameObject Panda;
    public GameObject Pan;
    public GameObject UpPan;
    public GameObject GanziPan;
    public GameObject UpOnePan;
    public GameObject UpTwoPan;
    public static bool PetTwoDie;
    Vector3 MoveVec;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("SwimShoes1").Equals(2))
        {
            Panda = GanziPan.gameObject;
        }

        else if (PlayerPrefs.GetInt("SwimShoes2").Equals(2))
        {
            Panda = UpOnePan.gameObject;
        }
        else if (PlayerPrefs.GetInt("SwimShoes3").Equals(2))
        {
            Panda = UpTwoPan.gameObject;
        }
        else if (PlayerPrefs.GetInt("SwimUpgrade").Equals(1))
        {
            Panda = UpPan.gameObject;
        }
        else
        {
            Panda = Pan.gameObject;
        }
        PetTwoDie = false;
        MoveVec = Vector3.zero;
        StartCoroutine(PetMove());
    }

    IEnumerator PetMove()
    {
        while (true)
        {
            if (Vector3.Distance(Panda.transform.position, this.transform.position) > 0.4f)
            {
                MoveVec = Panda.transform.position - this.transform.position;
                MoveVec.Normalize();
                this.transform.position += MoveVec * 0.01f;
            }
            if (PetTwoDie) Destroy(this.gameObject);
            yield return new WaitForEndOfFrame();
        }
    }
}
