using UnityEngine;
using System.Collections;

//Esse script controla a movimentação da nave do jogador de acordo com
//o axiscontroller
//Assim como o parâmetro da animação
public class ShipController : MonoBehaviour 
{
	//Velocidade máxima padrão de movimento da nave
	public float standardMaxSpeed = 8;

	//Animator da nave
	private Animator animator;
	//controlador de eixo do input
	private AxisController axisController;

	//Ao instanciar
	void Start () 
	{
		//pega a referência para o axiscontroller
		axisController = GetComponent<AxisController>();
		//pega a referência para o animator
		animator = GetComponent<Animator>();
	}
	
	// A cada Frame
	void Update () 
	{
		//Seta a velocidade de acordo com o axis
		rigidbody2D.velocity = new Vector2(axisController.axis * standardMaxSpeed, 0);
		//seta o parametro do animator
		//(porcentagem da velocidade máxima)
		animator.SetFloat("Speed", rigidbody2D.velocity.x / standardMaxSpeed);

		//declara um posicão auxiliar
		Vector3 thePosition;

		//se a nave passar de -7.5
		if (transform.position.x < -7.5f)
		{
			//manda ela pra -7.5
			thePosition = transform.position;
			thePosition.x = -7.5f;
			transform.position = thePosition;
		}
		//se passar de 7.5
		else if (transform.position.x > 7.5f)
		{
			//manda ela pra 7.5
			thePosition = transform.position;
			thePosition.x = 7.5f;
			transform.position = thePosition;
		}
			

	}
}
