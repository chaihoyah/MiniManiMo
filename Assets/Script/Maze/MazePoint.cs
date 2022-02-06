using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class MazePoint : MonoBehaviour
{

    private GameObject Pointer;
    private GameObject Panda;


    public Vector3 vect;

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Pointer = GameObject.Find("Pointer");
        Panda = GameObject.Find("MazePanda");
        StartCoroutine(PointerAppear());
    }

    // Update is called once per frame
    IEnumerator PointerAppear()
    {
        while (true)
        {
            vect = new Vector3(Panda.transform.position.x, Panda.transform.position.y - 0.5f, Panda.transform.position.z);

            Instantiate(Pointer, vect, Panda.transform.rotation);
            yield return new WaitForSeconds(7f);
        }
    }
}