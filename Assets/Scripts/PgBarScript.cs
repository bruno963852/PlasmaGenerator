using UnityEngine;
using System.Collections;

public class PgBarScript : MonoBehaviour {

	UISlider slider;

	UISprite backGround;

	UISprite overlay;
	// Use this for initialization
	void Start () 
	{
		slider = GetComponent<UISlider>();

		backGround = GetComponent<UISprite>();

		overlay = transform.GetChild(2).GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		slider.value = gameManager.i.rpm;

		if (slider.value >= 0.75f && !gameManager.i.isShotBlocked)
		{
			overlay.color = Color.cyan;
			backGround.color = Color.green;
		}
		else if (slider.value >= 0.5f && !gameManager.i.isShotBlocked)
		{
			overlay.color = Color.green;
			backGround.color = Color.green;
		}
		else if (slider.value >= 0.25f && !gameManager.i.isShotBlocked)
		{
			overlay.color = Color.blue;
			backGround.color = Color.green;
		}
		else if (!gameManager.i.isShotBlocked)
		{
			overlay.color = Color.red;
			backGround.color = Color.green;
		}
		else
		{
			slider.value = 0;
			backGround.color = Color.red;
		}
	}
}
