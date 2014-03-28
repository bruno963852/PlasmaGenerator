using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour 
{
	public bool destroyBullets = true;
	public bool destroyEnemies = false;
	public bool destroyEnemyBullets = true;

	void OnTriggerEnter2D(Collider2D other)
	{
		if((other.tag.Equals("Bullet") && destroyBullets) || (other.tag.Equals("Enemy") && destroyEnemies) ||
		   (other.tag.Equals("EnemyBullet") && destroyEnemyBullets))
		{
			Destroy(other.gameObject);
		}
	}
}
