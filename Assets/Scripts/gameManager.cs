using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
	//Instância do Singleton
	public static gameManager i;

	//Controlador BlueTooh
	public BlueToothController btController;

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

	// Use this for initialization
	void Start () 
	{
		this.btController = new BlueToothController();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
