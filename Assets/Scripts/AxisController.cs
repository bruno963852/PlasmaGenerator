using UnityEngine;
using System.Collections;

//Essa script serve para simular o Input.getAxis padrão do unity.
//Assim suavisando o movimento da nave, com aceleração e freio
public class AxisController : MonoBehaviour 
{
	//Valor do eixo de input. Esse é o valor
	//usado para ajustar a movimentação da nave
	public float axis = 0;
	//Sensibilidade do eixo (quao rápido vai pra 1 ou -1)
	public float sensitivity = 0.03f;
	//Gravidade do botão (quão rápido vai pra zero)
	public float gravity = 0.1f;
	//faixa de valor (positivo ou negativo) que é
	//considerado zero
	public float deadZone = 0.03f;
	//O eixo deve começar do zero a cada apertar
	//de botão?
	public bool restatOnPress = false;

	//Estado dos botões
	private ButtonState bState = ButtonState.up;
	
	// A cada frame
	void Update () 
	{
		//Verifica os botões
		checkButtonState();

		//quado estiver apertado o botão esquerdo
		if (bState == ButtonState.leftDown)
		{
			//Se o eixo estiver positivo
			if (axis > 0)
				//desacelera de acordo com a gravidade
				axis -= gravity;
			//senão
			else
				//acelera até -1 de acordo com a sensibilidade
				axis -= sensitivity;
			//se passar de -1
			if (axis < -1)
				//é -1
				axis = -1;
		}
		//quado estiver apertado o botão esquerdo

		else if (bState == ButtonState.rightDown)
		{
			//Se o eixo estiver negativo
			if (axis < 0)
				//desacelera de acordo com a gravidade
				axis += gravity;
			//senão
			else
				//acelera até 1 de acordo com a sensibilidade
				axis += sensitivity;
			//se passar de 1
			if (axis > 1)
				//é 1
				axis = 1;
		}
		//Se não tiver nenhum botão pressionado
		//e o eixo é negativo
		else if (axis < 0)
		{
			//se estiver fora da deadzone
			if (axis < -deadZone)
			{
				//desacelera com a gravidade
				axis += gravity;
			}
			//senão
			else
			{
				//é zero
				axis = 0;
			}
		}
		//Se não tiver nenhum botão pressionado
		//e o eixo é positivo
		else if (axis > 0)
		{
			//se estiver fora da deadzone
			if (axis > deadZone)
			{
				//desacelera com a gravidade
				axis -= gravity;
			}
			//senão
			else
			{
				//é zero
				axis = 0;
			}
		}
	}

	//método para checar o apertar dos botões
	private void checkButtonState()
	{
		if (gameManager.i.isOnBikeMode)
			{
			//se o botão essquerdo foi apertado e não estava apertado antes
			if (gameManager.i.btController.getLeftButtonDown() && bState != ButtonState.leftDown)
			{
				//se restartPnPress foi marcado
				if(restatOnPress)
					//começa do zero
					axis = 0;
				//seta o estado dos botões
				bState = ButtonState.leftDown;
			}
			//se o botão direito foi apertado e não estava apertado antes
			if (gameManager.i.btController.getRightButtonDown() && bState != ButtonState.rightDown)
			{
				//se restartPnPress foi marcado
				if(restatOnPress)
					//começa do zero
					axis = 0;
				//seta o estado dos botões
				bState = ButtonState.rightDown;
			}
			//se o botão esquerdo estava apertado e foi solto
			if (gameManager.i.btController.getLeftButtonUp() && bState == ButtonState.leftDown)
			{
				//seta o estado
				bState = ButtonState.up;
			}
			//se o botão direito estada apertado e foi solto
			if (gameManager.i.btController.getRightButtonUp() && bState == ButtonState.rightDown)
			{
				//seta o estado
				bState = ButtonState.up;
			}
		}
		//Se não estiver com a bike
		else
		{
			//pega o toque
			Touch touch = Input.GetTouch(0);

			//se foi toque
			if (touch.phase == TouchPhase.Began)
			{
				if (touch.position.x <= 640)
				{
					bState = ButtonState.leftDown;
				}
				else
				{
					bState = ButtonState.rightDown;
				}
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				bState = ButtonState.up;
			}
		}
	}
}
//Enum para representar o estado dos botões
//de uma forma mais legível
enum ButtonState
{
	//esquero apertado
	leftDown,
	//direito apertado
	rightDown,
	//nenhum apertado
	up
}
//Obs. Para efeito de eixo de movimentação o estado
//de ambos apertados é dispensável
