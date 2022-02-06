using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class RightTouchMove : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public GameObject Player;
    public GameObject Pan;
    public GameObject UpPan;
    public GameObject GanziPan;
    public GameObject UpOnePan;
    public GameObject UpTwoPan;
    bool isPress = false;
    public bool isPause;
    public int Upgrade;
    private Image ButtonImage;
    public float speed;

    public GameObject PandaTwo;
    Quaternion rotatTwo;
    // Use this for initialization
    void Start()
    {
        ButtonImage = this.GetComponent<Image>();

            if (PlayerPrefs.GetInt("SwimShoes1").Equals(2))
            {
                Pan.SetActive(false);
                GanziPan.SetActive(true);
                Player = GanziPan.gameObject;
                Upgrade = 0;
            }

            else if (PlayerPrefs.GetInt("SwimShoes2").Equals(2))
            {
                Pan.SetActive(false);
                UpOnePan.SetActive(true);
                Player = UpOnePan.gameObject;
                Upgrade = 1;
            }
            else if (PlayerPrefs.GetInt("SwimShoes3").Equals(2))
            {
                Pan.SetActive(false);
                UpTwoPan.SetActive(true);
                Player = UpTwoPan.gameObject;
                Upgrade = 2;
            }
            else if (PlayerPrefs.GetInt("SwimUpgrade").Equals(1))
            {
                Pan.SetActive(false);
                UpPan.SetActive(true);
                Player = UpPan.gameObject;
                Upgrade = 0;
            }
            else
            {
                Pan.SetActive(true);
                Player = Pan.gameObject;
                Upgrade = 0;
            }
        
        rotatTwo = PandaTwo.transform.rotation;
        if (Upgrade.Equals(0)) speed = 0.025f;
        else if (Upgrade.Equals(1)) speed = 0.03f;
        else speed = 0.045f;
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
        OnDrag(ped);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPress)
        {
            if (!isPause)
            {
                if (Player.transform.position.z <= 1.5f)
                {
                    Player.transform.rotation = rotatTwo;
                    Player.transform.position = Player.transform.position + new Vector3(0, 0, speed);
                }
            }
        }

    }
}
