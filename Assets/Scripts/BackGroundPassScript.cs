using UnityEngine;
using System.Collections;

public class BackGroundPassScript : MonoBehaviour {

	public float speed = 0.5f;
	
	// Update is called once per frame
	void Update () 
	{
		renderer.material.mainTextureOffset = new Vector2 (0f, (Time.time * speed) % 1);
	}
}
