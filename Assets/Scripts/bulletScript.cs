﻿using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour 
{
	public float speed = 15;


	void Start () 
	{
		this.rigidbody2D.velocity = new Vector2(0, speed);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y >= 6 || transform.position.y <= -6 ||
		   transform.position.x >= 9 || transform.position.x <= -9)
		{
			Destroy (this.gameObject);
		}
	}
}
