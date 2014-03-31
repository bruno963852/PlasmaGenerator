using UnityEngine;
using System.Collections;

//Esse script gera uma onde de tiros
public class shotBurst : MonoBehaviour 
{
	//prefab do tiro
	public GameObject shot;
	//prefab do som do tiro
	public GameObject shotSound;
	//tempo entre tiros
	public float shotTime = 0.5f;
	//quantidade de tiros
	public int shotQuantity = 3;

	//tempo
	private float updateTime = 0;
	//contador de tiros
	private int shotCount = 0;

	// Update is called once per frame
	void Update () 
	{
		//se tem tiros pra soltar e passou o tempo de soltar
		if (shotCount < shotQuantity && updateTime + shotTime <= Time.time)
		{
			//instancia o tiro
			Instantiate(shot, transform.position, Quaternion.identity);
			//instancia o som do tiro
			Instantiate(shotSound, transform.position, Quaternion.identity);
			//incrementa o contador
			shotCount++;
			//salva o tempo
			updateTime = Time.time;
		}
		//se não tem mais tiros
		if (shotCount > shotQuantity)
		{
			//destroi
			Destroy(gameObject);
		}

	}
}
