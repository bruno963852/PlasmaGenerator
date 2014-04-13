using UnityEngine;
using System.Collections;

public class PointsGUIScript : MonoBehaviour {

	UILabel label;

	// Use this for initialization
	void Start () 
	{
		label = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		label.text = "Points: " + gameManager.i.points;
	}
}
