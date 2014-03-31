using UnityEngine;
using System.Collections;

//Script para fazer o inimigo atirar em uma certa frequência
public class enemyShotScripts : MonoBehaviour 
{
	//prefab da bala
	public GameObject shot;
	//se, ao invés de um tiro, sera instanciado uma
	//rajada de tiros
	public bool isBurst = false;
	//prefab do som do tiro
	//(criei prefabs separados para os soms, para que
	//eles não sejam interrompidos quando a bala for
	//destruida, isso soa estranho)
	public GameObject laserSound;
	//tempo entre tiros
	public float shotFrequency = 1;

	//guarda o tempo anterior
	private float updateTime;

	// Ao instanciar
	void Start () 
	{
		//salva o tempo
		updateTime = Time.time;
	}
	
	// A cada Frame
	void Update () 
	{
		//Se passou o tempo
		if (updateTime + shotFrequency <= Time.time)
		{
			//Instancia a bala
			Instantiate (shot, transform.position, Quaternion.identity);
			//se não for uma rajada
			if (!isBurst)
			{
				//Instancia o som da bala
				Instantiate(laserSound, transform.position, Quaternion.identity);
			}

			//Salva o tempo
			updateTime = Time.time;
		}
	}
}
