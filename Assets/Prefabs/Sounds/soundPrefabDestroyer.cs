using UnityEngine;
using System.Collections;

public class soundPrefabDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!this.audio.isPlaying)
		{
			Destroy(this.gameObject);
		}
	}
}
