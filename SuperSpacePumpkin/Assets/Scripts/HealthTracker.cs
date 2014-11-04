using UnityEngine;
using System.Collections;

public class HealthTracker : MonoBehaviour 
{
	private int currentHealth;
	public bool boss = false;

	void Start () 
	{
		boss = this.tag == "Boss" ? true : false;
		if (boss) currentHealth = GameController.controller.BossHealth;
		else currentHealth = GameController.controller.PlanetHealth;
	}

	void Update () 
	{
		if (boss && GameController.controller.BossHealth != currentHealth)
		{
			currentHealth = GameController.controller.BossHealth;

		}

		else if (!boss && GameController.controller.PlanetHealth != currentHealth)
		{
			currentHealth = GameController.controller.PlanetHealth;
			if (currentHealth < 25)
				gameObject.guiText.color = Color.red; 
			else
				gameObject.guiText.color = Color.white; 
		}

		gameObject.guiText.text = currentHealth + "%";
	}
}
