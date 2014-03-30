using UnityEngine;
using System.Collections;

//Esse é o script das balas atiradas da nave
public class bulletScript : MonoBehaviour 
{
	//velocidade da bala
	public float speed = 15;
	//dano causado pela bala
	public float damage = 2;
	//Prefab de explosão da bala
	public GameObject explosion;

	//Ao instanciar
	void Start () 
	{
		//seta a velocidade da bala pra frente
		this.rigidbody2D.velocity = new Vector2(0, speed);
	}

	//Ao colidir
	void OnTriggerEnter2D(Collider2D other)
	{
		//Se colidiu com um inimigo
		if (other.tag.Equals("Enemy"))
		{
			//Instancia a explosão
			Instantiate(explosion, transform.position, Quaternion.identity);
			//destroi essa bala
			Destroy(this.gameObject);
		}
	}
}
