using UnityEngine;
using System.Collections;

public class EnemyZigZag : MonoBehaviour {

	public float maxSpeed = 6;
	public float zigZagTime = 1;


	private EnemyaxisController xAxisController;
	private float updateTime;
 	// Use this for initialization
	void Start () 
	{
		xAxisController = GetComponents<EnemyaxisController>()[0];
		updateTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (updateTime + zigZagTime <= Time.time)
		{
			if (xAxisController.bState == FakeButtonState.negative)
			{
				xAxisController.bState = FakeButtonState.positive;
			}
			else
			{
				xAxisController.bState = FakeButtonState.negative;
			}

			updateTime = Time.time;
		}
		rigidbody2D.velocity = new Vector2(xAxisController.axis * maxSpeed, -maxSpeed);
	}
}
