using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public Vector3 Char_One;
	public Vector3 Char_Two;
	public Vector3 Char_Three;
	public Vector3 Char_Four;
	public Vector3 Char_Five;
	public Vector3 Char_Six;
	public Vector3 Char_Seven;
	public Vector3 Char_Eight;
	public Vector3 Char_Nine;
	public Vector3 Char_Ten;
	public Vector3 Char_Eleven;
	public Vector3 Char_Twelve;
	public Vector3 Char_Thirteen;
	public Vector3 Char_Fourteen;
	public Vector3 Char_Fifteen;
	public Vector3 Char_Sixteen;
	public Vector3 Char_Seventeen;
    public Vector3 Char_Tuto;
	public GameObject Panda;
	
	
	// Use this for initialization
	void Start () {
		Char_One = new Vector3 (-19.1f,0.9f,11);
		Char_Two = new Vector3 (-0.85f,19.1f,11);
		Char_Three = new Vector3 (-3.5f,0.9f,11);
		Char_Four = new Vector3 (-6,16.5f,11);
		Char_Five = new Vector3 (-0.9f,15.15f,11);
		Char_Six = new Vector3 (-0.9f,10,11);
		Char_Seven = new Vector3 (-10,0.9f,11);
		Char_Eight = new Vector3 (-0.9f,19.1f,11);
		Char_Nine = new Vector3 (-0.9f,19.1f,11);
		Char_Ten = new Vector3 (-0.9f,15.15f,11);
		Char_Eleven = new Vector3 (-0.85f,0.85f,11);
		Char_Twelve = new Vector3 (-0.85f,19.15f,11);
		Char_Thirteen = new Vector3 (-10,0.85f,11);
		Char_Fourteen = new Vector3 (-15.15f,10,11);
        Char_Fifteen = new Vector3 (-4.15f,18.5f,11);
		Char_Sixteen = new Vector3 (-2.3f,17.7f,11);
		Char_Seventeen = new Vector3 (-0.85f,12.55f,11);
        Char_Tuto = new Vector3(3.84f, 1.29f, 4.22f);
		if(StageScript.Round==1){
			Panda.transform.Translate(Char_One);
		}
		else if(StageScript.Round==2){
			Panda.transform.Translate(Char_Two);
	}
	else if(StageScript.Round==3){
			Panda.transform.Translate(Char_Three);
	}
	else if(StageScript.Round==4){
			Panda.transform.Translate(Char_Four);
	}
	else if(StageScript.Round==5){
			Panda.transform.Translate(Char_Five);
	}
	else if(StageScript.Round==6){
			Panda.transform.Translate(Char_Six);
	}
	else if(StageScript.Round==7){
			Panda.transform.Translate(Char_Seven);
	}
	else if(StageScript.Round==8){
			Panda.transform.Translate(Char_Eight);
	}
	else if(StageScript.Round==9){
			Panda.transform.Translate(Char_Nine);
	}
	else if(StageScript.Round==10){
			Panda.transform.Translate(Char_Ten);
	}
	else if(StageScript.Round==11){
			Panda.transform.Translate(Char_Eleven);
	}
	else if(StageScript.Round==12){
			Panda.transform.Translate(Char_Twelve);
	}
	else if(StageScript.Round==13){
			Panda.transform.Translate(Char_Thirteen);
	}
	else if(StageScript.Round==14){
			Panda.transform.Translate(Char_Fourteen);
	}
	else if(StageScript.Round==15){
			Panda.transform.Translate(Char_Fifteen);
	}
	else if(StageScript.Round==16){
			Panda.transform.position = new Vector3(-24.558f, 1.5f, -25.164f);
	}
	else if(StageScript.Round==17){
            Panda.transform.position = new Vector3(9.2f, 1.06f, 8.7f);
	}
        else if (StageScript.Round == 18)
        {
            Panda.transform.position = new Vector3(0.5f, 1.31f, -0.55f);
        }
        else if (StageScript.Round == 19)
        {
            Panda.transform.position = new Vector3(-6.185f, 1.2f, 18.463f);
        }
        else if (StageScript.Round == 20)
        {
            Panda.transform.position = new Vector3(-1.26f, 0.95f, 7.668f);
        }
        else if (StageScript.Round == 21)
        {
            Panda.transform.position = new Vector3(6.75f, 1.06f, -0.94f);
        }
        else if (StageScript.Round == 22)
        {
            Panda.transform.position = new Vector3(9.2f, 1.06f, 8.7f);
        }
        else if (StageScript.Round == 23)
        {
            Panda.transform.position = new Vector3(9.2f, 1.06f, 8.7f);
        }
        else if (StageScript.Round == 24)
        {
            Panda.transform.position = new Vector3(9.2f, 1.06f, 8.7f);
        }
        else if (StageScript.Round == 25)
        {
            Panda.transform.position = new Vector3(9.2f, 1.06f, 8.7f);
        }
        else if(StageScript.Round==0)
        {
            Panda.transform.position = (Char_Tuto);
        }

       
}
}