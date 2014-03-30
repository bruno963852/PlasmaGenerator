using UnityEngine;
using System.Collections;

//Esse script gera uma onde de inimigos do tipo spike
public class spikeBurstSpawner : MonoBehaviour 
{
	//prefabo do inimigo
	public GameObject enemy_spike;
	//tempo entre inimigos gerados
	public float spawnTime = 0.8f;
	//quantidade de inimigos
	public float burstSize = 8;

	//tempo
	private float updateTime;
	//contador de inimigos
	private int spawnCount = 0;
	//Alternador de lado
	private int alternator = -1;

	// Use this for initialization
	void Start () 
	{
		//salva o tempo
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//se tiver inimigo pra gerar e passou o tempo de gerar
		if (updateTime + spawnTime <= Time.time && spawnCount < burstSize)
		{
			//instancia o inimigo (alternando lado e a distancia)
			Instantiate(enemy_spike, transform.position + new Vector3((spawnCount + 1) * alternator, 0, 0), Quaternion.identity);

			//atualiza o tempo e incrementa contador e inverte alternador
			updateTime = Time.time;
			spawnCount++;
			alternator *= -1;
		}
		//se acabou de gerar
		if (spawnCount >= burstSize)
		{
			//destroi
			Destroy(gameObject);
		}
	}
}
