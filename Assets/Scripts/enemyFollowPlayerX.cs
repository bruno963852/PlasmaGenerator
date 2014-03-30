using UnityEngine;
using System.Collections;

//Script para controlar a falsa apertada de botão dos inimigos
//no sentido de seguir a nava do jogador (somente no eixo x)
public class enemyFollowPlayerX : MonoBehaviour 
{
	//Velocidade de deslocamento
	public float maxSpeed = 5;

	//Referencia para a posiçAo da nave do jogador
	private Transform player;
	//Referencia para o script do EnemyAxisController
	private EnemyaxisController xAxisController;

	// Ao instanciar
	void Start () 
	{
		//pega a referência para o primeiro axiscontroller
		//(que deve sempre ser considerado o controlador do eixo x)
		xAxisController = GetComponents<EnemyaxisController>()[0];

		//Pega a refeência para a posiçAo da nave do jogador
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// A cada frame
	void Update () 
	{
		//Se a nave estiver à direita
		if (player.position.x > transform.position.x)
		{
			//aperta botão para ir pra direita
			xAxisController.bState = FakeButtonState.positive;
		}
		//se estiver a esquerda
		else if (player.position.x < transform.position.x)
		{
			//aperta botão para ir a esquerda
			xAxisController.bState = FakeButtonState.negative;
		}
		//se estiver na posiçao igual
		else
		{
			//solta botão
			xAxisController.bState = FakeButtonState.up;
		}

		//Seta a velocidade de acordo com o exixo
		rigidbody2D.velocity = new Vector2(xAxisController.axis * maxSpeed, -maxSpeed);
	}
}
