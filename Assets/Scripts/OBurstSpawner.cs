using UnityEngine;
using System.Collections;

public class OBurstSpawner : MonoBehaviour 
{
	public GameObject enemy_o;
	public float spawnTime = 0.6f;
	public float burstSize = 9;

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
			Instantiate(enemy_o, transform.position + new Vector3(spawnCount * 1.5f, 0, 0), Quaternion.identity);
			
			updateTime = Time.time;
			spawnCount++;
		}
		if (spawnCount >= burstSize)
		{
			Destroy(gameObject);
		}
	}
}
