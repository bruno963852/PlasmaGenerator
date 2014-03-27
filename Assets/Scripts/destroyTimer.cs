using UnityEngine;
using System.Collections;

public class destroyTimer : MonoBehaviour {

	public float time = 1;

	private float updateTime;

	// Use this for initialization
	void Start () 
	{
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (updateTime + time <= Time.time)
		{
			Destroy(this.gameObject);
		}
	}
}
