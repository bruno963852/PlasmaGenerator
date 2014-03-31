using UnityEngine;
using System.Collections;

public class GeneralBurstSpawner : MonoBehaviour 
{
	public GameObject[] enemies;
	public float spawnTime;
	public float[] spawnDists;

	private float updateTime;
	private int spawnCount = 0;
	private int maxSpawns;
	// Use this for initialization
	void Start () 
	{
		maxSpawns = enemies.Length;
		updateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spawnCount < maxSpawns && updateTime + spawnTime <= Time.time)
		{
			Instantiate(enemies[spawnCount], transform.position + new Vector3(spawnDists[spawnCount], 0, 0), Quaternion.identity);

			spawnCount++;
			updateTime = Time.time;
		}
		if (spawnCount >= maxSpawns)
		{
			Destroy(gameObject);
		}
	}
}
