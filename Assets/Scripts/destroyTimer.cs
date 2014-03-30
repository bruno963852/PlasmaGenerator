using UnityEngine;
using System.Collections;

//Aplicar esse script a um objeto que vc quer que
//se auto destrua depois de um certo tempo
public class destroyTimer : MonoBehaviour 
{
	//tempo para se auto destruir
	public float time = 1;

	//guarda tempo anterior
	private float updateTime;

	// Ao instanciar
	void Start () 
	{
		//salva o tempo.
		updateTime = Time.time;
	}
	
	// A cada frame
	void Update () 
	{
		//se passou o tempo especificado
		if (updateTime + time <= Time.time)
		{
			//destroi esse objeto
			Destroy(this.gameObject);
		}
	}
}
