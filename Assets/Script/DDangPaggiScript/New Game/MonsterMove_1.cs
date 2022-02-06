using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove_1 : MonoBehaviour {

    public GameObject Shark;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wolf"))
        {
            MonsterMove_Shark MM;
            MM = other.gameObject.transform.GetComponent<MonsterMove_Shark>();
            if (MM.count <= 3 && MM.count != 0)
            {
                MM.count++;
                MM.dX = -MM.dX;             
                float angle = Mathf.Atan2(MM.dX, MM.dY);
                other.gameObject.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);
                other.gameObject.transform.Rotate(0, -90, 0);
            }
            else if (MM.count.Equals(0)) MM.count++;
        }
        else if(other.CompareTag("Mon"))
        {
            MonsterMove MM;
            MM = other.gameObject.transform.GetComponent<MonsterMove>();
            if (MM.count <= 3 && MM.count != 0)
            {
                MM.count++;
                MM.dX = -MM.dX;
                float angle = Mathf.Atan2(MM.dX, MM.dY);
                other.gameObject.transform.rotation = Quaternion.Euler(0, angle * (180 / Mathf.PI), 0);
            }
            else if (MM.count.Equals(0)) MM.count++;
        }
    }
}
