using UnityEngine;
using System.Collections;

//Esse script gera um ondas de inimigos tipo "O"
public class OBurstSpawner : MonoBehaviour 
{
	//prefabo do inimigo
	public GameObject enemy_o;
	//tempo entre cada um
	public float spawnTime = 0.6f;
	//quantidade de inimigos
	public float burstSize = 9;

	//tempo...
	private float updateTime;
	//contador de inimigos
	private int spawnCount = 0;

	// Ao instanciar
	void Start () 
	{
		//Salva o tempo
		updateTime = Time.time;
	}
	
	// A cada frame
	void Update () 
	{
		//se tiver mais inimigos pra gerar e tiver passado o tempo
		if (updateTime + spawnTime <= Time.time && spawnCount < burstSize)
		{
			//instancia um inimigo (cada um a 1,5u de distância do outro)
			Instantiate(enemy_o, transform.position + new Vector3(spawnCount * 1.5f, 0, 0), Quaternion.identity);

			//atualiza o tempo
			updateTime = Time.time;
			//incrementa o contador
			spawnCount++;
		}
		//Se não houver mais inimigos pra gerar
		if (spawnCount >= burstSize)
		{
			//Destroy o gerador
			Destroy(gameObject);
		}
	}
}
