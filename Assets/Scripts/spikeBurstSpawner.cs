using UnityEngine;
using System.Collections;

public class spikeBurstSpawner : MonoBehaviour 
{
	public GameObject enemy_spike;
	public float spawnTime = 0.8f;
	public float burstSize = 8;
	
	private float updateTime;
	private int spawnCount = 0;
	private int alternator = -1;

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
			Instantiate(enemy_spike, transform.position + new Vector3((spawnCount + 1) * alternator, 0, 0), Quaternion.identity);
			
			updateTime = Time.time;
			spawnCount++;
			alternator *= -1;
		}
		if (spawnCount >= burstSize)
		{
			Destroy(gameObject);
		}
	}
}
