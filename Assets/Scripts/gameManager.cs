using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

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

	//Tempo da partida (em segundos)
	public int gameTime = 60;

	//guarda o tempo
	private float updateTime;

	//rotaões da bilicleta
	public float rpm = 0;

	//Valor de rpm para máxima geração de plasma
	public float maxGenRpm = 9.0f;

	//Setar o rpm manualmente (para testes)
	public bool setRpmManually = false;

	//bloqueia o tiro da nave
	public bool isShotBlocked = false;

	//Lista de high scores
	public List<ScoreEntry> highScores;

	//Se está no modo bicicleta
	public bool isOnBikeMode = true;

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

			//inicializa o controlador BT
			this.btController = new BlueToothController();
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
		updateTime = Time.timeSinceLevelLoad;

		//Carrega os Scores
		LoadScores();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//se passou um segundo
		if (updateTime + 1 <= Time.timeSinceLevelLoad)
		{
			//decrementa o tempo da partida
			gameTime--;
			
			//atualiza o tempo
			updateTime = Time.timeSinceLevelLoad;
		}

		if (gameTime == 0)
		{
			Application.LoadLevel(2);
		}

		if (!setRpmManually)
			rpm = btController.getRpm()/maxGenRpm;
	}

	public void SaveScores()
	{
		//binary formatter
		BinaryFormatter b = new BinaryFormatter();
		//memory stream
		MemoryStream m = new MemoryStream();
		//salva os scores
		b.Serialize(m, highScores);
		//salva no playerprefs
		PlayerPrefs.SetString("HighScores", Convert.ToBase64String(m.GetBuffer()));
	}

	public void LoadScores()
	{
		//Pega os scores
		string data = PlayerPrefs.GetString("HighScores");
		//carrega se não for nulo
		if(!string.IsNullOrEmpty(data))
		{
			//Binary formatter
			BinaryFormatter b = new BinaryFormatter();
			//Cria a memorystream
			MemoryStream m = new MemoryStream(Convert.FromBase64String(data));
			//Salva no atributo
			highScores = (List<ScoreEntry>)b.Deserialize(m);
		}
	}

	public void addScore(ScoreEntry score)
	{
		highScores.Add(score);

		highScores.Sort();

		if (highScores.Count > 10)
		{
			highScores.RemoveAt(10);
		}

		SaveScores();
	}
}

public class ScoreEntry : IComparable<ScoreEntry>
{
	public string name;
	public int score;

	public int CompareTo(ScoreEntry other)
	{
		if (other == null)
			return 1;

		return score.CompareTo(other.score);
	}
}