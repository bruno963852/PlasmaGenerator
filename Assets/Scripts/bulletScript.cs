using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour 
{
	public float speed = 15;
	public float damage = 2;
	public GameObject explosion;


	void Start () 
	{
		this.rigidbody2D.velocity = new Vector2(0, speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Enemy"))
		{
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
