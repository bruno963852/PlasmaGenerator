using UnityEngine;
using System.Collections;

public class enemyDestroyscript : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Bullet"))
		{
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
