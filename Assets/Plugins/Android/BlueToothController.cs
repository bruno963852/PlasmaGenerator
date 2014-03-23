using UnityEngine;
using System.Collections;
/****************************************************************
 * Isso nao e um script, e uma classe normal, portanto nao 		*
 * adicione ele a nenhum objeto, somente instancie dentro do	*
 * script no qual voce quer usa-lo e acione os metodos de 		*
 * acordo com a necessidade										*
 * *************************************************************/

public class BlueToothController {
#if UNITY_ANDROID

	//Guarda a classe java do plugin
	private AndroidJavaObject javaController;

	//Construtor
	public BlueToothController()
	{
		//localiza a classe dentro do plugin
		javaController = new AndroidJavaObject("com.koruja.bluetoothunityplugin.BTController");
	}

	//Use esse metodo para obter uma lista(array) com
	//os nomes de todos os dispositivos que estao
	//pareados com o tablet
	public string[] getBondedDevices()
	{
		return javaController.Call<string[]>("getBondedDevicesStr");
	}

	//Use esse metodo para conectar com o dispositivo
	//desejado. "index" e o indice da lista anterior
	//no qual se encontra o dispositivo a qual voce
	//deseja conectar..
	public void connectDevice(int index)
	{
		javaController.Call("connectDevice", new object[] { index});
	}

	//Retorna verdadeiro se voce estiver conectado a
	//ao dispositivo
	public bool isConnected()
	{
		return javaController.Call<bool>("isItConnected");
	}

	//Retorna verdadeiro se o botao do guidao esquerdo
	//foi pressionado
	public bool getLeftButtonDown()
	{
		return javaController.Call<bool>("getLeftButtonDown");
	}

	//Retorna verdadeiro se o botao do guidao esquerdo
	//foi solto
	public bool getLeftButtonUp()
	{
		return javaController.Call<bool>("getLeftButtonUp");
	}

	//Retorna verdadeiro se o botao do guidao direito
	//foi pressionado
	public bool getRightButtonDown()
	{
		return javaController.Call<bool>("getRightButtonDown");
	}

	//Retorna verdadeiro se o botao do guidao direito
	//foi solto
	public bool getRightButtonUp()
	{
		return javaController.Call<bool>("getRightButtonUp");
	}

	//Retorna a rpm da bicicleta
	public int getRpm()
	{
		return javaController.Call<int>("getRpm");
	}

	//Retorna o pulso do individio
	public int getHeartBeat()
	{
		return javaController.Call<int>("getHeartBeat");
	}

#elif UNITY_STANDALONE

	//Essa parte aqui serve pra testar quando estiver no pc
	//simulando a classe android sem dar problema com os 
	//métodos, edite à vontade


	//Pra simular o isConnected verdadeiro
	bool connected = false;

	//Construtor
	public BlueToothController()
	{
	}
	
	//Use esse metodo para obter uma simulação de 
	//lista(array) com os dispositivos
	//pareados com o tablet
	public string[] getBondedDevices()
	{
		return new string[] { "Device-A", "Device-B", "Device-C" };
	}
	
	//Use esse metodo para inventar que está conectando com
	//algum dispositivo.
	public void connectDevice(int index)
	{
		connected = true;
	}
	
	//Retorna verdadeiro se voce estiver conectado a
	//ao dispositivo
	public bool isConnected()
	{
		return connected;
	}
	
	//Retorna verdadeiro se o botao que vc achar
	//melhor pra simular o botao do guidao esquerdo
	//for pressionado
	public bool getLeftButtonDown()
	{
		return Input.GetKeyDown(KeyCode.LeftArrow);
	}
	
	//Retorna verdadeiro se o botao que vc achar
	//melhor pra simular o botao do guidao esquerdo
	//for solto
	public bool getLeftButtonUp()
	{
		return Input.GetKeyUp(KeyCode.LeftArrow);
	}
	
	//Retorna verdadeiro se o botao que vc achar
	//melhor pra simular o botao do guidao direito
	//for pressionado
	public bool getRightButtonDown()
	{
		return Input.GetKeyDown(KeyCode.RightArrow);
	}
	
	//Retorna verdadeiro se o botao que vc achar
	//melhor pra simular o botao do guidao direito
	//for solto
	public bool getRightButtonUp()
	{
		return Input.GetKeyUp(KeyCode.RightArrow);
	}
	
	//Retorna a rpm da bicicleta
	public int getRpm()
	{
		return Random.Range(7, 9);
	}
	
	//Retorna o pulso do individio
	public int getHeartBeat()
	{
		return Random.Range (175, 182);
	}

#endif
}
