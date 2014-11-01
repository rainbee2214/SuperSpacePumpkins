using UnityEngine;
using System.Collections;

public class PlanePosition : MonoBehaviour 
{
	int currentLevel;

	void Start () 
	{
		currentLevel = GameController.controller.Level;
	}
	
	void Update () 
	{
		if (GameController.controller.Level > currentLevel)
		{
			currentLevel = GameController.controller.Level;
			transform.localScale -= new Vector3(2f, 2f, 0f);
		}
	}
}
