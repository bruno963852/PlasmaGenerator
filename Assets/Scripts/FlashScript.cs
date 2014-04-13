using UnityEngine;
using System.Collections;

//Esse é o script que faz o objeto piscar
public class FlashScript : MonoBehaviour 
{
	//Tempo em segundos do estado piscatório
	public float flashingTime = 2;

	//Se está piscando
	private bool isFlashing = false;
	//Referência ao spriterenderer do objeto
	private SpriteRenderer sRenderer;
	//guarda o tempo
	private float updateTime = 0;

	// Ao instanciar
	void Start () 
	{
		//pega a referência para o renderer
		sRenderer = GetComponent<SpriteRenderer>();
	}
	
	// A cada frame
	void Update () 
	{
		//Se estiver piscando e passou tempo de piscar
		if (isFlashing && updateTime + flashingTime <= Time.time)
		{
			//diz que não está mais piscando
			isFlashing = false;
			//Cancela a função de piscar
			CancelInvoke();
			//Garante que termina habilitado
			sRenderer.enabled = true;
			//desbloqueia o tiro
			gameManager.i.isShotBlocked = false;
		}
	}

	//Método para fazer piscar
	public void flash()
	{
		//Se já estiver piscando
		if (this.IsInvoking())
		{
			//Cancela a função
			CancelInvoke();
		}
		//Salva o tempo
		updateTime = Time.time;
		//diz que está piscando
		isFlashing = true;
		//chama a funÇao de alternar visibilidade a cada 0.1 segundos
		InvokeRepeating("alternateVisibility", 0, 0.1f);
		//Bloqueia o tiro
		gameManager.i.isShotBlocked = true;
	}

	//Função para alterna a visibilidade do objeto
	private void alternateVisibility()
	{
		sRenderer.enabled = !sRenderer.enabled;
	}
}
