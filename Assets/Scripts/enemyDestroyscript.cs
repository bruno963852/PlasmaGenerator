using UnityEngine;
using System.Collections;

//Script que destroi o inimigo
public class enemyDestroyscript : MonoBehaviour 
{
	//prefab da explosão do inimigo
	public GameObject explosion;
	//hp do inimigo
	public float hp = 5;
	//ele muda a aparência quando tá morrendo?
	public bool changSpriteWhenDying = false;
	//sprite morrendo
	public Sprite dyingSprite;
	//hp para mudar sprite
	public float dyingHP = 5;
	//Pontos ganhos ao destruir inimigos
	public int pointsWin = 0;
	//pontos perdidos ao colidir com inimigo
	public int pointsLoose = 0;

	//Referência para o sprite renderer
	private SpriteRenderer sRenderer;

	void Start()
	{
		//pega a referência
		sRenderer = GetComponent<SpriteRenderer>();
	}

	//Ao colidir
	void OnTriggerEnter2D(Collider2D other)
	{
		//Se colidiu com uma bala do jogador
		if (other.tag.Equals("Bullet"))
		{
			//Diminui o hp com o dano da bala
			hp -= other.GetComponent<bulletScript>().damage;
			//se ele muda o sprite quando tá morrendo e
			//ele tá morrendo
			if (hp <= dyingHP && changSpriteWhenDying)
			{
				//muda o sprite
				sRenderer.sprite = dyingSprite;
			}
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
