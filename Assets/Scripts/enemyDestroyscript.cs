using UnityEngine;
using System.Collections;

//Script que destroi o inimigo
public class enemyDestroyscript : MonoBehaviour 
{
	//prefab da explosão do inimigo
	public GameObject explosion;
	//hp do inimigo
	public float hp = 5;
	//Pontos ganhos ao destruir inimigos
	public int pointsWin = 0;
	//pontos perdidos ao colidir com inimigo
	public int pointsLoose = 0;

	//Ao colidir
	void OnTriggerEnter2D(Collider2D other)
	{
		//Se colidiu com uma bala do jogador
		if (other.tag.Equals("Bullet"))
		{
			//Diminui o hp com o dano da bala
			hp -= other.GetComponent<bulletScript>().damage;

			//Se zerou o hp
			if (hp <= 0f)
			{
				//instancia a explosão
				Instantiate(explosion, transform.position, Quaternion.identity);
				//Acrecenta os pontos
				gameManager.i.points += pointsWin;
				//Destoi inimigo
				Destroy(this.gameObject);
			}
		}
		//Se colidiu com a nave do jogador
		else if (other.tag.Equals("Player"))
		{
			//Instancia a explosão
			Instantiate(explosion, transform.position, Quaternion.identity);
			//Diminui os pontos
			gameManager.i.points -= pointsLoose;
			//Faz a nave piscar
			other.GetComponent<FlashScript>().flash();
			//destroi inimigo
			Destroy(this.gameObject);
		}
	}
}
