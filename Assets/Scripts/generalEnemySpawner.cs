using UnityEngine;
using System.Collections;

//Esse é o script que gera as ondas de inimigos
public class generalEnemySpawner : MonoBehaviour 
{
	//Lista das ondas de inimigos para serem geradas
	//(Cada gerador de onda específica tem seu próprio prefab)
	public GameObject[] bursts;
	//Lista de tempos entre a geração das ondas
	public float[] spawnTimes;
	//Lista de posições onde as ondas são geradas
	//(no eixo x, sempre acima da tela)
	public float[] spawnPositions;

	//Contador de ondas
	public int burstCount = 0;
	//numero maximo de ondas
	public int maxBursts;
	//guarda o tempo...
	private float updateTime;

	// Ao instanciar
	void Start () 
	{
		//salva o tempo
		updateTime = Time.timeSinceLevelLoad;
		//o numero maximo de ondas é o tamanho do vetor de ondas
		maxBursts = bursts.Length;
	}
	
	// A cada frame
	void Update () 
	{
		//se ainda tiver onda pra ser gerada e tiver passado o tempo de gerar
		if((burstCount < maxBursts) && ((updateTime + spawnTimes[burstCount]) <= Time.timeSinceLevelLoad))
		{
			//salva a posição
			Vector3 thePosition = transform.position;
			//a[lica a alteração no eixo x
			thePosition.x += spawnPositions[burstCount];

			//Instancia o gerador de onda na posiÇao especificada
			Instantiate(bursts[burstCount], thePosition, Quaternion.identity);

			//atualiza o tempo
			updateTime = Time.timeSinceLevelLoad;
			//incrementa a contagem de ondas
			burstCount++;
		}
	}
}
