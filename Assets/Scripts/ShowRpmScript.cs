using UnityEngine;
using System.Collections;

public class ShowRpmScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		if (!gameManager.i.showRpm)
		{
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<UILabel>().text = "RPM: " + gameManager.i.rpm;
	}
}
