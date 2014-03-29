using UnityEngine;
using System.Collections;

public class uBurstSpawner : MonoBehaviour 
{
	public GameObject enemy_u;
	public float spawnTime = 0.5f;
	public int burstSize = 5;

	private float updateTime;
	private int spawnCount = 0;

	// Use this for initialization
	void Start () 
	{
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (updateTime + spawnTime <= Time.time && spawnCount < burstSize)
		{
			Instantiate(enemy_u, transform.position, Quaternion.identity);

			updateTime = Time.time;
			spawnCount++;
		}
		if (spawnCount >= burstSize)
		{
			Destroy(gameObject);
		}
	}
}
