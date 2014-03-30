using UnityEngine;
using System.Collections;

//Esse script serve apenas para aplicar movimento
//a um inimigo seguindo as apertadas falsas de 
//2 axiscontrollers
public class EnemyMovementController : MonoBehaviour 
{
	//Velocidade do deslocamento
	public float maxSpeed = 5;

	//referencias aos axiscontrollers
	private EnemyaxisController xAxisController;
	private EnemyaxisController yAxisController;

	// Ao instanciar
	void Start () 
	{
		//Pega as referências
		//(o primeiro deve sempre ser considerado o eixo x e o segundi o y)
		xAxisController = GetComponents<EnemyaxisController>()[0];
		yAxisController = GetComponents<EnemyaxisController>()[1];
	}
	
	// A cada frame
	void Update () 
	{
		//seta a velocidade de acordo com os eixos
		rigidbody2D.velocity = new Vector2(xAxisController.axis * maxSpeed, yAxisController.axis * maxSpeed);
	}
}
