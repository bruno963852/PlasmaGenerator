using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

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
	public HighScores highScores;

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
		}
		//Se houver uma instância e não for essa
		else if (i != this)
		{
			//Destrua essa instância
			Destroy(this.gameObject);
		}

		//inicializa o controlador BT
		this.btController = new BlueToothController();
	}

	// Ao instanciar
	void Start () 
	{
		updateTime = Time.timeSinceLevelLoad;
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

		if (!setRpmManually)
			rpm = btController.getRpm()/maxGenRpm;
	}

/*	public void SaveScore(Score score)
	{
		
	}

	public void saveTestScores()
	{
		highScores = new HighScores();
		Score score = new Score();
		score.name = "AAA";
		score.score = 35;
		highScores.list.Add(score);
		score = new Score();
		score.name = "BBB";
		score.score = 50;
		highScores.list.Add(score);
		score = new Score();
		score.name = "CCC";
		score.score = 70;
		highScores.list.Add(score);

		highScores.list.Sort(new myComparer());

		pushHighScores();
	}

	private void pushHighScores()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		byte[] data = formatter.Serialize();
		string dataString = System.Convert.ToBase64String(data);
		PlayerPrefs.SetString("HighScores", dataString);
	}

	private void pullHighScores()
	{
		string dataString = PlayerPrefs.GetString("HighScores");
		if (!dataString.Equals(""));
		{
			byte[] data = System.Convert.FromBase64String(dataString);
			BinaryFormatter formatter = new BinaryFormatter();
			highScores = (HighScores) formatter.Deserialize(data);
		}
	}*/
}

public class HighScores
{
	public ArrayList list;
}

public class Score
{
	public string name;
	public int score;
}

/*public class myComparer : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		return new Comparer().Compare(((Score)x).score, ((Score)y).score);
	}
}*/