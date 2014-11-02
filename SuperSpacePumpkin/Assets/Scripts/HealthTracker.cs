using UnityEngine;
using System.Collections;

public class HealthTracker : MonoBehaviour 
{
	private int currentHealth;

	void Start () 
	{
		currentHealth = GameController.controller.PlanetHealth;
	}

	void Update () 
	{
		if (GameController.controller.PlanetHealth != currentHealth)
		{
			currentHealth = GameController.controller.PlanetHealth;
			if (currentHealth < 25)
				gameObject.guiText.color = Color.red; 
			else
				gameObject.guiText.color = Color.white; 
				
			gameObject.guiText.text = currentHealth + "%";
		}
	}
}
