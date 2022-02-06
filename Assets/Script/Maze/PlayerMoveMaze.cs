using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class PlayerMoveMaze : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private GameObject Panda;
    public Button MoveButton;
    private Image ButtonImage;
    bool isPress;
    public Maze_Tuto Tut;

    public static float speed;
    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        ButtonImage = MoveButton.GetComponent<Image>();
        Panda = GameObject.Find("MazePanda");

        isPress = false;
        speed = -0.03f;
    }


    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(ButtonImage.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            isPress = true;
        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        isPress = false;
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        Tut.TutoBool[0] = true;
        OnDrag(ped);
    }


    // Update is called once per frame
    void Update()
    {
        if (isPress) Panda.transform.Translate(0, speed, 0);
    }
}
