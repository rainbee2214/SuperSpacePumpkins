using UnityEngine;
using System.Collections;

public class DisplaySequence : MonoBehaviour 
{
	public GameObject[] guiElements;
	public Color[] colors;
	public float betweenDelay;
	public Vector2 displayPosition;

	float startTime;
	float lastDisplayTime;
	float nextDisplayTime = 0;
	float totalDuration;

	void Start()
	{
		startTime = Time.time;
		lastDisplayTime = startTime;
	}

	void Update()
	{
		if (Time.time > nextDisplayTime)
		{
			DisplayGui();
			lastDisplayTime = Time.time;
			nextDisplayTime = lastDisplayTime + betweenDelay;
		}
	}

	void DisplayGui()
	{

	}

}
