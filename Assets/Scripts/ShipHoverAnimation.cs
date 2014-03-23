using UnityEngine;
using System.Collections;

public class ShipHoverAnimation : MonoBehaviour {

	private ShipController shipController;
	private HoverState hoverState = HoverState.center;
	private ShipMovingState currentMovingState = ShipMovingState.notMoving;
	private float updateTime;
	private Animator animator;

	public float frameTime = 0.2f;

	// Use this for initialization
	void Start () 
	{
		shipController = GetComponent<ShipController>();
		animator = GetComponent<Animator>();
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentMovingState != shipController.movingState)
		{
			updateTime = Time.time;
			currentMovingState = shipController.movingState;
		}

		if (shipController.movingState == ShipMovingState.movingLeft)
		{
			//updateTime = Time.time;
			doAnimation(frameTime, -1);
		}
		if (shipController.movingState == ShipMovingState.movingRight)
		{
			doAnimation(frameTime, +1);
		}
	}	

	private void doAnimation(float frameTime, int increment)
	{
		if (updateTime + frameTime <= Time.time)
		{
			Debug.Log("Entrou no frame! Estado: " + (int)hoverState);
			hoverState += increment;
			if (hoverState < HoverState.fullLeft)
			{
				hoverState = HoverState.fullLeft;
			}
			else if (hoverState > HoverState.fullRight)
			{
				hoverState = HoverState.fullRight;
			}
			animator.SetFloat("HoverState", (float) hoverState);
			Debug.Log ("Animou frame: " + (int)hoverState);
			updateTime = Time.time;
		}

	}
}

public enum HoverState
{
	fullLeft,
	middleLeft,
	center,
	middleRight,
	fullRight
}
