using UnityEngine;
using System.Collections;

public class TimedDeath : MonoBehaviour {

	public float lifespan;
	float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startTime + lifespan)
			Destroy(this.gameObject);
	}
}
