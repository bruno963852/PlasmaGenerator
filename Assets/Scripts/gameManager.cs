using UnityEngine;
using System.Collections;

//Esse script é o gerenciador do jogo
//Se comporta como um singletom
public class gameManager : MonoBehaviour 
{
	//Instância do Singleton
	public static gameManager i;

	//Controlador BlueTooh
	public BlueToothController btController;

	//Pontuação
	public int points = 0;

	//Logo antes de instanciar
	void Awake()
	{
		//Se não houver nenhuma instância
		if (i == null)
		{
			//Não destrua esse objeto na mudança de scene
			DontDestroyOnLoad(this.gameObject);

			//Essa é A instância
			i = this;
		}
		//Se houver uma instância e não for essa
		else if (i != this)
		{
			//Destrua essa instância
			Destroy(this.gameObject);
		}
	}

	// Ao instanciar
	void Start () 
	{
		//inicializa o controlador BT
		this.btController = new BlueToothController();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
