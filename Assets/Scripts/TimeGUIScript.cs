using UnityEngine;
using System.Collections;

public class TimeGUIScript : MonoBehaviour {

	UILabel label;

	// Use this for initialization
	void Start () 
	{
		label = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		int timeMinutes = (int) gameManager.i.gameTime / 60;
		int timeSeconds = gameManager.i.gameTime % 60;

		label.text = string.Format("Time: 00:{0:d2}:{1:d2}", timeMinutes, timeSeconds);
	}
}
