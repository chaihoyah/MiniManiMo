using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePotalTwo : MonoBehaviour
{
    public GameObject Move3;

    public GameObject panda;

    private void OnEnable()
    {
        panda = GameObject.Find("MazePanda");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            panda.transform.position = Move3.transform.position;

        }
    }
}