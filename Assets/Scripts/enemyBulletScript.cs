using UnityEngine;
using System.Collections;

public class enemyBulletScript : MonoBehaviour 
{

	public float speed = 20;
	public GameObject explosion;
	public Vector3 direction;
	public Vector2 velocity;
	
	void Start () 
	{
		direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
		direction = direction.normalized;
		rigidbody2D.velocity = (new Vector2(direction.x, direction.y) * speed);
		velocity = rigidbody2D.velocity;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Player"))
		{
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
