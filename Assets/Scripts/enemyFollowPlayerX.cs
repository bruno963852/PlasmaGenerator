using UnityEngine;
using System.Collections;

public class enemyFollowPlayerX : MonoBehaviour {

	public float maxSpeed = 5;

	private Transform player;
	private EnemyaxisController xAxisController;
	// Use this for initialization
	void Start () 
	{
		xAxisController = GetComponents<EnemyaxisController>()[0];

		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.position.x > transform.position.x)
		{
			xAxisController.bState = FakeButtonState.positive;
		}
		else if (player.position.x < transform.position.x)
		{
			xAxisController.bState = FakeButtonState.negative;
		}
		else
		{
			xAxisController.bState = FakeButtonState.up;
		}

		rigidbody2D.velocity = new Vector2(xAxisController.axis * maxSpeed, -maxSpeed);
	}
}
