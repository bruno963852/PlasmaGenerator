using UnityEngine;
using System.Collections;

//esse é o script para as balas disparadas pelos inimigos
//(as que atiram na direção da nave)
public class enemyBulletFollowScript : MonoBehaviour 
{
	//Velocidade da bala
	public float speed = 20;
	//prefab da Explosão da bala
	public GameObject explosion;
	//Direção da bala
	public Vector3 direction;
	//Pontos perdidos ao ser atingido
	public int pointsLoose = 0;

	//Ao instanciar
	void Start () 
	{
		//O vetor direção é a posição da nave menos a da bala
		direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
		//Transformado em vetor unitário
		direction = direction.normalized;
		//seta a velocidade baseado na direção
		rigidbody2D.velocity = (new Vector2(direction.x, direction.y) * speed);
	}

	//Ao colidir
	void OnTriggerEnter2D(Collider2D other)
	{
		//Se colidou com a nave do jogador
		if (other.tag.Equals("Player"))
		{
			//Instancia a explosão
			Instantiate(explosion, transform.position, Quaternion.identity);
			//Diminui os pontos
			gameManager.i.points -= pointsLoose;
			//fas a nave piscar
			other.GetComponent<FlashScript>().flash();
			//Destroi a bala
			Destroy(this.gameObject);
		}
	}
}
