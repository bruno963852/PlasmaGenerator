using UnityEngine;
using System.Collections;

public class GameTimeController : MonoBehaviour {

	private float updateTime;

	// Use this for initialization
	void Start () 
	{
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//se passou um segundo
		if (updateTime + 1 <= Time.time)
		{
			//decrementa o tempo da partida
			gameManager.i.gameTime--;
			
			Debug.Log("Passou 1 segundo");
			
			//atualiza o tempo
			updateTime = Time.time;
		}
		
		if (gameManager.i.gameTime == 0)
		{
			gameManager.i.gameTime--;
			Debug.Log("Tempo Acabou, Carregando Game OVer...");
			Application.LoadLevel(2);
		}
	}
}
