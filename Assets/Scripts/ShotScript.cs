using UnityEngine;
using System.Collections;

//Esse é o script que faz a nave do jogador atirar
public class ShotScript : MonoBehaviour 
{
	//tempo entre tiros
	public float shotTime = 0.3f;
	//prefab da bala
	public GameObject bullet;
	//prefab do som do tiro
	public GameObject laserSound;
	//rotação do sprite da bala
	public Vector3 rotation;

	//tempo...
	private float updateTime;
	//rotação em quaternion
	private Quaternion quatRotation;

	//Ao instanciar
	void Start()
	{
		//Salva o tempo
		updateTime = Time.time;

		//transfora a rotação em quaternion
		quatRotation = Quaternion.Euler(rotation);
	}

	//A cada frame
	void Update () 
	{
		//Se pasou o tempo de atirar
		if(updateTime + shotTime <= Time.time)
		{
			//instancia a bala
			Instantiate(bullet, transform.position, quatRotation);
			//instancia o som da bala
			Instantiate(laserSound, transform.position, Quaternion.identity);

			//Atualiza o tempo
			updateTime = Time.time;
		}
	}
}
