using UnityEngine;
using System.Collections;

public class AxisController : MonoBehaviour 
{

	public float axis = 0;
	public float sensitivity = 0.03f;
	public float gravity = 0.1f;
	public float deadZone = 0.03f;
	public bool restatOnPress = false;

	private ButtonState bState = ButtonState.up;
	
	// Update is called once per frame
	void Update () 
	{
		checkButtonState();

		if (bState == ButtonState.leftDown)
		{
			if (axis > 0)
				axis -= gravity;
			else
				axis -= sensitivity;
			if (axis < -1)
				axis = -1;
		}
		else if (bState == ButtonState.rightDown)
		{
			if (axis < 0)
				axis += gravity;
			else
				axis += sensitivity;
			if (axis > 1)
				axis = 1;
		}
		else if (axis < 0)
		{
			if (axis < -deadZone)
			{
				axis += gravity;
			}
			else
			{
				axis = 0;
			}
		}
		else if (axis > 0)
		{
			if (axis > deadZone)
			{
				axis -= gravity;
			}
			else
			{
				axis = 0;
			}
		}
	}

	private void checkButtonState()
	{
		if (gameManager.i.btController.getLeftButtonDown() && bState != ButtonState.leftDown)
		{
			if(restatOnPress)
				axis = 0;
			bState = ButtonState.leftDown;
		}
		if (gameManager.i.btController.getRightButtonDown() && bState != ButtonState.rightDown)
		{
			if(restatOnPress)
				axis = 0;
			bState = ButtonState.rightDown;
		}
		if (gameManager.i.btController.getLeftButtonUp() && bState == ButtonState.leftDown)
		{
			bState = ButtonState.up;
		}
		if (gameManager.i.btController.getRightButtonUp() && bState == ButtonState.rightDown)
		{
			bState = ButtonState.up;
		}
	}
}
enum ButtonState
{
	leftDown,
	rightDown,
	up
}
