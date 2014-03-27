using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour 
{
	public float shotTime = 0.3f;
	public GameObject bullet;
	public GameObject laserSound;
	public Vector3 rotation;

	private float updateTime;
	private Quaternion quatRotation;

	void Start()
	{
		updateTime = Time.time;

		quatRotation = Quaternion.Euler(rotation);
	}

	void Update () 
	{
		if(updateTime + shotTime <= Time.time)
		{
			Instantiate(bullet, transform.position, quatRotation);
			Instantiate(laserSound, transform.position, Quaternion.identity);

			updateTime = Time.time;
		}
	}
}
