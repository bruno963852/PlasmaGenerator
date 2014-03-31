using UnityEngine;
using System.Collections;

//Esse script controla a GUI da fase
public class Stage01GUIScript : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		//label com o tempo
		GUI.Label(new Rect(10,Screen.height - 30, 150, 20), "Seconds: " + Time.timeSinceLevelLoad);
		//Label com a pontuação
		GUI.Label(new Rect(Screen.width - 110 ,Screen.height - 30, 100, 20), "Points: " + gameManager.i.points);
	}
}
