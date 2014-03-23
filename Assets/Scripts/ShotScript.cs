using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour 
{
	public float shotTime = 0.3f;
	public GameObject bullet;
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

			updateTime = Time.time;
		}
	}
}
