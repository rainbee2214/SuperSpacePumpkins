using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour 
{
	
	void Update () 
	{
		if (Input.GetButtonDown(Input.anyKeyDown) == Input.anyKeyDown)
			Debug.Log("..");
	}
}
