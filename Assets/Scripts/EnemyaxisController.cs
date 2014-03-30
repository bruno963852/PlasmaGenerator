using UnityEngine;
using System.Collections;

public class EnemyaxisController : MonoBehaviour {

	public float axis = 0;
	public float sensitivity = 0.03f;
	public float gravity = 0.1f;
	public float deadZone = 0.03f;
	public bool restatOnPress = false;
	public bool isExternallySetted = false;

	public FakeButtonState[] fakePresses;
	public float[] fakePressesTimes;

	public FakeButtonState bState = FakeButtonState.up;
	public int movCount = 0;
	public int moves;
	public float updateTime;

	// Use this for initialization
	void Start () 
	{
		moves = fakePresses.Length;
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isExternallySetted)
		{
			doMoviment();
		}

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

	private void doMoviment()
	{
		if(movCount < moves && updateTime + fakePressesTimes[movCount] <= Time.time)
		{
			bState = fakePresses[movCount];

			updateTime = Time.time;
			movCount++;
		}

	}

}

public enum FakeButtonState
{
	positive,
	negative,
	up
}
