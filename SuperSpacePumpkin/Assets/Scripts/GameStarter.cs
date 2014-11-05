using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour 
{
	void Update () 
	{
		if (Input.GetButtonDown("StartLevel")) Application.LoadLevel("Level");
		if (Input.GetButtonDown("t")) Application.LoadLevel("Tutorial");
	}
}
