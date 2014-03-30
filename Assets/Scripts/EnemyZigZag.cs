using UnityEngine;
using System.Collections;

//Esse script controla os falsos botoes para 
//fazer o inimigo andar em zig zag
public class EnemyZigZag : MonoBehaviour 
{
	//Velocidade do deslocamento
	public float maxSpeed = 6;
	//Tempo entre apertadas de botão
	public float zigZagTime = 1;

	//referencia para o axiscontroller
	private EnemyaxisController xAxisController;
	//guarda o tempo
	private float updateTime;

 	// Ao instanciar
	void Start () 
	{
		//pega a referência para o primeiro axiscontroller
		//(que deve sempre ser considerado o controlador do eixo x)		
		xAxisController = GetComponents<EnemyaxisController>()[0];

		//zera o tempo para que o movimento comece imediatamente
		updateTime = 0;
	}
	
	// A cada frame
	void Update () 
	{
		//se passou o tempo
		if (updateTime + zigZagTime <= Time.time)
		{
			//Se estiver indo pra esquerda
			if (xAxisController.bState == FakeButtonState.negative)
			{
				//vai pra direita
				xAxisController.bState = FakeButtonState.positive;
			}
			//vice-versa
			else
			{
				xAxisController.bState = FakeButtonState.negative;
			}

			//salva o tempo
			updateTime = Time.time;
		}
		//seta a velocidade de acordo com o eixo
		rigidbody2D.velocity = new Vector2(xAxisController.axis * maxSpeed, -maxSpeed);
	}
}
