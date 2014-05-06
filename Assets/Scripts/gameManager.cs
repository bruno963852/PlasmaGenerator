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
	public int gameTime;

	//tempo de duraçao da partida
	public int gameDuration = 70;

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

	//Reduz os rpms
	public bool isRpmReduced = false;

	//Valor de redução de RPM
	public int rpmReducingValue = 2;

	//Lista de high scores
	public List<ScoreEntry> highScores;

	//Se está no modo bicicleta
	public bool isOnBikeMode = true;

	//se deve ser mostrada o valor da rpm
	public bool showRpm = true;


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

		gameTime = gameDuration;
	}

	// Ao instanciar
	void Start () 
	{
		updateTime = Time.timeSinceLevelLoad;

		//Carrega os Scores
		LoadScores();
	}

	void OnLevelWasLoaded(int level)
	{
		Debug.Log("Level 1 carregado");
		if (level == 1)
		{
			updateTime = Time.timeSinceLevelLoad;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.loadedLevel == 1)
		{

			//se passou um segundo
			if (updateTime + 1 <= Time.timeSinceLevelLoad)
			{
				//decrementa o tempo da partida
				gameTime--;

				Debug.Log("Passou 1 segundo");
				
				//atualiza o tempo
				updateTime = Time.timeSinceLevelLoad;
			}

			if (gameTime == 0)
			{
				gameTime--;
				Debug.Log("Tempo Acabou, Carregando Game OVer...");
				Application.LoadLevel(2);
			}
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (!setRpmManually)
		{
			if (isOnBikeMode)
				rpm = (btController.getRpm() - (isRpmReduced? rpmReducingValue : 0))/maxGenRpm;
			else
				rpm = (6 - (isRpmReduced? rpmReducingValue : 0))/maxGenRpm;
		}
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
		else
		{
			highScores = new List<ScoreEntry>();
			ScoreEntry scoreEntry = new ScoreEntry();
			scoreEntry.name = "aaa";
			scoreEntry.score = 500;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "bbb";
			scoreEntry.score = 450;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "ccc";
			scoreEntry.score = 400;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "ddd";
			scoreEntry.score = 350;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "eee";
			scoreEntry.score = 300;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "fff";
			scoreEntry.score = 250;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "ggg";
			scoreEntry.score = 200;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "hhh";
			scoreEntry.score = 150;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "iii";
			scoreEntry.score = 100;
			highScores.Add(scoreEntry);
			scoreEntry = new ScoreEntry();
			scoreEntry.name = "jjj";
			scoreEntry.score = 50;
			highScores.Add(scoreEntry);
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

	public void resetGame()
	{
		gameTime = gameDuration;
		points = 0;
		Application.LoadLevel(1);
	}
	
}

[Serializable]
public class ScoreEntry : IComparable<ScoreEntry>
{
	public string name;
	public int score;

	public int CompareTo(ScoreEntry other)
	{
		if (other == null)
			return -1;

		return -score.CompareTo(other.score);
	}
}