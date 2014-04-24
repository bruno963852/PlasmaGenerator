using UnityEngine;
using System.Collections;

//Esse é o script que faz a nave do jogador atirar
public class ShotScript : MonoBehaviour 
{
	//tempo entre tiros
	public float shotTime = 0.1f;
	//prefab da bala
	public GameObject[] bullets;
	//prefab do som do tiro
	public GameObject laserSound;
	//rotação do sprite da bala
	public Vector3 rotation;
	//bala atual
	private GameObject currentBullet;

	public UISlider slider;

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

		currentBullet = bullets[0];
	}

	//A cada frame
	void Update () 
	{
		//Se pasou o tempo de atirar
		if(updateTime + shotTime <= Time.time)
		{
			if (currentBullet != null)
			{
				//instancia a bala
				Instantiate(currentBullet, transform.position, quatRotation);
				//instancia o som da bala
				Instantiate(laserSound, transform.position, Quaternion.identity);
			}

			//Atualiza o tempo
			updateTime = Time.time;
		}

		if (slider.value >= 0.75f && !gameManager.i.isShotBlocked)
		{
			currentBullet = bullets[2];
		}
		else if (slider.value >= 0.50f && !gameManager.i.isShotBlocked)
		{
			currentBullet = bullets[1];
		}
		else if (slider.value >= 0.25f && !gameManager.i.isShotBlocked)
		{
			currentBullet = bullets[0];
		}
		else
		{
			currentBullet = null;
		}
	}
}
