using UnityEngine;
using System.Collections;

public class generalEnemySpawner : MonoBehaviour 
{
	public GameObject[] bursts;
	public float[] spawnTimes;
	public float[] spawnPositions;

	public int burstCount = 0;
	public int maxBursts;
	private float updateTime;
	// Use this for initialization
	void Start () 
	{
		updateTime = Time.time;
		maxBursts = bursts.Length;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if((burstCount < maxBursts) && ((updateTime + spawnTimes[burstCount]) <= Time.time))
		{
			Vector3 thePosition = transform.position;
			thePosition.x += spawnPositions[burstCount];

			Instantiate(bursts[burstCount], thePosition, Quaternion.identity);

			Debug.Log("Instantianted in: " + Time.time + "Suposed: " + spawnTimes[burstCount]);
			Debug.Log("updateTime + spawntime = " + updateTime + spawnTimes[burstCount]);

			updateTime = Time.time;
			burstCount++;
		}
	}
}
