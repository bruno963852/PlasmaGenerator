using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour 
{
	public float maxSpeed = 5;

	private EnemyaxisController xAxisController;
	private EnemyaxisController yAxisController;

	// Use this for initialization
	void Start () 
	{
		xAxisController = GetComponents<EnemyaxisController>()[0];
		yAxisController = GetComponents<EnemyaxisController>()[1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		rigidbody2D.velocity = new Vector2(xAxisController.axis * maxSpeed, yAxisController.axis * maxSpeed);
	}
}
