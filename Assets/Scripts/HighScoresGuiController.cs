using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScoresGuiController : MonoBehaviour {
	
	public Transform scoresContainer;

	// Use this for initialization
	void Start () 
	{
		int i = 0;
		foreach (ScoreEntry scoreEntry in gameManager.i.highScores) 
		{
			scoresContainer.GetChild(i).GetComponent<UILabel>().text = (i + 1) + " - " + scoreEntry.name + " - " + scoreEntry.score;
			i++;
		}

		Debug.Log("High Scores carregados!");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnPlayAgainBtnPress()
	{
		gameManager.i.gameTime =  60;
		gameManager.i.points = 0;
		Application.LoadLevel(1);
	}

	public void OnExitBtnPress()
	{
		Application.Quit();
	}
}
