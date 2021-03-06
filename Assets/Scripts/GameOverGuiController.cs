﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverGuiController : MonoBehaviour {

	public UIInput uiInput;
	public UILabel scoreLabel;

	// Use this for initialization
	void Start () 
	{
		scoreLabel.text = gameManager.i.points.ToString();
		Debug.Log("Tela de Game Over");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnOkBtnPress()
	{
		Debug.Log("Apertou o botão ok na tela de GameOver!!!");
		gameManager.i.addScore(new ScoreEntry() {score = gameManager.i.points, name = uiInput.value});
		Application.LoadLevel(3);
	}

	public void OnNameSubmit()
	{
		gameManager.i.addScore(new ScoreEntry() {score = gameManager.i.points, name = uiInput.value});
		Application.LoadLevel(3);
	}

}
