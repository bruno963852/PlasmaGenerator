using UnityEngine;
using System.Collections;

//Esse script serve só pra fazer um textura ficar "passando" no background
public class BackGroundPassScript : MonoBehaviour 
{
	//velocidade do andamento
	public float speed = 0.5f;
	
	// a cada frame
	void Update () 
	{
		//incrementa o offset da textura, fazendo o efeito de continuidade
		renderer.material.mainTextureOffset = new Vector2 (0f, (Time.time * speed) % 1);
	}
}
