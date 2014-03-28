using UnityEngine;
using System.Collections;

public class enemyShotScripts : MonoBehaviour 
{
	public GameObject shot;
	public GameObject laserSound;
	public float shotFrequency = 1;

	private float updateTime;

	// Use this for initialization
	void Start () 
	{
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (updateTime + shotFrequency <= Time.time)
		{
			Instantiate (shot, transform.position, Quaternion.identity);
			Instantiate(laserSound, transform.position, Quaternion.identity);

			updateTime = Time.time;
		}
	}
}
