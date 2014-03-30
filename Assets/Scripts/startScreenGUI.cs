using UnityEngine;
using System.Collections;

public class startScreenGUI : MonoBehaviour 
{
	public Texture2D leftArrow;
	public Rect leftArrowRect;

	public Texture2D rightArrow;
	public Rect rightArrowRect;

	public Rect connectTextRect;
	public float connectTectSize = 1;

	public Rect DeviceNameRect;
	public float DeviceNameFontSize = 1;

	public Rect connPlayBtnRect;

	private GUIContent guiLeftArrow;
	private GUIContent guiRightArrow;

	private string[] devices;
	private int deviceIndex = 0;
	private string connPlayBtnText = "Conect!";
	private connectionState connState = connectionState.notConnected;

	// Use this for initialization
	void Start () 
	{
		devices = gameManager.i.btController.getBondedDevices();
		guiLeftArrow = new GUIContent(leftArrow);
		guiRightArrow = new GUIContent(rightArrow);
	}

	void Update()
	{
		if (gameManager.i.btController.isConnected())
		{
			connState = connectionState.connected;
			connPlayBtnText = "Play!";
		}
	}
	
	void OnGUI()
	{
		if (GUI.Button(leftArrowRect, guiLeftArrow))
		{
			if (deviceIndex > 0)
			{
				deviceIndex--;
			}
		}
		if (GUI.Button(rightArrowRect, guiRightArrow))
		{
			if (deviceIndex < devices.Length - 1)
			{
				deviceIndex++;
			}
		}
		if (connState == connectionState.notConnected)
		{
			if (GUI.Button(connPlayBtnRect, connPlayBtnText))
			{
				gameManager.i.btController.connectDevice(deviceIndex);
			}
		}
		else if (connState == connectionState.connecting)
		{
			GUI.Box(connPlayBtnRect, "Connectiong...");
		}
		else
		{
			if (GUI.Button(connPlayBtnRect, connPlayBtnText))
			{
				Application.LoadLevel(1);
			}
		}
		GUI.Label(connectTextRect, "Connect:");
		GUI.Label(DeviceNameRect, devices[deviceIndex]);
	}
}
public enum connectionState
{
	notConnected,
	connecting,
	connected
}
