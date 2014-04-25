using UnityEngine;
using System.Collections;

public class HighScoresGuiController : MonoBehaviour {

	public Transform table;
	public Transform scoreEntryLabel;

	// Use this for initialization
	void Start () 
	{
		int scoreCounter = 1;
		foreach (ScoreEntry scoreEntry in gameManager.i.highScores) 
		{
			string text = scoreCounter + " - " + scoreEntry.name + "  ->  " + scoreEntry.score;
			Transform label = Instantiate(scoreEntryLabel, table.position, Quaternion.identity) as Transform;
			label.transform.parent = table;
			label.GetComponent<UILabel>().text = text;

			scoreCounter++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnPlayAgainBtnPress()
	{
		Application.LoadLevel(1);
	}
}
