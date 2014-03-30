using UnityEngine;
using System.Collections;

public class FlashScript : MonoBehaviour {

	public float flashingTime = 2;

	private bool isFlashing;
	private SpriteRenderer sRenderer;
	private float updateTime = 0;
	// Use this for initialization
	void Start () 
	{
		sRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isFlashing && updateTime + flashingTime <= Time.time)
		{
			isFlashing = false;
			CancelInvoke();
			sRenderer.enabled = true;
		}
	}

	public void flash()
	{
		if (this.IsInvoking())
		{
			CancelInvoke();
		}
		updateTime = Time.time;
		isFlashing = true;
		InvokeRepeating("alternateVisibility", 0, 0.1f);
	}

	private void alternateVisibility()
	{
		sRenderer.enabled = !sRenderer.isVisible;
	}
}
