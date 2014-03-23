using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour 
{
	//Velocidade máxima padrão de movimento da nave
	public float standardMaxSpeed = 8;

	//Animator da nave
	private Animator animator;
	//controlador de eixo do input
	private AxisController axisController;

	void Start () 
	{
		axisController = GetComponent<AxisController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rigidbody2D.velocity = new Vector2(axisController.axis * standardMaxSpeed, 0);
		animator.SetFloat("Speed", rigidbody2D.velocity.x / standardMaxSpeed);

		Vector3 thePosition;

		if (transform.position.x < -7.5f)
		{
			thePosition = transform.position;
			thePosition.x = -7.5f;
			transform.position = thePosition;
		}
		else if (transform.position.x > 7.5f)
		{
			thePosition = transform.position;
			thePosition.x = 7.5f;
			transform.position = thePosition;
		}
			

	}
}
