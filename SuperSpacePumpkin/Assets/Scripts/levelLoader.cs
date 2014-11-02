using UnityEngine;
using System.Collections;

public class levelLoader : MonoBehaviour 
{

	public string nextLevel;
	public float delay;

	void Update () 
	{
		if (Time.timeSinceLevelLoad > delay)
			Application.LoadLevel(nextLevel);
	}
}
