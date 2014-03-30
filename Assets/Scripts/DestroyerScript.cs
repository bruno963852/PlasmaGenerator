using UnityEngine;
using System.Collections;

//Script para os destruidores de objetos localizados
//nas extremidades da tela do jogo
public class DestroyerScript : MonoBehaviour 
{
	//destuir balas da nave?
	public bool destroyBullets = true;
	//Destruir inimigos?
	public bool destroyEnemies = false;
	//Destuir tiros dos inimigos?
	public bool destroyEnemyBullets = true;

	//Ao colidir
	void OnTriggerEnter2D(Collider2D other)
	{
		//Verifica se é um objeto para ser destuido
		if((other.tag.Equals("Bullet") && destroyBullets) || (other.tag.Equals("Enemy") && destroyEnemies) ||
		   (other.tag.Equals("EnemyBullet") && destroyEnemyBullets))
		{
			//Destroy o objeto
			Destroy(other.gameObject);
		}
	}
}
