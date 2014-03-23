using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour 
{
	//Estado de movimento da nave
	public ShipMovingState movingState = ShipMovingState.notMoving;
	//Velocidade máxima padrão de movimento da nave
	public float standardSpeed = 5;
	//Aceleração da nave
	public float accel = 0.1f;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameManager.i.btController.getLeftButtonDown() && this.movingState != ShipMovingState.movingLeft)
		{
			movingState = ShipMovingState.movingLeft;

			this.rigidbody2D.velocity = new Vector2(-standardSpeed, 0);
		}
		if (gameManager.i.btController.getRightButtonDown() && this.movingState != ShipMovingState.movingRight)
		{

			movingState = ShipMovingState.movingRight;

			this.rigidbody2D.velocity = new Vector2(standardSpeed, 0);
		}
		if ((gameManager.i.btController.getLeftButtonUp() && this.movingState == ShipMovingState.movingLeft)
		    || (gameManager.i.btController.getRightButtonUp() && this.movingState == ShipMovingState.movingRight))
		{
			movingState = ShipMovingState.notMoving;

			this.rigidbody2D.velocity = Vector2.zero;
		}
		if (this.transform.position.x > 7.5f)
		{
			this.rigidbody2D.velocity = Vector2.zero;

			Vector3 position = this.transform.position;

			position.x = 7.5f;

			this.transform.position = position;
		}
		if (this.transform.position.x < -7.5f)
		{
			this.rigidbody2D.velocity = Vector2.zero;
			
			Vector3 position = this.transform.position;
			
			position.x = -7.5f;
			
			this.transform.position = position;
		}
	}
}
public enum ShipMovingState
{
	movingLeft,
	movingRight,
	notMoving
}
