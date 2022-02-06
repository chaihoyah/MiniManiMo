using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ListItem : MonoBehaviour {

	public Text rankLabel;
	public Text nameLabel;
	public Text scoreLabel;

	public void SetItem(ListItemData itemdata)
	{
		rankLabel.text = itemdata.Rank.ToString();
		nameLabel.text = itemdata.username;
		scoreLabel.text = itemdata.score.ToString();
	}
	
	public void SetItem(int rank, string username, int score)
	{
		rankLabel.text = rank.ToString();
		nameLabel.text = username;
		scoreLabel.text = score.ToString();
	}
}
