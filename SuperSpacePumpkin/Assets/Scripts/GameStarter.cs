using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour 
{
	public string level;

	void Update () 
	{
		if (Input.GetButtonDown("StartLevel")) Application.LoadLevel(level);
	}
}
