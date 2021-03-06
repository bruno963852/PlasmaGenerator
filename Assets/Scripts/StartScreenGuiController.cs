﻿using UnityEngine;
using System.Collections;

public class StartScreenGuiController : MonoBehaviour 
{
	private ConnectionState conState = ConnectionState.notConnected;

	private int deviceIndex = 0;
	private string[] devices;

	public UILabel conPlayLabel;
	public UILabel deviceLabel;
	public UILabel refSpeedLabel;
	public UIToggle bikeToggle;
	public UIToggle rpmToggle;

	// Use this for initialization
	void Start () 
	{
		devices = gameManager.i.btController.getBondedDevices();
		foreach (string item in devices) {
			Debug.Log(item);
				}
		deviceLabel.text = devices[0];

		refSpeedLabel.text = "RefSpeed: " + gameManager.i.maxGenRpm;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (conState == ConnectionState.Connecting)
		{
			if (gameManager.i.btController.isConnected())
			{
				conState = ConnectionState.Connected;
				conPlayLabel.text = "Play!";
			}
		}
	}

	private void connectDevice()
	{
		gameManager.i.btController.connectDevice(deviceIndex);
		conState = ConnectionState.Connecting;
		conPlayLabel.text = "Wait...";
	}

	public void OnConPlayClick()
	{
		switch (conState) 
		{
		case ConnectionState.notConnected:
			bikeToggle.enabled = false;
			connectDevice();
			break;
		case ConnectionState.Connecting:
			break;
		case ConnectionState.Connected:
			Application.LoadLevel(1);
			break;
		default:
			break;
		}
	}

	public void OnLeftBtnClick()
	{
		if (deviceIndex > 0)
		{
			deviceIndex--;
			deviceLabel.text = devices[deviceIndex];
		}
	}

	public void OnRightBtnClick()
	{
		if (deviceIndex < devices.Length - 1)
		{
			deviceIndex++;
			deviceLabel.text = devices[deviceIndex];
		}
	}

	public void OnPlusBtnClick()
	{
		gameManager.i.maxGenRpm++;
		refSpeedLabel.text = "RefSpeed: " + gameManager.i.maxGenRpm;
	}

	public void OnMinusBtnClick()
	{
		if (gameManager.i.maxGenRpm > 0)
		{
			gameManager.i.maxGenRpm--;
			refSpeedLabel.text = "RefSpeed: " + gameManager.i.maxGenRpm;
		}
	}

	public void OnBikeToggleChange()
	{
		if (bikeToggle.value)
		{
			conState = ConnectionState.notConnected;
			gameManager.i.isOnBikeMode = true;
			conPlayLabel.text = "Connect";
		}
		else
		{
			conState = ConnectionState.Connected;
			gameManager.i.isOnBikeMode = false;
			conPlayLabel.text = "Play!";
		}
	}

	public void OnRpmToggleChange()
	{
		gameManager.i.showRpm = rpmToggle.value;
	}
}
enum ConnectionState
{
	notConnected,
	Connecting,
	Connected
}
