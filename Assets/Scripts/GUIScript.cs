using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {


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
		//GUI.Box(new Rect(10,Screen.height - 50, 40, 500), "Seconds: " + Time.time);
		GUI.Label(new Rect(10,Screen.height - 30, 150, 20), "Seconds: " + Time.time);
		GUI.Label(new Rect(Screen.width - 110 ,Screen.height - 30, 100, 20), "Points: " + gameManager.i.points);
	}
}
