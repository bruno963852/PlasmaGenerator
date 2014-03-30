using UnityEngine;
using System.Collections;

//Esse script gera uma onda de inimigos do tipo U
public class uBurstSpawner : MonoBehaviour 
{
	//prefab do inimigo
	public GameObject enemy_u;
	//tempo entre gerações
	public float spawnTime = 0.5f;
	//quantidade de inimigos
	public int burstSize = 5;

	//tempo
	private float updateTime;
	//contador
	private int spawnCount = 0;

	// Use this for initialization
	void Start () 
	{
		//tempo........
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//se tem inimigo e deu o tempo de gerar
		if (updateTime + spawnTime <= Time.time && spawnCount < burstSize)
		{
			//instancia inimigo
			Instantiate(enemy_u, transform.position, Quaternion.identity);

			//atualiza tempo e incrementa contador
			updateTime = Time.time;
			spawnCount++;
		}
		//se não tiver mais inimigos pra gerar
		if (spawnCount >= burstSize)
		{
			//destroi
			Destroy(gameObject);
		}
	}
}
