using UnityEngine;
using System.Collections;

public class enemyDestroyscript : MonoBehaviour {

	public GameObject explosion;
	public float hp = 5;
	public int pointsWin = 0;
	public int pointsLoose = 0;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Bullet"))
		{
			hp -= other.GetComponent<bulletScript>().damage;

			if (hp <= 0f)
			{
				Instantiate(explosion, transform.position, Quaternion.identity);
				gameManager.i.points += pointsWin;
				Destroy(this.gameObject);
			}
		}
		else if (other.tag.Equals("Player"))
		{
			Instantiate(explosion, transform.position, Quaternion.identity);
			gameManager.i.points -= pointsLoose;
			other.GetComponent<FlashScript>().flash();
			Destroy(this.gameObject);
		}
	}
}
