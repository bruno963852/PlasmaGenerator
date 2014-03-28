using UnityEngine;
using System.Collections;

public class EnemyZigZag : MonoBehaviour {

	public float zigZagSpeed = 1;
	public float zigZagAmplitude = 2;
	public float goSpeed = 3;

	public Vector2 velocity;
	// Use this for initialization
	void Start () 
	{
		velocity = new Vector2();
	}
	
	// Update is called once per frame
	void Update () 
	{
		velocity.x = Mathf.Sin(Time.time * zigZagSpeed) * zigZagAmplitude;
		velocity.y = -goSpeed;

		this.rigidbody2D.velocity = velocity;
	}
}
