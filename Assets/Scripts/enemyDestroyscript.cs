using UnityEngine;
using System.Collections;

public class enemyDestroyscript : MonoBehaviour {

	public GameObject explosion;
	public float hp = 5;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Bullet"))
		{
			hp -= other.GetComponent<bulletScript>().damage;

			if (hp <= 0f)
			{
				Instantiate(explosion, transform.position, Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}
}
