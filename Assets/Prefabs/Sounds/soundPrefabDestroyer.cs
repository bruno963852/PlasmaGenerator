using UnityEngine;
using System.Collections;

//Esse script destŕoi um prefab de som quando ele para de tocar
public class soundPrefabDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//se parou de tocar
		if (!this.audio.isPlaying)
		{
			//destroi
			Destroy(this.gameObject);
		}
	}
}
