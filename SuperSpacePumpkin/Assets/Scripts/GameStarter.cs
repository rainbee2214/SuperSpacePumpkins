using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour 
{
	
	void Update () 
	{
		if (Input.GetButtonDown("Fire")) Application.LoadLevel("LevelOne");
	}
}
