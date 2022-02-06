using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public GameObject Tuto_Map;
	public GameObject Map_One;
	public GameObject Map_Two;
	public GameObject Map_Three;
	public GameObject Map_Four;
	public GameObject Map_Five;
	public GameObject Map_Six;
	public GameObject Map_Seven;
	public GameObject Map_Eight;
	public GameObject Map_Nine;
	public GameObject Map_Ten;
	public GameObject Map_Eleven;
	public GameObject Map_Twelve;
	public GameObject Map_Thirteen;
	public GameObject Map_Fourteen;
	public GameObject Map_Fifteen;
	public GameObject Map_Sixteen;
	public GameObject Map_Seventeen;
    public GameObject Map_Eighteen;
    public GameObject Map_Nineteen;
    public GameObject Map_Twenty;
    public GameObject Map_TwentyOne;
    public GameObject Map_TwentyTwo;
    public GameObject Map_TwentyThree;
    public GameObject Map_TwentyFour;
    public GameObject Map_TwentyFive;
    public Vector3 Vec;
	
	// Use this for initialization
	void Start () {
		Vec = new Vector3 (0, 0, 0);
		
		if(StageScript.Round==1){
			Instantiate(Map_One , Vec , Map_One.transform.rotation);
		}
		else if(StageScript.Round==2){
			Instantiate (Map_Two, Vec, Map_Two.transform.rotation);
	}
	else if(StageScript.Round==3){
			Instantiate (Map_Three, Vec, Map_Three.transform.rotation);
	}
	else if(StageScript.Round==4){
			Instantiate (Map_Four, Vec, Map_Four.transform.rotation);
	}
	else if(StageScript.Round==5){
			Instantiate (Map_Five, Vec, Map_Five.transform.rotation);
	}
	else if(StageScript.Round==6){
			Instantiate (Map_Six, Vec, Map_Six.transform.rotation);
	}
	else if(StageScript.Round==7){
			Instantiate (Map_Seven, Vec, Map_Seven.transform.rotation);
	}
	else if(StageScript.Round==8){
			Instantiate (Map_Eight, Vec, Map_Eight.transform.rotation);
	}
	else if(StageScript.Round==9){
			Instantiate (Map_Nine, Vec, Map_Nine.transform.rotation);
	}
	else if(StageScript.Round==10){
			Instantiate (Map_Ten, Vec, Map_Ten.transform.rotation);
	}
	else if(StageScript.Round==11){
			Instantiate (Map_Eleven, Vec, Map_Eleven.transform.rotation);
	}
	else if(StageScript.Round==12){
			Instantiate (Map_Twelve, Vec, Map_Twelve.transform.rotation);
	}
	else if(StageScript.Round==13){
			Instantiate (Map_Thirteen, Vec, Map_Thirteen.transform.rotation);
	}
	else if(StageScript.Round==14){
			Instantiate (Map_Fourteen, Vec, Map_Fourteen.transform.rotation);
	}
	else if(StageScript.Round==15){
			Instantiate (Map_Fifteen, Vec, Map_Fifteen.transform.rotation);
	}
	else if(StageScript.Round==16){
			Instantiate (Map_Sixteen, Map_Sixteen.transform.position, Map_Sixteen.transform.rotation);
	}
	else if(StageScript.Round==17){
			Instantiate (Map_Seventeen, Map_Seventeen.transform.position, Map_Seventeen.transform.rotation);
	}
        else if (StageScript.Round == 18)
        {
            Instantiate(Map_Eighteen, Map_Eighteen.transform.position, Map_Eighteen.transform.rotation);
        }
        else if (StageScript.Round == 19)
        {
            Instantiate(Map_Nineteen, Map_Nineteen.transform.position, Map_Nineteen.transform.rotation);
        }
        else if (StageScript.Round == 20)
        {
            Instantiate(Map_Twenty, Map_Twenty.transform.position, Map_Twenty.transform.rotation);
        }
        else if (StageScript.Round == 21)
        {
            Instantiate(Map_TwentyOne, Map_TwentyOne.transform.position, Map_TwentyOne.transform.rotation);
        }
        else if (StageScript.Round == 22)
        {
            Instantiate(Map_TwentyTwo, Map_TwentyTwo.transform.position, Map_TwentyTwo.transform.rotation);
        }
        else if (StageScript.Round == 23)
        {
            Instantiate(Map_TwentyThree, Map_TwentyThree.transform.position, Map_TwentyThree.transform.rotation);

        }
        else if (StageScript.Round == 24)
        {
            Instantiate(Map_TwentyFour, Map_TwentyFour.transform.position, Map_TwentyFour.transform.rotation);
        }
        else if (StageScript.Round == 25)
        {
            Instantiate(Map_TwentyFive, Map_TwentyFive.transform.position, Map_TwentyFive.transform.rotation);
        }
        else if(StageScript.Round == 0)
    {
            Instantiate(Tuto_Map, Vec, Tuto_Map.transform.rotation);
    }
}
}