using UnityEngine;
using System.Collections;

//Não sei se chamo isso de POG ou arte. Tem o mesmo propósito do
//AxisController, porém ao invés de ler o botão de verdade, é programável
//com falsas apertadas de botão ao longo do tempo.
//Serve pra automatizer os movimentos dos inimigos.

//Obs.: Vc pode aplicar duas vezes em um unico objeto
//um para o eixo x e outro para o y (se for 3d pode ser 3)
public class EnemyaxisController : MonoBehaviour 
{
	//Vide AxisController
	public float axis = 0;
	public float sensitivity = 0.03f;
	public float gravity = 0.1f;
	public float deadZone = 0.03f;
	public bool restatOnPress = false;
	//Eu vou setar o estado do botão através 
	//de outro script?
	public bool isExternallySetted = false;

	//Lista de falsas apertadas de botão
	public FakeButtonState[] fakePresses;
	//Lista dos tempos em que os botões são pressionados
	//Atenção: Os tempos são incrementais
	//Ex.: Se forem setados os tempos 2 e 1 o inimigo irá
	//apertar o primeiro botão 2 segundo após ser instanciado
	//depois apertará o segundo botão 1 segundo após apertar
	//o primeiro botão.
	public float[] fakePressesTimes;

	//Estado da falsa apertada de botão
	public FakeButtonState bState = FakeButtonState.up;
	//Contagem de apertadas de botão
	public int movCount = 0;
	//numero máximo de apertadas
	public int moves;
	//guarda tempo anterior
	public float updateTime;

	// Ao instanciar
	void Start () 
	{
		//o número máximo de apertadas será
		//a quantidade de elementos no
		//vetor de apertadas
		moves = fakePresses.Length;

		//Salva o tempo
		updateTime = Time.time;
	}
	
	// A cada frame
	void Update () 
	{
		//Se o botão não for ser setado externamente
		if (!isExternallySetted)
		{
			//Segue os movimentos programados
			doMoviment();
		}

		//Vide AxisController
		if (bState == FakeButtonState.negative)
		{
			if (axis > 0)
				axis -= gravity;
			else
				axis -= sensitivity;
			if (axis < -1)
				axis = -1;
		}
		else if (bState == FakeButtonState.positive)
		{
			if (axis < 0)
				axis += gravity;
			else
				axis += sensitivity;
			if (axis > 1)
				axis = 1;
		}
		else if (axis < 0)
		{
			if (axis < -deadZone)
			{
				axis += gravity;
			}
			else
			{
				axis = 0;
			}
		}
		else if (axis > 0)
		{
			if (axis > deadZone)
			{
				axis -= gravity;
			}
			else
			{
				axis = 0;
			}
		}
	}

	//Método para realizar os movimentos programados
	//nas listas
	private void doMoviment()
	{
		//Se ainda tiver botões para ser aplicados e passou o tempo para apertá-lo
		if(movCount < moves && updateTime + fakePressesTimes[movCount] <= Time.time)
		{
			//Seta o estado do botão de acordo com a lista
			bState = fakePresses[movCount];

			//Atualiza o tempo
			updateTime = Time.time;
			//Incrementa o contador de apertadas
			movCount++;
		}

	}

}

//Tem o mesmo propósito do axisControler, porém
//simplificado else generalizado
public enum FakeButtonState
{
	positive,
	negative,
	up
}
